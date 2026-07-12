INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
;Task-1
COMMENT &
.data
prompt BYTE "Enter First number: ", 0
prompt2 BYTE "Enter Second number: ", 0
prompt3 BYTE "The sum is: ", 0
.code
AddNum PROC
push ebp
mov ebp, esp
mov eax, [ebp + 8]
mov ebx, [ebp + 12] 
add eax, ebx 
pop ebp
ret 8 
AddNum ENDP
main PROC
mov edx,OFFSET prompt
call WriteString
call ReadInt
push eax
mov edx,OFFSET prompt2
call WriteString
call ReadInt
push eax
call AddNum
mov edx,OFFSET prompt3
call WriteString
call WriteInt
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
;Task-2
COMMENT &
.data
prompt BYTE "Enter Size of Array: ", 0
prompt2 BYTE "Enter Array Elements: ", 0
prompt3 BYTE "The sum is: ", 0
.code
ArraySum PROC
LOCAL arrayAddress:DWORD
LOCAL arraySize :DWORD
mov edx,offset prompt
call WriteString
call ReadInt
mov arraySize, eax
shl eax, 2 
sub esp, eax
mov arrayAddress, esp
mov edx, offset prompt2
call WriteString
mov ecx, arraySize
mov esi, arrayAddress
mov ebx, 0
getValue:
call ReadInt
mov [esi+4*ebx], eax
inc ebx
loop getValue
mov ecx, arraySize
mov eax, 0
mov ebx, 0
computeSum:
add eax, [esi+4*ebx]
inc ebx
loop computeSum
mov ecx, arraySize
    shl ecx, 2
    add esp, ecx
ret 
ArraySum ENDP
main PROC
 call ArraySum
 mov edx, offset prompt3
 call WriteString
 call WriteInt
 exit
 INVOKE ExitProcess,0
 main ENDP
 END main
&
;Task-3
COMMENT &
.data
prompt BYTE "Enter Table Number to Print: ", 0
prompt2 BYTE "Enter Initial Range: ", 0
prompt3 BYTE "Enter Final Range: ", 0
num dd ?
start dd ?
final dd ?
.code
Table PROC, n:DWORD, s:DWORD, f:DWORD
mov ecx,n
mov ebx,s
calculate:
cmp ebx,f
jg done
mov eax,ecx
mul ebx
call WriteInt
call Crlf
inc ebx
jmp calculate
done:
ret
Table ENDP
main PROC
mov edx, OFFSET prompt
call WriteString
call ReadInt
mov num, eax
mov edx, OFFSET prompt2
call WriteString
call ReadInt
mov start, eax
mov edx, OFFSET prompt3
call WriteString
call ReadInt
mov final, eax
Invoke Table, num, start, final
 exit
 INVOKE ExitProcess,0
 main ENDP
 END main
 &
;Task-4
COMMENT &
.data
prompt BYTE "Enter Size of Array: ", 0
prompt2 BYTE "Enter Array Elements: ", 0
prompt3 BYTE "The Square Result is: ", 0
space BYTE "     ", 0
.code
ArraySquare PROC
LOCAL arrayAddress:DWORD
LOCAL arraySize :DWORD
mov edx,offset prompt
call WriteString
call ReadInt
mov arraySize, eax
shl eax, 2 
sub esp, eax
mov arrayAddress, esp
mov edx, offset prompt2
call WriteString
mov ecx, arraySize
mov esi, arrayAddress
mov ebx, 0
getValue:
call ReadInt
mov [esi+4*ebx], eax
inc ebx
loop getValue
mov ecx, arraySize
mov eax, 0
mov ebx, 0
mov edx, offset prompt3
call WriteString
call crlf
computeSquare:
mov eax, [esi+4*ebx]
call WriteInt 
mov edx, OFFSET space
call WriteString
mul eax
call WriteInt
call Crlf
inc ebx
loop computeSquare
mov ecx, arraySize
    shl ecx, 2
    add esp, ecx
ret 
ArraySquare ENDP
main PROC
  call ArraySquare
 exit
 INVOKE ExitProcess,0
 main ENDP
 END main
 &
 end