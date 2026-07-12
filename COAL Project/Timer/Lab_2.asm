COMMENT &
.386
.model flat,stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD

.data
.code
main PROC
   mov ax, 0F2B7h
   mov bx, 08D3Ah

   add ax, bx

   add ax, 017Eh
   mov cx, 01AC9h
   add ax, cx

    INVOKE ExitProcess, 0
main ENDP
END main
&
END


