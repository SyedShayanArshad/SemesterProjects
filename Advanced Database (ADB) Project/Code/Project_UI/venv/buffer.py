import time
from collections import Counter, deque

class Buffer:
    def __init__(self, size):
        """Initialize the buffer with the specified size"""
        # Convert size to integer to ensure it's a valid number
        self.size = max(0, int(size)) if size else 0  # Set minimum size to 0 and default to 0
        self.buffer = []
        self.access_count = Counter()
        self.policy = "LRU"
        self.cache = {}
        self.hit_count = 0
        self.miss_count = 0
        self.history = deque(maxlen=50)
        self.logs = []
        # Track read/write operations
        self.read_count = 0
        self.write_count = 0
        self.workload_type = "unknown"
        self.access_history = deque(maxlen=100)  # Track recent accesses for analysis
        # Full eviction tracking - make sure these are properly initialized
        self.eviction_counts = {"LRU": 0, "MRU": 0, "LFU": 0}
        self.eviction_history = []  # Store all evictions with detailed info
        # Track when a page was last accessed
        self.page_last_access = {}
        # Count aging for LFU
        self.enable_count_aging = True
        self.max_access_count = 100
        
        self.log(f"🔄 Buffer initialized with size {self.size} and LRU policy")
        
    def reset(self):
        """Reset all buffer states while maintaining the size"""
        self.buffer = []
        self.access_count = Counter()
        self.policy = "LRU"
        self.cache = {}
        self.hit_count = 0
        self.miss_count = 0
        self.history = deque(maxlen=50)
        self.logs = []
        # Reset workload tracking
        self.read_count = 0
        self.write_count = 0
        self.workload_type = "unknown"
        self.access_history = deque(maxlen=1000)
        # Reset eviction tracking
        self.eviction_counts = {"LRU": 0, "MRU": 0, "LFU": 0}  # Removed TTL
        self.eviction_history = []
        # Reset aging tracking
        self.page_last_access = {}
        # Initialize count aging variables that were missing
        self.enable_count_aging = True
        self.max_access_count = 100
        
        self.log(f"🔄 Buffer reset with size {self.size} and LRU policy")
        self.log(f"🔢 Count aging enabled: {self.enable_count_aging} (max: {self.max_access_count})")
        return self

    def log(self, message):
        self.logs.append(message)
        if len(self.logs) > 100:
            self.logs = self.logs[-100:]

    def switch_policy(self):
        """Switch policy based on observed access patterns"""
        if len(self.history) < 10:
            return

        recent_history = list(self.history)[-20:]
        access_pattern = Counter(recent_history)
        most_common = access_pattern.most_common(1)
        most_frequent = most_common[0][1] if most_common else 0
        unique_queries = len(access_pattern)
        old_policy = self.policy

        # Make LFU more likely to be selected by lowering the threshold
        if most_frequent > len(recent_history) * 0.3:  # Lowered from 0.4 to 0.3
            new_policy = "LFU"
            self.log(f"DEBUG - Detected repeated pattern, suggesting LFU policy")
        elif unique_queries > len(recent_history) * 0.8:
            new_policy = "LRU"
            self.log(f"DEBUG - Detected diverse pattern, suggesting LRU policy")
        else:
            new_policy = "MRU" 
            self.log(f"DEBUG - Detected scanning pattern, suggesting MRU policy")

        # Add random chance to select LFU even when not triggered by pattern
        import random
        if random.random() < 0.15 and new_policy != "LFU":  # 15% chance to use LFU
            new_policy = "LFU"
            self.log(f"DEBUG - Randomly selected LFU policy to increase variety")

        if new_policy != old_policy:
            self.policy = new_policy
            self.log(f"🔁 Switched from {old_policy} to {new_policy} policy based on workload analysis")
            self.log(f"   - Unique pages: {unique_queries}/{len(recent_history)} ({unique_queries/len(recent_history)*100:.1f}%)")
            if most_common:
                self.log(f"   - Most frequent page: {most_common[0][0]} appeared {most_frequent} times ({most_frequent/len(recent_history)*100:.1f}%)")

    def analyze_workload(self):
        """Analyze the current workload pattern based on access history"""
        if len(self.access_history) < 10:
            return "insufficient-data"
            
        # Calculate read/write ratio
        read_ratio = self.read_count / max(1, (self.read_count + self.write_count))
        
        # Calculate unique pages ratio
        recent_accesses = list(self.access_history)
        unique_pages = len(set(recent_accesses))
        unique_ratio = unique_pages / len(recent_accesses)
        
        # Detect access patterns
        counter = Counter(recent_accesses)
        most_common = counter.most_common(1)[0][1] if counter else 0
        repeat_ratio = most_common / len(recent_accesses) if recent_accesses else 0
        
        old_workload = self.workload_type
        
        # Determine workload type with more sensitivity to repetitive patterns
        if read_ratio > 0.7:  # Lowered from 0.8 to detect more read-heavy patterns
            if repeat_ratio > 0.4:  # Lowered from 0.5 to detect more repetitive patterns
                self.workload_type = "read-heavy-repetitive"
            else:
                self.workload_type = "read-heavy-diverse"
        elif read_ratio < 0.3:
            self.workload_type = "write-heavy"
        elif unique_ratio > 0.7:
            self.workload_type = "mixed-diverse"
        else:
            self.workload_type = "mixed-repetitive"
            
        if old_workload != self.workload_type:
            self.log(f"📊 Workload pattern changed: {old_workload} → {self.workload_type}")
            self.log(f"   - Read ratio: {read_ratio:.2f}, Unique ratio: {unique_ratio:.2f}, Repeat ratio: {repeat_ratio:.2f}")
            
        return self.workload_type

    def access_page(self, page, operation="read"):
        """Access a page with the specified operation (read or write)"""
        # Update operation counts
        if operation.lower() == "read":
            self.read_count += 1
        elif operation.lower() == "write":
            self.write_count += 1
        
        # Check if the buffer is initialized with a valid size
        if self.size <= 0:
            self.size = 5  # Set a default size if invalid
            self.log(f"⚠️ Invalid buffer size, reset to default: {self.size}")
        
        # Update access history for workload analysis
        self.access_history.append((page, operation))
        
        # First, check if page is in buffer BEFORE updating any counters
        hit = page in self.buffer
        
        # Update access time and history AFTER determining hit/miss
        self.page_last_access[page] = time.time()
        self.history.append(page)
        
        if hit:
            # Page hit - increment access count ONLY now after confirming it's a hit
            self.access_count[page] += 1
            self.hit_count += 1
            self.log(f"✅ Page {page} hit! ({operation}) - New access count: {self.access_count[page]}")
        else:
            # Page miss - initialize access count to 1
            self.access_count[page] = 1  # Start with count 1 on first access
            self.miss_count += 1
            self.log(f"❌ Page {page} miss! ({operation}) - Initial access count: 1")
            
            # Check if buffer is full before adding new page
            if len(self.buffer) >= self.size:
                # Buffer is full, need to replace a page
                self.replace_page(page)
            else:
                # Buffer has space, just add the new page
                self.buffer.append(page)
                self.log(f"📥 Added page {page} to buffer (current size: {len(self.buffer)}/{self.size})")
        
        # Force a policy evaluation occasionally
        if (self.hit_count + self.miss_count) % 10 == 0:
            self.switch_policy()
            self.analyze_workload()
            self.log(f"Current policy: {self.policy} after {self.hit_count + self.miss_count} total accesses")
            
            # Print contents of buffer with access counts
            buffer_stats = [(p, self.access_count.get(p, 0)) for p in self.buffer]
            self.log(f"Buffer contents with access counts: {buffer_stats}")
        
        return hit

    # Add a method to get current hit/miss statistics for this run only
    def get_current_run_stats(self, previous_hits, previous_misses):
        """Get hit/miss statistics for the current run only"""
        current_hits = self.hit_count - previous_hits
        current_misses = self.miss_count - previous_misses
        total = current_hits + current_misses
        
        hit_rate = (current_hits / total * 100) if total > 0 else 0
        
        return {
            "hits": current_hits,
            "misses": current_misses,
            "total": total,
            "hit_rate": hit_rate
        }

    def adapt_policy_to_workload(self):
        """Adapt buffer policy based on workload analysis"""
        workload = self.workload_type
        old_policy = self.policy
        
        # Biasing toward LFU a bit more
        if workload == "read-heavy-repetitive" or workload == "mixed-repetitive":
            new_policy = "LFU"  # LFU works well for frequently repeated reads
        elif workload == "write-heavy":
            new_policy = "LRU"  # LRU is generally good for writes
        elif workload == "mixed-diverse":
            # Give LFU a chance in mixed-diverse workloads too
            import random
            new_policy = "LFU" if random.random() < 0.4 else "LRU"
        elif workload == "read-heavy-diverse":
            new_policy = "MRU"  # MRU can work well for scan-heavy workloads
        else:
            return  # No change needed
            
        if new_policy != old_policy:
            self.policy = new_policy
            self.log(f"🔁 Auto-switched from {old_policy} to {new_policy} policy based on {workload} workload")

    # Full implementation of the replace_page method to correctly track evictions
    def replace_page(self, new_page):
        """Replace a page in the buffer based on current policy"""
        if len(self.buffer) < self.size:
            # No need to replace, just add
            self.buffer.append(new_page)
            self.page_last_access[new_page] = time.time()
            self.log(f"📥 Added page {new_page} to buffer (no replacement needed)")
            return
            
        # Track the old policy for eviction stats
        current_policy = self.policy
        old_page = None
        
        # Force policy execution to ensure correct eviction
        if self.policy == "LRU":
            old_page = self.remove_least_recently_used()
            self.eviction_counts["LRU"] += 1
            self.log(f"🔥 Evicted page {old_page} using LRU policy")
        elif self.policy == "MRU":
            old_page = self.remove_most_recently_used()
            self.eviction_counts["MRU"] += 1
            self.log(f"🔥 Evicted page {old_page} using MRU policy")
        elif self.policy == "LFU":
            old_page = self.remove_least_frequently_used()
            self.eviction_counts["LFU"] += 1
            self.log(f"🔥 Evicted page {old_page} using LFU policy (access count: {self.access_count.get(old_page, 0)})")
        else:
            # Default to LRU if unknown policy
            old_page = self.remove_least_recently_used()
            self.eviction_counts["LRU"] += 1
            self.log(f"🔥 Evicted page {old_page} using LRU policy (default)")
        
        # Add the new page after eviction
        if new_page not in self.buffer:
            self.buffer.append(new_page)
            self.page_last_access[new_page] = time.time()
            self.log(f"📥 Added page {new_page} after eviction using {current_policy} policy")
            
        # Ensure buffer doesn't exceed size
        while len(self.buffer) > self.size:
            removed_page = self.buffer.pop(0)
            self.log(f"⚠️ Enforcing buffer size limit: removed extra page {removed_page}")

    # Implement the add_eviction_record method
    def add_eviction_record(self, page, reason, mechanism="Policy"):
        """Add a record of an eviction event"""
        timestamp = time.time()
        eviction_record = {
            "page": page,
            "timestamp": timestamp,
            "reason": reason,
            "mechanism": mechanism,
            "policy": self.policy,
            "access_count": self.access_count.get(page, 0)
        }
        
        self.eviction_history.append(eviction_record)
        self.log(f"📝 Recorded eviction: {page} (policy: {self.policy}, access count: {self.access_count.get(page, 0)})")

    def remove_least_recently_used(self):
        """Remove least recently used page from buffer"""
        if not self.buffer:
            return None
            
        # Use page_last_access dictionary to find LRU page
        lru_page = None
        oldest_time = float('inf')
        
        for page in self.buffer:
            access_time = self.page_last_access.get(page, 0)
            if access_time < oldest_time:
                oldest_time = access_time
                lru_page = page
                
        if lru_page is not None:
            self.buffer.remove(lru_page)
            # Make sure to call add_eviction_record before returning
            self.add_eviction_record(lru_page, "Buffer full, removed LRU page")
            return lru_page
            
        # Fallback to the first page in buffer if no timestamps available
        old_page = self.buffer[0]
        self.buffer.remove(old_page)
        self.add_eviction_record(old_page, "Buffer full, removed first page (LRU fallback)")
        return old_page

    def remove_most_recently_used(self):
        """Remove most recently used page from buffer"""
        if not self.buffer:
            return None
            
        # Use page_last_access dictionary to find MRU page
        mru_page = None
        newest_time = 0
        
        for page in self.buffer:
            access_time = self.page_last_access.get(page, 0)
            if access_time > newest_time:
                newest_time = access_time
                mru_page = page
                
        if mru_page is not None:
            self.buffer.remove(mru_page)
            # Make sure to call add_eviction_record before returning
            self.add_eviction_record(mru_page, "Buffer full, removed MRU page")
            return mru_page
            
        # Fallback to the last page in buffer if no timestamps available
        old_page = self.buffer[-1]
        self.buffer.remove(old_page)
        self.add_eviction_record(old_page, "Buffer full, removed last page (MRU fallback)")
        return old_page

    def remove_least_frequently_used(self):
        """Remove least frequently used page from buffer"""
        if not self.buffer:
            self.log(f"⚠️ Cannot apply LFU: Buffer is empty")
            return None

        # Debug print to check current access counts
        buffer_access_counts = {p: self.access_count.get(p, 0) for p in self.buffer}
        self.log(f"DEBUG - LFU checking pages with access counts: {buffer_access_counts}")
        
        # Find the page with the lowest access count in the buffer
        least_used_page = None
        least_count = float('inf')

        for page in self.buffer:
            count = self.access_count.get(page, 0)
            if count < least_count:
                least_count = count
                least_used_page = page
        
        # Failsafe: if something went wrong with access count tracking
        if least_used_page is None:
            self.log(f"⚠️ LFU error: No page found with minimum count, defaulting to first page")
            least_used_page = self.buffer[0] if self.buffer else None
            least_count = self.access_count.get(least_used_page, 0)
        
        # If there are multiple pages with the same lowest count, use LRU as tie-breaker
        candidates = [p for p in self.buffer if self.access_count.get(p, 0) == least_count]
        
        if len(candidates) > 1:
            self.log(f"DEBUG - LFU found {len(candidates)} pages with same lowest count {least_count}: {candidates}")
            # Use LRU as tie-breaker
            oldest_time = float('inf')
            for page in candidates:
                access_time = self.page_last_access.get(page, 0)
                if access_time < oldest_time:
                    oldest_time = access_time
                    least_used_page = page
            
            self.log(f"DEBUG - LFU tie broken by LRU, selected page {least_used_page} (time: {oldest_time})")
        
        # Remove the selected page
        if least_used_page in self.buffer:
            self.buffer.remove(least_used_page)
            self.add_eviction_record(least_used_page, f"LFU eviction (access count: {least_count})")
            self.log(f"LFU evicted page {least_used_page} with access count {least_count}")
            return least_used_page
        
        # This should not happen, but if it does, default to first page
        if self.buffer:
            old_page = self.buffer[0]
            self.buffer.remove(old_page)
            self.add_eviction_record(old_page, "LFU fallback - something went wrong")
            self.log(f"⚠️ LFU fallback: removed first page {old_page}")
            return old_page
        
        self.log(f"⚠️ LFU critical error: No page to remove!")
        return None

    # Update check_expired_pages to only check count-based expiry
    def check_expired_pages(self):
        """Check and remove expired pages based on access count"""
        pages_to_remove = []
        
        for page in self.buffer:
            # Check for access count-based expiry
            if self.enable_count_aging and page in self.access_count:
                if self.access_count[page] > self.max_access_count:
                    reason = f"Max access count reached ({self.access_count[page]}/{self.max_access_count})"
                    pages_to_remove.append((page, reason))
        
        # Remove expired pages
        for page, reason in pages_to_remove:
            if page in self.buffer:
                self.buffer.remove(page)
                self.add_eviction_record(page, reason, "Count")
                self.log(f"🔢 Evicted page {page}: {reason}")
        
        return len(pages_to_remove) > 0

    # Update the stats method to ensure access counts are properly formatted
    def stats(self):
        """Return current buffer statistics"""
        total_ops = self.hit_count + self.miss_count
        hit_rate = (self.hit_count / total_ops * 100) if total_ops > 0 else 0
        total_accesses = self.read_count + self.write_count
        read_ratio = (self.read_count / total_accesses * 100) if total_accesses > 0 else 0
        write_ratio = (self.write_count / total_accesses * 100) if total_accesses > 0 else 0

        self.log("\n📊 Buffer Stats:")
        self.log(f"Total Hits: {self.hit_count}")
        self.log(f"Total Misses: {self.miss_count}")
        self.log(f"Hit Rate: {hit_rate:.2f}%")
        self.log(f"Read/Write: {self.read_count}/{self.write_count} ({read_ratio:.1f}%/{write_ratio:.1f}%)")
        self.log(f"Workload Type: {self.workload_type}")
        self.log(f"Current Buffer Content: {self.buffer}")
        self.log(f"Current Policy: {self.policy}")

        # Create access frequency data for the chart
        access_frequency = {}
        for page, count in self.access_count.most_common(10):
            access_frequency[str(page)] = count
            
        # Create a properly formatted access count dictionary for the template
        # Making sure to convert all keys to strings for template access
        formatted_access_count = {}
        for page, count in self.access_count.items():
            formatted_access_count[str(page)] = count
        
        # Debug log to verify access counts for pages in buffer
        buffer_access_counts = [(page, self.access_count.get(page, 0)) for page in self.buffer]
        self.log(f"DEBUG - Current buffer pages with access counts: {buffer_access_counts}")
        
        # Debug log to check eviction history
        self.log(f"DEBUG - Eviction history length: {len(self.eviction_history)}")
        if self.eviction_history:
            self.log(f"DEBUG - Last eviction: {self.eviction_history[-1]}")
        
        # Make sure eviction_history is copied properly, not by reference
        eviction_history_copy = []
        for record in self.eviction_history:
            eviction_history_copy.append(record.copy())

        return {
            "logs": self.logs.copy(),
            "size": self.size,
            "buffer": self.buffer.copy(),  
            "hits": self.hit_count,  
            "misses": self.miss_count,
            "total_ops": total_ops,
            "hit_rate": hit_rate,
            "policy": self.policy,  
            "read_count": self.read_count,
            "write_count": self.write_count,
            "workload_type": self.workload_type,
            "access_frequency": access_frequency,
            "eviction_history": eviction_history_copy,  # Use our properly copied history
            "eviction_counts": self.eviction_counts.copy(),
            "access_count": formatted_access_count
        }
        
    # Also adding a dedicated method to force a specific policy for testing
    def set_policy(self, policy):
        """Force a specific replacement policy"""
        valid_policies = ["LRU", "MRU", "LFU"]
        if policy in valid_policies:
            old_policy = self.policy
            self.policy = policy
            self.log(f"⚙️ Manually changed policy from {old_policy} to {policy}")
            return True
        self.log(f"⚠️ Invalid policy '{policy}'. Valid options are: {valid_policies}")
        return False
