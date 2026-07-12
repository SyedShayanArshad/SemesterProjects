INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
INCLUDELIB shell32.lib
INCLUDELIB user32.lib
INCLUDELIB kernel32.lib

.386
.stack 4096

ExitProcess PROTO, dwExitCode:DWORD
WriteChar PROTO
Crlf PROTO
WriteString PROTO
ReadChar PROTO
GetMSeconds PROTO
WriteDec PROTO
OpenInputFile PROTO
ReadFromFile PROTO
CloseFile PROTO 
ShellExecuteA PROTO, hwnd:DWORD, lpOperation:DWORD, lpFile:DWORD, lpParameters:DWORD, lpDirectory:DWORD, nShowCmd:DWORD
Delay PROTO
CloseHandle PROTO, hObject:DWORD
DeleteFileA PROTO, lpFileName:DWORD
SetTextColor PROTO
GetSystemMetrics PROTO, nIndex:DWORD
FindWindowA PROTO, lpClassName:DWORD, lpWindowName:DWORD
GetConsoleWindow PROTO
SetWindowPos PROTO, hWnd:DWORD, hWndInsertAfter:DWORD, X:DWORD, Y:DWORD, nWidth:DWORD, nHeight:DWORD, uFlags:DWORD


; Color constants
CONSOLE_BLACK     = 0
CONSOLE_BLUE      = 1
CONSOLE_GREEN     = 2
CONSOLE_CYAN      = 3
CONSOLE_RED       = 4
CONSOLE_MAGENTA   = 5
CONSOLE_YELLOW    = 6
CONSOLE_WHITE     = 7
CONSOLE_LIGHTBLUE = 9
CONSOLE_LIGHTGREEN = 10
CONSOLE_LIGHTCYAN = 11
CONSOLE_LIGHTRED  = 12
CONSOLE_LIGHTMAGENTA = 13
CONSOLE_LIGHTYELLOW = 14
CONSOLE_BRIGHTWHITE = 15

; Text styles (foreground | (background << 4))
TITLE_COLOR       = CONSOLE_LIGHTYELLOW 
INSTRUCTION_COLOR = CONSOLE_LIGHTGREEN
ERROR_COLOR       = CONSOLE_LIGHTRED
SUCCESS_COLOR     = CONSOLE_LIGHTGREEN
METRIC_COLOR      = CONSOLE_LIGHTCYAN
INPUT_COLOR       = CONSOLE_WHITE
DEFAULT_COLOR     = CONSOLE_WHITE
PARAGRAPH_COLOR   = CONSOLE_BRIGHTWHITE
PROMPT_COLOR      = CONSOLE_LIGHTMAGENTA
TIME_COLOR        = CONSOLE_LIGHTBLUE

; Standard word length (characters per word)
STD_WORD_LENGTH   = 5

; Fixed width for display - IMPORTANT, DO NOT CHANGE
FIXED_WIDTH       = 100

; Key constants
ESC_KEY           = 27  ; ASCII value for ESC key

; Add these constants for window positioning
SM_CXSCREEN EQU 0       ; Screen width
SM_CYSCREEN EQU 1       ; Screen height
HWND_TOP EQU 0
SWP_NOSIZE EQU 1h
SWP_NOZORDER EQU 4h

.data
operation     BYTE "open", 0
pythonExe     BYTE "cmd.exe", 0
commandLine30 BYTE "/c python generate_words.py 30sec", 0
commandLine1  BYTE "/c python generate_words.py 1min", 0
commandLine2  BYTE "/c python generate_words.py 2min", 0
commandLineC  BYTE "/c python generate_words.py complete", 0
commandLine   BYTE 64 DUP(0)               ; Buffer for selected command line
wordsFile     BYTE "word.txt", 0
timeFile      BYTE "time_setting.txt", 0   ; File for time setting
syncFile      BYTE "C:\Users\Shayan\OneDrive\Desktop\COAL\COAL\sync.txt", 0
syncContent   BYTE "sync", 0
bytesWritten  DWORD ?
fileBuffer    BYTE 1024 DUP(0)
timeBuffer    BYTE 16 DUP(0)               ; Buffer for reading time setting
fileHandle    DWORD ?
timeHandle    DWORD ?
syncHandle    DWORD ?
bytesRead     DWORD ?

; Add these variables
screenWidth DWORD ?
screenHeight DWORD ?
windowWidth DWORD 800   ; Adjust based on your window's typical width
windowHeight DWORD 600  ; Adjust based on your window's typical height
windowY DWORD ?
windowTitle BYTE "Typing Speed Test", 0  ; Match your window title


originalColor DWORD ?                       ; To store the original console color

; Messages with formatting characters
execMsg       BYTE "Executing Python script...", 0
execSuccessMsg BYTE "Python script executed successfully.", 0
execFailMsg   BYTE "Error: Python script execution failed. Error code: ", 0
fileOpenMsg   BYTE "word.txt opened successfully.", 0
fileReadMsg   BYTE "word.txt read successfully.", 0
openErrorMsg  BYTE "Error: Failed to open word.txt.", 0
readErrorMsg  BYTE "Error: Failed to read word.txt.", 0

titleMsg      BYTE "===== TYPING SPEED TEST =====", 0
dividerLine   BYTE "--------------------------------", 0
prompt        BYTE "Type the following paragraph:", 0
inputPrompt   BYTE "Start typing (Press ESC to stop): ", 0
timeMsg       BYTE "Time taken: ", 0
zeroTimeErrorMsg BYTE "Error: Elapsed time is zero.", 0
secondsMsg    BYTE " seconds", 0
speedMsg      BYTE "Typing speed: ", 0
wpmMsg        BYTE " words per minute.", 0
errorMsg      BYTE "Error: Input does not match the paragraph.", 0
successMsg    BYTE "Success: Input matches the paragraph!", 0
accuracyMsg   BYTE "Typing accuracy: ", 0
percentMsg    BYTE " %", 0
bufferFullMsg BYTE "Error: Input buffer full!", 0
noInputMsg    BYTE "Error: No input provided!", 0
emptyParagraphMsg BYTE "Error: Paragraph is empty!", 0
errorCountMsg BYTE "Total errors: ", 0
backspaceMsg  BYTE "Backspace key presses: ", 0
cpmMsg        BYTE "Characters per minute: ", 0
grossWPMMsg   BYTE "Gross WPM: ", 0 
netWPMMsg     BYTE "Net WPM: ", 0
completionMsg BYTE "Completion percentage: ", 0
timeLimit     DWORD 60000                  ; Default time limit (60 seconds)
timeUpMsg     BYTE "Time's up! Input collection stopped.", 0
completeMsg   BYTE "Paragraph completed!", 0
escPressedMsg BYTE "Test stopped by user (ESC key). Results for partial test:", 0
newline       BYTE 0Dh, 0Ah, 0
backspaceChar BYTE 08h, 0
spaceChar     BYTE " ", 0
userInput     BYTE 1024 DUP(0)
inputIndex    DWORD 0
startTime     DWORD ?
endTime       DWORD ?
elapsedTime   DWORD ?
wordCount     DWORD ?
correctChars  DWORD ?
errorCount    DWORD ?
backspaceCount DWORD ?
paragraphLength DWORD ?
accuracy      DWORD ?
completion    DWORD ?
timeLimitMsg  BYTE "Time limit: ", 0
secondsForLimitMsg BYTE " seconds", 0
noTimeLimitMsg BYTE "No time limit (complete paragraph mode)", 0
resultTitle   BYTE "===== TYPING TEST RESULTS =====", 0
grossWPM      DWORD ?                      ; Gross Words Per Minute
netWPM        DWORD ?                      ; Net Words Per Minute
charsTyped    DWORD ?                      ; Total characters typed (including errors)
testMode      BYTE 0                       ; Selected test mode
isNoTimeLimit BYTE 0                       ; Flag for no time limit mode
helpMsg       BYTE "Press ESC at any time to stop the test and view results", 0

; Menu messages
menuTitle     BYTE "Select Test Mode:", 0
menuOption1   BYTE "1. 30 seconds (Short test)", 0
menuOption2   BYTE "2. 1 minute (Standard test - Recommended)", 0
menuOption3   BYTE "3. 2 minutes (Extended test)", 0
menuOption4   BYTE "4. Complete paragraph (No time limit)", 0
menuPrompt    BYTE "Enter your choice (1-4): ", 0
invalidChoice BYTE "Invalid choice! Please select 1-4.", 0

; Border strings
topBorder     BYTE "+----------------------------------------+", 0
sideBorder    BYTE "|", 0
bottomBorder  BYTE "+----------------------------------------+", 0
padding       BYTE " ", 0

; Paragraph borders with FIXED width (100 chars)
paraTopBorder    BYTE "+----------------------------------------------------------------------------------------------------+", 0
paraSideBorder   BYTE "|", 0
paraBottomBorder BYTE "+----------------------------------------------------------------------------------------------------+", 0
paraPadding      BYTE " ", 0

; Simple buffer for line display with fixed width
lineBuffer    BYTE 150 DUP(0)              ; Line buffer (larger than needed)
lineIndex     DWORD 0                      ; Current position in line buffer

; Line width is fixed at FIXED_WIDTH - 2 (for borders)
maxLineChars  DWORD 98                     ; FIXED_WIDTH - 2

.code

PositionWindow PROC
    ; Get screen dimensions
    INVOKE GetSystemMetrics, SM_CXSCREEN
    mov screenWidth, eax
    INVOKE GetSystemMetrics, SM_CYSCREEN
    mov screenHeight, eax
    
    ; Calculate right-center position (X position will be at right side, Y centered vertically)
    mov eax, screenHeight
    sub eax, windowHeight
    shr eax, 1           ; Divide by 2 to center vertically
    mov windowY, eax
    
    ; Get handle to console window
    INVOKE GetConsoleWindow
    
    ; Position window
    INVOKE SetWindowPos, eax, HWND_TOP, 370, windowY, 0, 0, SWP_NOSIZE + SWP_NOZORDER
    ret
PositionWindow ENDP

; Simple procedure to draw top border with fixed width
DrawTopBorder PROC
    mov edx, OFFSET topBorder
    call WriteString
    call Crlf
    ret
DrawTopBorder ENDP

; Simple procedure to draw bottom border with fixed width
DrawBottomBorder PROC
    mov edx, OFFSET bottomBorder
    call WriteString
    call Crlf
    ret
DrawBottomBorder ENDP

; Simple procedure to draw side borders
DrawSideBorders PROC
    mov edx, OFFSET sideBorder
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    ret
DrawSideBorders ENDP

; Simple procedure to draw paragraph top border with fixed width
DrawParaTopBorder PROC
    mov edx, OFFSET paraTopBorder
    call WriteString
    call Crlf
    ret
DrawParaTopBorder ENDP

; Simple procedure to draw paragraph bottom border with fixed width
DrawParaBottomBorder PROC
    mov edx, OFFSET paraBottomBorder
    call WriteString
    call Crlf
    ret
DrawParaBottomBorder ENDP

; Simple procedure to draw paragraph side borders
DrawParaSideBorders PROC
    mov edx, OFFSET paraSideBorder
    call WriteString
    mov edx, OFFSET paraPadding
    call WriteString
    ret
DrawParaSideBorders ENDP

; Procedure to display menu and get test mode selection
DisplayMenu PROC
    mov eax, TITLE_COLOR
    call SetTextColor
    call DrawTopBorder
    
    call DrawSideBorders
    mov edx, OFFSET menuTitle
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET menuOption1
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET menuOption2
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET menuOption3
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET menuOption4
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawBottomBorder
    
    mov eax, PROMPT_COLOR
    call SetTextColor
    call Crlf
    mov edx, OFFSET menuPrompt
    call WriteString
    
    mov eax, INPUT_COLOR
    call SetTextColor
    
getChoice:
    call ReadChar
    sub al, '0'  ; Convert from ASCII
    cmp al, 1
    jl invalidInput
    cmp al, 4
    jg invalidInput
    
    mov testMode, al
    add al, '0'  ; Convert back to ASCII for display
    call WriteChar  ; Echo the character
    call Crlf
    call Crlf
    
    ; Convert testMode back to number
    movzx eax, testMode
    jmp choiceValid
    
invalidInput:
    call Crlf
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET invalidChoice
    call WriteString
    call Crlf
    
    mov eax, PROMPT_COLOR
    call SetTextColor
    mov edx, OFFSET menuPrompt
    call WriteString
    
    mov eax, INPUT_COLOR
    call SetTextColor
    jmp getChoice
    
choiceValid:
    ; Set command line based on choice
    cmp testMode, 1
    je use30Sec
    cmp testMode, 2
    je use1Min
    cmp testMode, 3
    je use2Min
    jmp useComplete
    
use30Sec:
    mov esi, OFFSET commandLine30
    mov edi, OFFSET commandLine
    call CopyString
    jmp menuDone
    
use1Min:
    mov esi, OFFSET commandLine1
    mov edi, OFFSET commandLine
    call CopyString
    jmp menuDone
    
use2Min:
    mov esi, OFFSET commandLine2
    mov edi, OFFSET commandLine
    call CopyString
    jmp menuDone
    
useComplete:
    mov esi, OFFSET commandLineC
    mov edi, OFFSET commandLine
    call CopyString
    mov isNoTimeLimit, 1
    
menuDone:
    mov eax, DEFAULT_COLOR
    call SetTextColor
    ret
DisplayMenu ENDP

; Procedure to copy null-terminated string from ESI to EDI
CopyString PROC
copyLoop:
    mov al, [esi]
    mov [edi], al
    cmp al, 0
    je copyDone
    inc esi
    inc edi
    jmp copyLoop
copyDone:
    ret
CopyString ENDP

; Simple procedure to display paragraph safely with fixed width
DisplaySimpleParagraph PROC
    push eax  ; Save color
    push esi
    push edi
    push ecx
    push ebx
    
    mov esi, OFFSET fileBuffer  ; Source paragraph
    mov ecx, 0                  ; Character counter
    
processLine:
    mov edi, OFFSET lineBuffer  ; Reset line buffer pointer
    mov lineIndex, 0            ; Reset line index
    
fillLine:
    ; Get character from paragraph
    mov al, [esi]
    
    ; Check for end of paragraph
    cmp al, 0
    je flushLastLine
    
    ; Add character to line buffer
    mov [edi], al
    inc edi
    inc lineIndex
    inc esi
    
    ; Check if we've reached max line width
    mov eax, lineIndex
    cmp eax, maxLineChars
    jae displayCurrentLine
    
    ; Continue processing line
    jmp fillLine
    
displayCurrentLine:
    ; Null terminate the line
    mov BYTE PTR [edi], 0
    
    ; Display the line
    call DrawParaSideBorders
    mov edx, OFFSET lineBuffer
    call WriteString
    
    ; Add right border and newline
    mov edx, OFFSET paraSideBorder
    call WriteString
    call Crlf
    
    ; Move to next line
    jmp processLine
    
flushLastLine:
    ; Check if there's any content in the last line
    cmp lineIndex, 0
    je paragraphDone
    
    ; Null terminate the last line
    mov BYTE PTR [edi], 0
    
    ; Display the last line
    call DrawParaSideBorders
    mov edx, OFFSET lineBuffer
    call WriteString
    
    ; Calculate padding needed to reach fixed width
    mov ebx, maxLineChars
    sub ebx, lineIndex
    mov ecx, ebx
    
    ; Add padding spaces
fillPadding:
    cmp ecx, 0
    je paddingDone
    mov edx, OFFSET paraPadding
    call WriteString
    dec ecx
    jmp fillPadding
    
paddingDone:
    ; Add right border and newline
    mov edx, OFFSET paraSideBorder
    call WriteString
    call Crlf
    
paragraphDone:
    pop ebx
    pop ecx
    pop edi
    pop esi
    pop eax  ; Restore color
    ret
DisplaySimpleParagraph ENDP

; New procedure to display paragraph header and border safely
DisplayParagraphHeader PROC
    call Crlf
    mov eax, INSTRUCTION_COLOR
    call SetTextColor
    
    ; Draw top border
    call DrawParaTopBorder
    
    ; Display prompt with left border
    call DrawParaSideBorders
    mov edx, OFFSET prompt
    call WriteString
    
    ; Add right border and newline
    mov edx, OFFSET paraSideBorder
    call WriteString
    call Crlf
    
    ret
DisplayParagraphHeader ENDP

; Parse a decimal string in ESI to a number in EAX
ParseDecimal PROC
    push ebx
    push ecx
    push edx
    
    mov eax, 0    ; Result
    mov ebx, 10   ; Base 10
    
parseLoop:
    mov cl, [esi]
    cmp cl, 0
    je parseDone
    cmp cl, '0'
    jb parseDone
    cmp cl, '9'
    ja parseDone
    
    ; Convert digit
    sub cl, '0'
    mov edx, 0
    mul ebx
    movzx ecx, cl  ; Zero extend to avoid sign issues
    add eax, ecx
    
    inc esi
    jmp parseLoop
    
parseDone:
    pop edx
    pop ecx
    pop ebx
    ret
ParseDecimal ENDP

main PROC
    ; Save original console color
    call GetTextColor
    mov originalColor, eax
    
    ; Position window to right-center of screen
     call PositionWindow

    ; Delete sync.txt at the start of the program to ensure a fresh run
    INVOKE DeleteFileA, OFFSET syncFile

    mov backspaceCount, 0
    mov charsTyped, 0

    call Clrscr
    
    ; Display menu and get test mode selection
    call DisplayMenu
    
    ; Display title with border
    mov eax, TITLE_COLOR
    call SetTextColor
    call DrawTopBorder
    
    call DrawSideBorders
    mov edx, OFFSET titleMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET dividerLine
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawBottomBorder
    call Crlf
    
    ; Reset to default color
    mov eax, DEFAULT_COLOR
    call SetTextColor

    mov eax, INSTRUCTION_COLOR
    call SetTextColor
    mov edx, OFFSET execMsg
    call WriteString
    call Crlf

    ; Save color before system call
    mov ebx, eax  ; Save current color in ebx
    
    INVOKE ShellExecuteA, 0, OFFSET operation, OFFSET pythonExe, OFFSET commandLine, 0, 1
    ; Store result in a separate register
    mov ecx, eax   ; Save shell execute result in ecx
    cmp ecx, 32    ; Compare the saved result
    jle displayExecError

    ; Restore color for success message
    mov eax, SUCCESS_COLOR
    call SetTextColor
    mov edx, OFFSET execSuccessMsg
    call WriteString
    call Crlf

    ; Delay to allow Python script to finish
    mov eax, DEFAULT_COLOR
    call SetTextColor  ; Reset color before delay
    push eax           ; Save color
    mov eax, 15000
    call Delay
    pop eax            ; Restore color
    
    ; Read time setting from file
    mov eax, DEFAULT_COLOR
    call SetTextColor
    
    mov edx, OFFSET timeFile
    call OpenInputFile
    mov timeHandle, eax
    cmp eax, -1
    je useDefaultTime  ; If can't open, use default time
    
    mov eax, timeHandle
    mov edx, OFFSET timeBuffer
    mov ecx, SIZEOF timeBuffer
    call ReadFromFile
    
    cmp eax, 0
    je useDefaultTime  ; If empty file, use default time
    
    ; Null-terminate the buffer
    mov BYTE PTR [timeBuffer + eax], 0
    
    ; Convert string to number
    mov esi, OFFSET timeBuffer
    call ParseDecimal
    
    ; If time is 0, it's the complete mode
    cmp eax, 0
    je enableNoTimeLimit
    
    ; Set the time limit
    mov timeLimit, eax
    jmp timeHandleDone
    
enableNoTimeLimit:
    mov isNoTimeLimit, 1
    jmp timeHandleDone
    
useDefaultTime:
    mov timeLimit, 60000  ; Default to 60 seconds
    
timeHandleDone:
    ; Close the time file if opened
    cmp timeHandle, -1
    je timeFileClosed
    mov eax, timeHandle
    call CloseFile
    
timeFileClosed:
    ; File operations - ensure eax is preserved
    mov eax, DEFAULT_COLOR
    call SetTextColor  ; Reset color before file operations
    
    mov edx, OFFSET wordsFile
    call OpenInputFile
    mov fileHandle, eax  ; Save file handle immediately
    cmp eax, -1          ; Compare saved handle
    je openError

    ; Now we can safely change the color
    mov eax, SUCCESS_COLOR
    call SetTextColor
    mov edx, OFFSET fileOpenMsg
    call WriteString
    call Crlf

    ; Reset color before next file operation
    mov eax, DEFAULT_COLOR
    call SetTextColor
    
    ; Use the saved file handle
    mov eax, fileHandle
    mov edx, OFFSET fileBuffer
    mov ecx, SIZEOF fileBuffer
    call ReadFromFile
    mov bytesRead, eax   ; Save read result immediately
    cmp eax, 0
    je readError

    ; Success message for file read
    mov eax, SUCCESS_COLOR
    call SetTextColor
    mov edx, OFFSET fileReadMsg
    call WriteString
    call Crlf
    
    ; Reset color before next operation
    mov eax, DEFAULT_COLOR
    call SetTextColor

    ; Use saved file handle for closing
    mov eax, fileHandle
    call CloseFile

    ; Null-terminate the buffer
    mov ebx, bytesRead
    mov BYTE PTR [fileBuffer + ebx], 0

    ; Calculate paragraph length
    mov esi, OFFSET fileBuffer
    mov ecx, 0
calcLength:
    mov al, [esi]
    cmp al, 0
    je doneLength
    inc ecx
    inc esi
    jmp calcLength
doneLength:
    mov paragraphLength, ecx

    cmp paragraphLength, 0
    je zeroLengthError
    
    ; Display paragraph header
    call DisplayParagraphHeader
    
    ; Display paragraph with fixed width
    mov eax, PARAGRAPH_COLOR
    call SetTextColor
    call DisplaySimpleParagraph
    call DrawParaBottomBorder
    call Crlf
    
    mov eax, TIME_COLOR
    call SetTextColor
    
    ; Display appropriate time limit message
    cmp isNoTimeLimit, 1
    je displayNoTimeLimit
    
    mov edx, OFFSET timeLimitMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, timeLimit
    mov ecx, 1000
    cdq
    div ecx
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET secondsForLimitMsg
    call WriteString
    jmp timeDisplayDone
    
displayNoTimeLimit:
    mov edx, OFFSET noTimeLimitMsg
    call WriteString

timeDisplayDone:
    call Crlf
    
    ; Display ESC key help message
    mov eax, INSTRUCTION_COLOR
    call SetTextColor
    mov edx, OFFSET helpMsg
    call WriteString
    call Crlf
    call Crlf

    mov eax, PROMPT_COLOR
    call SetTextColor
    mov edx, OFFSET inputPrompt
    call WriteString
    
    mov eax, INPUT_COLOR
    call SetTextColor

    ; File operations for sync file - need to preserve eax
    push eax  ; Save color
    INVOKE CreateFileA, OFFSET syncFile, 40000000h, 1, 0, 2, 80h, 0
    mov syncHandle, eax  ; Save handle immediately
    pop eax   ; Restore color
    
    cmp syncHandle, -1
    je done

    push eax  ; Save color
    INVOKE WriteFile, syncHandle, OFFSET syncContent, LENGTHOF syncContent - 1, OFFSET bytesWritten, 0
    INVOKE CloseHandle, syncHandle
    pop eax   ; Restore color

    push eax  ; Save color
    mov eax, 500
    call Delay
    pop eax   ; Restore color

    push eax  ; Save color
    call GetMSeconds
    mov startTime, eax
    pop eax   ; Restore color

    mov inputIndex, 0
readInput:
    push eax  ; Save color
    call GetMSeconds
    sub eax, startTime
    mov ecx, eax  ; Save time in ecx
    pop eax   ; Restore color
    
    ; Only check time limit if not in "complete" mode
    cmp isNoTimeLimit, 1
    je skipTimeCheck
    cmp ecx, timeLimit
    jae timeUp
skipTimeCheck:

    ; Check if the entire paragraph has been typed (for all modes)
    mov esi, OFFSET fileBuffer
    mov edi, OFFSET userInput
    mov ecx, 0
checkCompletion:
    mov bl, [esi+ecx]
    cmp bl, 0
    je paragraphCompleted
    mov dl, [edi+ecx]
    cmp dl, 0
    je notCompletedYet
    inc ecx
    jmp checkCompletion
    
paragraphCompleted:
    ; Only consider complete if user typed enough characters
    cmp ecx, paragraphLength
    jl notCompletedYet
    call Crlf
    mov eax, SUCCESS_COLOR
    call SetTextColor
    mov edx, OFFSET completeMsg
    call WriteString
    call Crlf
    jmp finishInput
    
notCompletedYet:
    push eax  ; Save color
    call ReadChar
    mov bl, al    ; Save char in bl
    pop eax   ; Restore color
    
    ; Check for ESC key
    cmp bl, ESC_KEY
    je handleEscKey
    
    cmp bl, 08h
    je handleBackspace
    cmp inputIndex, 1023
    jae bufferFull
    
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov [esi], bl  ; Use bl instead of al
    inc inputIndex
    inc charsTyped  ; Track total characters typed
    
    push eax  ; Save color
    mov al, bl    ; Move character back to al for WriteChar
    call WriteChar
    pop eax   ; Restore color
    
    jmp readInput

handleEscKey:
    call Crlf
    mov eax, INSTRUCTION_COLOR
    call SetTextColor
    mov edx, OFFSET escPressedMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp finishInput

handleBackspace:
    cmp inputIndex, 0
    je readInput
    dec inputIndex
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov BYTE PTR [esi], 0
    inc backspaceCount
    
    push eax  ; Save color
    mov al, 08h
    call WriteChar
    mov al, " "
    call WriteChar
    mov al, 08h
    call WriteChar
    pop eax   ; Restore color
    
    jmp readInput

bufferFull:
    call Crlf
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET bufferFullMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp finishInput

timeUp:
    call Crlf
    mov eax, TIME_COLOR
    call SetTextColor
    mov edx, OFFSET timeUpMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp finishInput

finishInput:
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov BYTE PTR [esi], 0
    cmp inputIndex, 0
    je noInputError

    push eax  ; Save color
    call GetMSeconds
    mov endTime, eax
    pop eax   ; Restore color

    mov eax, endTime
    sub eax, startTime
    mov elapsedTime, eax
    
    ; Display results title with border
    call Crlf
    mov eax, TITLE_COLOR
    call SetTextColor
    call DrawTopBorder
    
    call DrawSideBorders
    mov edx, OFFSET resultTitle
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawSideBorders
    mov edx, OFFSET dividerLine
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawBottomBorder
    
    mov eax, DEFAULT_COLOR
    call SetTextColor

    call DisplayResults
    call CalculateMetrics
    jmp done

displayExecError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET execFailMsg
    call WriteString
    push eax  ; Save color
    mov eax, ecx  ; Use saved result from ShellExecuteA
    call WriteDec
    pop eax   ; Restore color
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp done

openError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET openErrorMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp done

readError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET readErrorMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp done

noInputError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET noInputMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp done

zeroLengthError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET emptyParagraphMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp done

done:
    ; Restore original console color
    mov eax, originalColor
    call SetTextColor
    
    call Crlf
    mov eax, 5000
    call Delay
    INVOKE ExitProcess, 0
main ENDP

DisplayResults PROC
    mov eax, TIME_COLOR
    call SetTextColor
    call DrawTopBorder
    
    call DrawSideBorders
    mov edx, OFFSET timeMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, elapsedTime
    cdq
    mov ecx, 1000
    div ecx
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET secondsMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    call DrawBottomBorder
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    ret
DisplayResults ENDP

CalculateMetrics PROC
    push eax  ; Save color
    mov edx, OFFSET fileBuffer
    call CountWords
    mov wordCount, eax
    pop eax   ; Restore color

    mov eax, METRIC_COLOR
    call SetTextColor
    
    call DrawTopBorder
    
    ; Calculate and display gross WPM - based on total chars typed
    call DrawSideBorders
    mov edx, OFFSET grossWPMMsg
    call WriteString
    
    push eax  ; Save color
    ; Gross WPM = (chars typed / 5) / time in minutes
    mov eax, charsTyped
    mov ecx, STD_WORD_LENGTH  ; Standard word length (5 chars)
    cdq
    div ecx                   ; eax = chars typed / 5
    mov ebx, eax              ; Save word count in ebx
    
    ; Convert to per-minute rate
    mov eax, ebx
    imul eax, 60000           ; Convert to per minute (60 seconds * 1000ms)
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    mov grossWPM, eax         ; Save gross WPM result
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET wpmMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    ; Calculate and display net WPM - accounts for errors
    call DrawSideBorders
    mov edx, OFFSET netWPMMsg
    call WriteString
    
    push eax  ; Save color
    ; Reset error count first
    mov errorCount, 0
    mov correctChars, 0
    
    ; Only compare up to the length of user input
    mov ecx, inputIndex
    mov esi, OFFSET fileBuffer
    mov edi, OFFSET userInput
compareCharsForWPM:
    cmp ecx, 0
    je endCompareWPM
    mov bl, [esi]  ; Get character from reference text
    mov dl, [edi]  ; Get character from user input
    cmp bl, dl
    je correctChar
    inc errorCount ; Increment error only for incorrect characters
    jmp nextCharWPM
correctChar:
    inc correctChars
nextCharWPM:
    inc esi
    inc edi
    dec ecx
    jmp compareCharsForWPM
endCompareWPM:
    
    ; Net WPM = ((chars typed / 5) - errors/5) / time in minutes
    mov eax, charsTyped
    mov ecx, STD_WORD_LENGTH  ; Standard word length
    cdq
    div ecx                   ; eax = chars typed / 5
    
    ; Subtract error count (divide by 5)
    mov ebx, errorCount
    mov ecx, STD_WORD_LENGTH
    mov eax, ebx
    cdq
    div ecx                   ; eax = errors / 5
    mov ebx, eax              ; Error rate in words
    
    mov eax, charsTyped
    mov ecx, STD_WORD_LENGTH
    cdq
    div ecx                   ; eax = chars typed / 5
    sub eax, ebx              ; Subtract error rate
    jns notNegative           ; Check if result is negative
    mov eax, 0                ; If negative, set to 0
notNegative:
    ; Convert to per-minute rate
    imul eax, 60000           ; Convert to per minute (60 seconds * 1000ms)
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    mov netWPM, eax           ; Save net WPM result
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET wpmMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    
    ; Calculate WPM based on actual words in user input (not reference text)
    call DrawSideBorders
    mov edx, OFFSET speedMsg
    call WriteString
    
    push eax  ; Save color
    ; Count words in user input
    mov edx, OFFSET userInput
    call CountWords
    
    ; Convert to per-minute rate
    imul eax, 60000
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET wpmMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf

    ; Calculate accuracy based only on what was typed
    push eax  ; Save color
    mov eax, correctChars
    imul eax, 100
    cdq
    mov ebx, inputIndex
    cmp ebx, 0
    je handleZeroLengthError
    idiv ebx
    mov accuracy, eax
    pop eax   ; Restore color
    
    call DrawSideBorders
    mov edx, OFFSET accuracyMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, accuracy
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET percentMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf

    ; Calculate completion percentage
    push eax  ; Save color
    mov eax, inputIndex
    imul eax, 100
    cdq
    mov ebx, paragraphLength
    cmp ebx, 0
    je handleZeroLengthError
    idiv ebx
    mov completion, eax
    pop eax   ; Restore color
    
    call DrawSideBorders
    mov edx, OFFSET completionMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, completion
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET percentMsg
    call WriteString
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf

    call DrawSideBorders
    mov edx, OFFSET errorCountMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, errorCount
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf

    call DrawSideBorders
    mov edx, OFFSET backspaceMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, backspaceCount
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf

    push eax  ; Save color
    mov eax, inputIndex
    imul eax, 60000
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    mov ecx, eax  ; Save result
    pop eax   ; Restore color
    
    call DrawSideBorders
    mov edx, OFFSET cpmMsg
    call WriteString
    
    push eax  ; Save color
    mov eax, ecx  ; Restore calculation result
    call WriteDec
    pop eax   ; Restore color
    
    mov edx, OFFSET padding
    call WriteString
    mov edx, OFFSET sideBorder
    call WriteString
    call Crlf
    call DrawBottomBorder
    
    mov eax, DEFAULT_COLOR
    call SetTextColor

    ; Compare only up to the length of user input for success/failure
    mov ecx, inputIndex
    mov esi, OFFSET fileBuffer
    mov edi, OFFSET userInput
    mov ebx, 0  ; Error counter for final comparison
compareInputFinal:
    cmp ecx, 0
    je checkInputEndFinal
    mov al, [esi]
    mov dl, [edi]
    cmp al, dl
    je matchCharFinal
    inc ebx  ; Count mismatches
matchCharFinal:
    inc esi
    inc edi
    dec ecx
    jmp compareInputFinal
checkInputEndFinal:
    cmp ebx, 0
    je inputMatch
    jmp inputMismatch

inputMatch:
    mov eax, SUCCESS_COLOR
    call SetTextColor
    mov edx, OFFSET successMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp metricsDone

inputMismatch:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET errorMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp metricsDone

zeroTimeError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET zeroTimeErrorMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp metricsDone

handleZeroLengthError:
    mov eax, ERROR_COLOR
    call SetTextColor
    mov edx, OFFSET emptyParagraphMsg
    call WriteString
    call Crlf
    
    mov eax, DEFAULT_COLOR
    call SetTextColor
    jmp metricsDone

metricsDone:
    ret
CalculateMetrics ENDP

CountWords PROC
    mov eax, 0
    mov bl, 0
countLoop:
    mov cl, [edx]
    cmp cl, 0
    je endCount
    cmp cl, " "
    jne notSpace
    mov bl, 0
    jmp nextChar
notSpace:
    cmp bl, 0
    jne nextChar
    inc eax
    mov bl, 1
nextChar:
    inc edx
    jmp countLoop
endCount:
    ret
CountWords ENDP

END main