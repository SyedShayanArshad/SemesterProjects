COMMENT &
INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
.data
stringIn BYTE 9 DUP (?) ;room for null
.code
main PROC
.code
mov edx,OFFSET stringIn
mov ecx,15
call ReadString
call WriteString
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
end