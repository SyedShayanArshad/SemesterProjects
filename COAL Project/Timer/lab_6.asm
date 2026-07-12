COMMENT &
.386
.model flat,stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD

.data
data word 60, 55, 45, 50, 40,85, 25, 30, 10, 2
swap byte 0
largest word 0
smallest word 0
.code
main PROC
    start:
mov ebx, 0
mov eax, 0
mov edx, 0
mov [swap], 0
loop1: mov ax, [data+bx] 
cmp ax, [data+bx+2] 
jae noswap 
mov dx, [data+bx+2] 
mov [data+bx+2], ax 
mov [data+bx], dx 
mov [swap], 1 
noswap: add bx, 2 
cmp bx, 18 
jne loop1 
cmp [swap], 1 
je start 
mov cx,[data]
mov largest,cx
mov cx,[data+18]
mov smallest,cx
INVOKE ExitProcess, 0
main ENDP
END main
&
end


