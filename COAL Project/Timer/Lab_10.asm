INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
COMMENT &
.data
arr DWORD 1,2,-3
.code
SignMax PROC
mov esi,eax
mov eax,[esi]
add esi,4
sub ecx,1
l1:
cmp [esi],eax
jg max
jmp cont
max:
mov eax,[esi]
cont:
add esi,4
loop l1
ret
SignMax ENDP
UnSignMax PROC
mov esi,eax
mov eax,[esi]
add esi,4
mov ecx,2
l1:
cmp [esi],eax
jae max
jmp cont
max:
mov eax,[esi]
cont:
add esi,4
loop l1
ret
UnSignMax ENDP
main PROC
mov eax,offset arr
mov ecx, LENGTHOF arr
call UnSignMax
call WriteInt
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
end