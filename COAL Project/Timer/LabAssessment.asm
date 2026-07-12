COMMENT &
INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
.data
stringIn BYTE 50 DUP (?) 
letterCount Word 0
WordString Byte 50 DUP (?)
wordCount Word 0
.code
main PROC
mov edx,OFFSET stringIn
mov ecx,50
call ReadString
mov esi,OFFSET stringIn
cmp ecx,50
je iterate
addComma:
mov al,','
call WriteChar
mov ax,letterCount
call WriteInt
mov letterCount,0
call crlf
iterate:
cmp ecx,0
je last
mov al,[esi]
call WriteChar
inc esi
mov al,[esi]
cmp al,' '
je addComma
add letterCount,1
loop iterate
last:
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
END