INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
INCLUDELIB shell32.lib

.386
.model flat, stdcall
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
ShellExecuteA PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD, :DWORD
Delay PROTO

.data
; File handling for dynamic paragraph
pythonExe     BYTE "cmd.exe", 0
commandLine   BYTE "/c python C:\\Users\\Shayan\\OneDrive\\Desktop\\generate_words.py", 0
operation     BYTE "open", 0
wordsFile     BYTE "C:\Users\Shayan\OneDrive\Desktop\COAL\COAL\word.txt", 0
fileBuffer    BYTE 1024 DUP(0)  ; Buffer to store paragraph from file
fileHandle    DWORD ?
bytesRead     DWORD ?

execMsg       BYTE "Executing Python script...", 0
execFailMsg   BYTE "Error: Python script execution failed. Check Python path or script.", 0
fileOpenMsg   BYTE "word.txt opened successfully.", 0
fileReadMsg   BYTE "word.txt read successfully.", 0
openErrorMsg  BYTE "Error: Failed to open word.txt.", 0
readErrorMsg  BYTE "Error: Failed to read word.txt.", 0

; Original data
prompt        BYTE "Type the following paragraph:", 0
inputPrompt   BYTE "Start typing: ", 0
timeMsg       BYTE "Time taken: ", 0
zeroTimeErrorMsg BYTE "Error: Elapsed time is zero. Typing speed cannot be calculated.", 0
secondsMsg    BYTE " seconds", 0
speedMsg      BYTE "Typing speed: ", 0
wpmMsg        BYTE " words per minute.", 0
errorMsg      BYTE "Error: Your input does not match the paragraph.", 0
successMsg    BYTE "Success: Your input matches the paragraph!", 0
accuracyMsg   BYTE "Typing accuracy: ", 0
percentMsg    BYTE " %", 0
bufferFullMsg BYTE "Error: Input buffer full!", 0
noInputMsg    BYTE "Error: No input provided!", 0
emptyParagraphMsg BYTE "Error: Paragraph is empty!", 0
errorCountMsg BYTE "Total errors: ", 0
backspaceMsg  BYTE "Backspace key presses: ", 0
cpmMsg        BYTE "Characters per minute: ", 0
timeLimit     DWORD 20000  ; 20 seconds in milliseconds
timeUpMsg     BYTE "Time's up! Input collection stopped.", 0
newline       BYTE 0Dh, 0Ah, 0
backspaceChar BYTE 08h, 0
spaceChar     BYTE ' ', 0
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

; New variables for time limit display
timeLimitMsg  BYTE "Time limit: ", 0
secondsForLimitMsg BYTE " seconds", 0

.code
main PROC
    ; Initialize backspace count
    mov backspaceCount, 0

    ; Execute Python script to generate paragraph
    mov edx, OFFSET execMsg
    call WriteString
    call Crlf

    INVOKE ShellExecuteA, 0, OFFSET operation, OFFSET pythonExe, OFFSET commandLine, 0, 1
    cmp eax, 32
    jle execError

    mov eax, 10000  ; Short delay to ensure script completes
    call Delay

    ; Open word.txt
    mov edx, OFFSET wordsFile
    call OpenInputFile
    mov fileHandle, eax
    cmp eax, -1
    je openError

    mov edx, OFFSET fileOpenMsg
    call WriteString
    call Crlf

    ; Read paragraph from word.txt
    mov edx, OFFSET fileBuffer
    mov ecx, SIZEOF fileBuffer
    call ReadFromFile
    mov bytesRead, eax
    cmp eax, 0
    je readError

    mov edx, OFFSET fileReadMsg
    call WriteString
    call Crlf

    ; Close file
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

    ; Check for empty paragraph
    cmp paragraphLength, 0
    je zeroLengthError

    ; Display the paragraph to type
    mov edx, OFFSET prompt
    call WriteString
    call Crlf
    mov edx, OFFSET fileBuffer
    call WriteString
    call Crlf
    call Crlf

    ; Display time limit to user
    mov edx, OFFSET timeLimitMsg
    call WriteString
    mov eax, timeLimit
    mov ecx, 1000
    cdq
    div ecx          ; Convert milliseconds to seconds
    call WriteDec
    mov edx, OFFSET secondsForLimitMsg
    call WriteString
    call Crlf

    ; Prompt user to start typing
    mov edx, OFFSET inputPrompt
    call WriteString

    ; Record start time
    call GetMSeconds
    mov startTime, eax

    ; Read user input with time limit
    mov inputIndex, 0
readInput:
    ; Check elapsed time
    call GetMSeconds
    sub eax, startTime
    cmp eax, timeLimit
    jae timeUp

    ; Read character
    call ReadChar
    cmp al, 08h ; Check for backspace
    je handleBackspace
    cmp inputIndex, 1023 ; Check buffer limit
    jae bufferFull
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov [esi], al
    inc inputIndex
    call WriteChar
    jmp readInput

handleBackspace:
    cmp inputIndex, 0
    je readInput ; Ignore backspace if no characters
    dec inputIndex
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov BYTE PTR [esi], 0 ; Clear the last character
    inc backspaceCount    ; Increment backspace counter
    mov al, 08h
    call WriteChar
    mov al, ' '
    call WriteChar
    mov al, 08h
    call WriteChar
    jmp readInput

bufferFull:
    mov edx, OFFSET bufferFullMsg
    call WriteString
    call Crlf
    jmp finishInput

timeUp:
    mov edx, OFFSET timeUpMsg
    call WriteString
    call Crlf
    jmp finishInput

finishInput:
    mov esi, OFFSET userInput
    add esi, inputIndex
    mov BYTE PTR [esi], 0
    cmp inputIndex, 0
    je noInputError

    ; Record end time
    call GetMSeconds
    mov endTime, eax

    ; Calculate elapsed time in milliseconds
    mov eax, endTime
    sub eax, startTime
    mov elapsedTime, eax

    ; Call procedure to display results
    call DisplayResults

    ; Call procedure to calculate and display metrics
    call CalculateMetrics

    jmp done

execError:
    mov edx, OFFSET execFailMsg
    call WriteString
    call Crlf
    jmp done

openError:
    mov edx, OFFSET openErrorMsg
    call WriteString
    call Crlf
    jmp done

readError:
    mov edx, OFFSET readErrorMsg
    call WriteString
    call Crlf
    jmp done

noInputError:
    mov edx, OFFSET noInputMsg
    call WriteString
    call Crlf
    jmp done

zeroLengthError:
    mov edx, OFFSET emptyParagraphMsg
    call WriteString
    call Crlf
    jmp done

done:
    call Crlf
    INVOKE ExitProcess, 0
main ENDP

; Procedure: DisplayResults
DisplayResults PROC
    mov edx, OFFSET timeMsg
    call WriteString
    mov eax, elapsedTime
    cdq
    mov ecx, 1000
    div ecx
    call WriteDec
    mov edx, OFFSET secondsMsg
    call WriteString
    call Crlf
    ret
DisplayResults ENDP

; Procedure: CalculateMetrics
CalculateMetrics PROC
    ; Calculate word count in the paragraph
    mov edx, OFFSET fileBuffer
    call CountWords
    mov wordCount, eax

    ; Calculate typing speed (words per minute)
    mov eax, wordCount
    imul eax, 60000
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    mov edx, OFFSET speedMsg
    call WriteString
    call WriteDec
    mov edx, OFFSET wpmMsg
    call WriteString
    call Crlf

    ; Calculate accuracy and error count
    mov correctChars, 0
    mov errorCount, 0
    mov ecx, paragraphLength
    mov esi, OFFSET fileBuffer
    mov edi, OFFSET userInput
compareChars:
    cmp ecx, 0
    je endCompare
    mov al, [esi]
    mov bl, [edi]
    cmp bl, 0
    je errorChar
    cmp al, bl
    jne errorChar
    inc correctChars
    jmp skipInc
errorChar:
    inc errorCount
skipInc:
    inc esi
    inc edi
    dec ecx
    jmp compareChars
endCompare:
    mov eax, correctChars
    imul eax, 100
    cdq
    mov ebx, paragraphLength
    cmp ebx, 0
    je zeroLengthError
    idiv ebx
    mov accuracy, eax

    ; Display accuracy
    mov edx, OFFSET accuracyMsg
    call WriteString
    mov eax, accuracy
    call WriteDec
    mov edx, OFFSET percentMsg
    call WriteString
    call Crlf

    ; Display error count
    mov edx, OFFSET errorCountMsg
    call WriteString
    mov eax, errorCount
    call WriteDec
    call Crlf

    ; Display backspace usage
    mov edx, OFFSET backspaceMsg
    call WriteString
    mov eax, backspaceCount
    call WriteDec
    call Crlf

    ; Calculate characters per minute (CPM)
    mov eax, inputIndex
    imul eax, 60000
    cdq
    cmp elapsedTime, 0
    je zeroTimeError
    idiv elapsedTime
    mov edx, OFFSET cpmMsg
    call WriteString
    call WriteDec
    call Crlf

    ; Compare user input with the paragraph
    mov esi, OFFSET fileBuffer
    mov edi, OFFSET userInput
compareInput:
    mov al, [esi]
    mov bl, [edi]
    cmp al, 0
    je checkInputEnd
    cmp bl, 0
    je inputMismatch
    cmp al, bl
    jne inputMismatch
    inc esi
    inc edi
    jmp compareInput
checkInputEnd:
    cmp bl, 0
    je inputMatch
    jmp inputMismatch

inputMatch:
    mov edx, OFFSET successMsg
    call WriteString
    call Crlf
    jmp metricsDone

inputMismatch:
    mov edx, OFFSET errorMsg
    call WriteString
    call Crlf
    jmp metricsDone

zeroTimeError:
    mov edx, OFFSET errorMsg
    call WriteString
    call Crlf
    mov edx, OFFSET zeroTimeErrorMsg
    call WriteString
    call Crlf
    jmp metricsDone

zeroLengthError:
    mov edx, OFFSET emptyParagraphMsg
    call WriteString
    call Crlf
    jmp metricsDone

metricsDone:
    ret
CalculateMetrics ENDP

; Procedure: CountWords
CountWords PROC
    mov eax, 0
    mov bl, 0
countLoop:
    mov cl, [edx]
    cmp cl, 0
    je endCount
    cmp cl, ' '
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