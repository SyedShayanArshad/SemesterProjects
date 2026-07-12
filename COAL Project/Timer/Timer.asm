INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
INCLUDELIB user32.lib
INCLUDELIB kernel32.lib

; Type definitions
BOOL TYPEDEF DWORD
TRUE EQU 1
FALSE EQU 0

; Structure definitions for Windows API
COORD STRUCT
  X WORD ?
  Y WORD ?
COORD ENDS

SMALL_RECT STRUCT
  Left   WORD ?
  Top    WORD ?
  Right  WORD ?
  Bottom WORD ?
SMALL_RECT ENDS

; API Prototypes
SetConsoleScreenBufferSize PROTO :DWORD, :COORD
SetConsoleWindowInfo PROTO :DWORD, :BOOL, :PTR SMALL_RECT
ExitProcess PROTO :DWORD
GetFileAttributesA PROTO :DWORD
SetWindowPos PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD
Beep PROTO, dwFreq:DWORD, dwDuration:DWORD
GetConsoleWindow PROTO

.data
startSeconds DWORD ?                       ; Will be set from time_setting.txt
secondsLeft  DWORD ?
timeBuffer   BYTE 16 DUP(0)                ; Buffer for reading time setting
timeFile     BYTE "C:\Users\Shayan\OneDrive\Desktop\COAL\COAL\time_setting.txt", 0
syncFile     BYTE "C:\Users\Shayan\OneDrive\Desktop\COAL\COAL\sync.txt", 0
msg1         BYTE "Time left: ", 0
msg2         BYTE " seconds", 0
timeUpMsg    BYTE "Time's up!", 0
waitingMsg   BYTE "Waiting for typing to start...", 0
syncFoundMsg BYTE "Sync file found! Starting timer...", 0
noTimeLimitMsg BYTE "No time limit mode: Waiting for typing to complete...", 0
completedMsg BYTE "Typing test completed!", 0
fileOpenErrorMsg BYTE "Error: Could not open time_setting.txt.", 0
fileReadErrorMsg BYTE "Error: Could not read time_setting.txt.", 0
fileParseErrorMsg BYTE "Error: Invalid time value in time_setting.txt.", 0
defaultTimeMsg BYTE "Using default 60 seconds.", 0
timeZeroDetectedMsg BYTE "Detected time value of 0 - No time limit mode", 0
bytesRead    DWORD ?
fileHandle   DWORD ?

; Flag to track if we're in no time limit mode
noTimeLimitFlag BYTE 0    ; 0 = timed mode, 1 = no time limit

; Simple border characters
topLeft      BYTE '+'
topRight     BYTE '+'
bottomLeft   BYTE '+'
bottomRight  BYTE '+'
horizontal   BYTE '-'
vertical     BYTE '|'

STD_OUTPUT_HANDLE EQU -11
INVALID_HANDLE_VALUE EQU -1
consoleHandle DWORD ?
consoleWindow SMALL_RECT <0, 0, 39, 6>
consoleSize   COORD <>

; Window position constants
HWND_TOP    EQU 0
SWP_NOSIZE  EQU 1h
SWP_NOZORDER EQU 4h

; Color constants
BLUE_ON_WHITE  = 1Fh
RED_ON_WHITE   = 4Fh
GREEN_ON_WHITE = 2Fh
YELLOW_ON_WHITE = 6Fh

.code
; Procedure to parse a decimal string in ESI to a number in EAX
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
    jb parseInvalid
    cmp cl, '9'
    ja parseInvalid
    
    sub cl, '0'
    mov edx, 0
    mul ebx
    movzx ecx, cl
    add eax, ecx
    
    inc esi
    jmp parseLoop
    
parseInvalid:
    mov eax, 0
parseDone:
    pop edx
    pop ecx
    pop ebx
    ret
ParseDecimal ENDP

DrawBorder PROC
    mov dh, 0
    mov dl, 0
    call Gotoxy
    mov al, topLeft
    call WriteChar
    mov ecx, 38
    mov al, horizontal
L1:
    call WriteChar
    loop L1
    mov al, topRight
    call WriteChar

    mov ecx, 5
    mov dh, 1
L2:
    mov dl, 0
    call Gotoxy
    mov al, vertical
    call WriteChar
    mov dl, 39
    call Gotoxy
    call WriteChar
    inc dh
    loop L2

    mov dh, 6
    mov dl, 0
    call Gotoxy
    mov al, bottomLeft
    call WriteChar
    mov ecx, 38
    mov al, horizontal
L3:
    call WriteChar
    loop L3
    mov al, bottomRight
    call WriteChar
    ret
DrawBorder ENDP

FileExists PROC
    push edx
    INVOKE GetFileAttributesA, edx
    cmp eax, -1
    je fileDoesntExist
    mov eax, 1
    jmp fileExistsDone
fileDoesntExist:
    mov eax, 0
fileExistsDone:
    pop edx
    ret
FileExists ENDP

PositionWindow PROC
    INVOKE GetConsoleWindow
    INVOKE SetWindowPos, eax, HWND_TOP, 0, 0, 0, 0, SWP_NOSIZE + SWP_NOZORDER
    ret
PositionWindow ENDP

ReadTimeFromFile PROC
    mov ecx, SIZEOF timeBuffer
    mov edi, OFFSET timeBuffer
    mov al, 0
    rep stosb
    
    mov edx, OFFSET timeFile
    call OpenInputFile
    cmp eax, INVALID_HANDLE_VALUE
    je openErrorRTF
    
    mov fileHandle, eax
    mov edx, OFFSET timeBuffer
    mov ecx, SIZEOF timeBuffer - 1
    call ReadFromFile
    jc readErrorRTF
    
    mov bytesRead, eax
    mov edi, OFFSET timeBuffer
    add edi, eax
    mov BYTE PTR [edi], 0
    
    mov eax, fileHandle
    call CloseFile
    
    mov esi, OFFSET timeBuffer
    call ParseDecimal
    mov ecx, eax
    
    cmp ecx, 0
    jne normalTimeValue
    
    mov noTimeLimitFlag, 1
    mov eax, 0
    clc
    ret
    
normalTimeValue:
    cmp ecx, 3600000
    ja parseErrorRTF
    
    mov eax, ecx
    mov ebx, 1000
    cdq
    div ebx
    clc
    ret
    
openErrorRTF:
    mov eax, 60
    stc
    ret

readErrorRTF:
    mov eax, fileHandle
    call CloseFile
    mov eax, 60
    stc
    ret
    
parseErrorRTF:
    mov eax, 60
    stc
    ret
ReadTimeFromFile ENDP

main PROC
    ; Get handle to console
    INVOKE GetStdHandle, STD_OUTPUT_HANDLE
    mov consoleHandle, eax

    ; Set console size
    mov consoleSize.X, 40
    mov consoleSize.Y, 7
    INVOKE SetConsoleScreenBufferSize, consoleHandle, consoleSize
    INVOKE SetConsoleWindowInfo, consoleHandle, TRUE, ADDR consoleWindow

    ; Position window in top-left corner
    call PositionWindow

    ; Draw initial border and countdown display
    call DrawBorder
    mov eax, BLUE_ON_WHITE
    call SetTextColor
    mov dh, 2
    mov dl, 10
    call Gotoxy
    mov edx, OFFSET msg1
    call WriteString

    ; Display waiting message
    mov dh, 3
    mov dl, 5
    call Gotoxy
    mov edx, OFFSET waitingMsg
    call WriteString

waitForSync:
    mov edx, OFFSET syncFile
    call FileExists
    cmp eax, 1
    je syncFound
    
    mov eax, 50
    call Delay
    jmp waitForSync

syncFound:
    ; Update display with sync found message
    mov eax, GREEN_ON_WHITE
    call SetTextColor
    mov dh, 3
    mov dl, 5
    call Gotoxy
    mov edx, OFFSET syncFoundMsg
    call WriteString
    mov eax, 500
    call Delay

    ; Read time after sync is found to get fresh time_setting.txt
    call ReadTimeFromFile
    jnc timeReadOK
    mov eax, 60
    mov dh, 4
    mov dl, 5
    call Gotoxy
    mov edx, OFFSET defaultTimeMsg
    call WriteString
timeReadOK:
    mov startSeconds, eax

    ; Check no time limit mode
    cmp noTimeLimitFlag, 1
    je noTimeLimitMode
    
    ; Ensure minimum 5 seconds for timed mode
    cmp startSeconds, 5
    jge startTimedMode
    mov startSeconds, 5

startTimedMode:
    ; Set seconds and start countdown
    mov eax, startSeconds
    mov secondsLeft, eax

countdownLoop:
    ; Clear previous seconds display with spaces
    mov eax, BLUE_ON_WHITE
    call SetTextColor
    mov dh, 2
    mov dl, 21
    call Gotoxy
    mov al, ' '
    call WriteChar
    call WriteChar
    call WriteChar

    ; Move back to start position and display new seconds
    mov dl, 21
    call Gotoxy
    mov eax, secondsLeft
    call WriteDec

    ; Display "seconds" text with extra spacing
    mov dl, 25
    call Gotoxy
    mov edx, OFFSET msg2
    call WriteString

    ; Change color based on time
    cmp secondsLeft, 5
    jg normalColor
    mov eax, RED_ON_WHITE
    call SetTextColor
    jmp afterColorSet
normalColor:
    cmp secondsLeft, 10
    jg blueColor
    mov eax, YELLOW_ON_WHITE
    call SetTextColor
    jmp afterColorSet
blueColor:
    mov eax, BLUE_ON_WHITE
    call SetTextColor
afterColorSet:

    ; Check if sync file exists
    mov edx, OFFSET syncFile
    call FileExists
    cmp eax, 0
    je testCompleted

    mov eax, 1000
    call Delay
    dec secondsLeft
    cmp secondsLeft, 0
    jg countdownLoop

timeUp:
    mov eax, RED_ON_WHITE
    call SetTextColor
    mov dh, 4
    mov dl, 15
    call Gotoxy
    mov edx, OFFSET timeUpMsg
    call WriteString
    INVOKE Beep, 800, 800
    jmp exitProgram

noTimeLimitMode:
    mov eax, BLUE_ON_WHITE
    call SetTextColor
    mov dh, 2
    mov dl, 3
    call Gotoxy
    mov edx, OFFSET noTimeLimitMsg
    call WriteString

waitForCompletion:
    mov edx, OFFSET syncFile
    call FileExists
    cmp eax, 0
    je testCompleted
    mov eax, 50
    call Delay
    jmp waitForCompletion

testCompleted:
    mov eax, GREEN_ON_WHITE
    call SetTextColor
    mov dh, 4
    mov dl, 10
    call Gotoxy
    mov edx, OFFSET completedMsg
    call WriteString

exitProgram:
    mov eax, 1500
    call Delay
    mov eax, 7
    call SetTextColor
    exit
main ENDP
END main