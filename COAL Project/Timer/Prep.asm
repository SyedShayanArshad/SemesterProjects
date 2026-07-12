
COMMENT &
INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
.data
.code
main PROC
mov ax,00fdffh
cwd
mov bx,100
idiv bx
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
END