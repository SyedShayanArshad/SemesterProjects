COMMENT #
.386
.model flat,stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
.data
.code
main PROC
 MOV AL, 0F0H
 MOV BL, 10H
 ADD AL,BL
 INVOKE ExitProcess, 0
main ENDP
END main
.data
    a DWORD 10
    b DWORD 20
    result DWORD 0
.code
main PROC
    MOV EAX, [a]  
    MOV EBX, [b]      
    ADD EAX, EBX      
    MOV [result], EAX 
    INVOKE ExitProcess, 0
main ENDP
END main
#
END