INCLUDE C:\Irvine\Irvine32.inc
INCLUDELIB C:\Irvine\Irvine32.lib
.386
.model flat, stdcall
.stack 4096
ExitProcess PROTO, dwExitCode:DWORD
DumpRegs PROTO 
;QUESTION 1
COMMENT &
.data
 prompt byte "Enter a string to reverse: ",0
 prompt2 byte "The reversed string is: ",0
 input byte 50 dup(?)
 reversedString byte 50 dup(?),0
.code
reversed PROC
    push ebp
	mov ebp,esp
	mov esi, [ebp+8]
	mov edi,[ebp+12]
	mov ecx,[ebp+16]
	reverse:
	    mov al,[esi+ecx-1]
		mov [edi],al
		inc edi
	loop reverse
	pop ebp
	ret 12
	reversed ENDP
main PROC
	mov edx,offset prompt
	call WriteString
	mov edx,offset input
	mov ecx,50
	call ReadString
	push eax
	push offset reversedString
	push offset input
	call reversed
	mov edx,offset prompt2
	call WriteString
	mov esi,offset reversedString
	mov ecx,eax
	displayReverse:
	 mov al,[esi]
		call WriteChar
		inc esi
	loop displayReverse
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
;QUESTION 2
COMMENT &
.data
prompt byte "The Size of Array is 5",0
prompt1 byte "Enter Value: ",0
result byte "The Maximum Value is: ",0
array dd 5 dup(?)
.code
findMax PROC
	push ebp
	mov ebp,esp
	mov esi,[ebp+8]
	mov ecx,[ebp+12]
	mov eax,[esi]
	add esi,4
	dec ecx
	check:
		cmp [esi],eax
		jle next
		mov eax,[esi]
		next:
		add esi,4
		loop check
	mov edx,offset result
	call WriteString
	call WriteInt
	pop ebp
	ret 8
	findMax ENDP
main PROC
mov edx,offset prompt
call WriteString
call crlf
mov esi,offset array
mov ecx,5
mov edx,offset prompt1
l1:
call WriteString
call ReadInt
mov [esi],eax
add esi,4
loop l1
mov ebx,offset array
mov eax,5
push eax
push ebx
call findMax
exit 
INVOKE ExitProcess,0
main ENDP
END main
&
;QUESTION 4
COMMENT &
.data
p1 byte "Enter A: ",0
p2 byte "Enter B: ",0
p3 byte "After Swapping A is : ",0
p4 byte "After Swapping B is : ",0
a dd ?
b dd ?
.code
swap PROC
	push ebp
	mov ebp,esp
	mov eax,[ebp+8]
	mov ebx,[ebp+12]
	mov ecx, [eax] 
    mov edx, [ebx]   
    xor ecx, edx       
    xor edx, ecx       
    xor ecx, edx       
    mov [eax], ecx 
    mov [ebx], edx
	pop ebp
	ret 8
	swap ENDP
main PROC
	mov edx,offset p1
	call WriteString
	call ReadInt
	mov a,eax
	mov edx,offset p2
	call WriteString
	call ReadInt
	mov b,eax
	push offset b
	push offset a
	call swap
	mov edx,offset p3
	call WriteString
	mov eax,a
	call WriteInt
	call crlf
	mov edx,offset p4
	call WriteString
	mov eax,b
	call WriteInt
	exit
	INVOKE ExitProcess,0
	main ENDP
	END main
&
;QUESTION 5
COMMENT &
.data
p1 byte "Enter First Integer: ",0
p2 byte "Enter Second Integer: ",0
p3 byte "Enter Operator: ",0
p4 byte "Result is: ",0
a dd ?
b dd ?
op byte ?
result dd ?
.code
addition PROC
    push ebp
    mov ebp,esp
    mov eax,[ebp+8]    
    mov ebx,[ebp+12]
    add eax,ebx
    pop ebp
    ret 8
addition ENDP
subtraction PROC
    push ebp
    mov ebp,esp
    mov eax,[ebp+8]    
    mov ebx,[ebp+12]     
    sub eax,ebx
    pop ebp
    ret 8
subtraction ENDP
multiplication PROC
    push ebp
    mov ebp,esp
    mov eax,[ebp+8]    
    mov ebx,[ebp+12]     
    mul ebx
    pop ebp
    ret 8
multiplication ENDP
division PROC
    push ebp
    mov ebp,esp
    mov eax,[ebp+8]    
    mov ebx,[ebp+12]     
    mov edx,0
    div ebx            
    pop ebp
    ret 8
division ENDP
main PROC
    mov edx,offset p1
    call WriteString
    call ReadInt
    mov a,eax
	mov edx,offset p2
    call WriteString
    call ReadInt
    mov b,eax
    mov edx,offset p3
    call WriteString
    call ReadChar
	call WriteChar
    mov op,al
	call ReadChar
    call Crlf
    push b
    push a
	mov al,op
    cmp al,'+'
    je sum
    cmp al,'-'
    je subtract
    cmp al,'*'
    je multiply
    cmp al,'/'
    je divide
    jmp display 
sum:
    call addition
    mov result,eax
    jmp display
subtract:
    call subtraction
    mov result,eax
    jmp display
multiply:
    call multiplication
    mov result,eax
    jmp display
divide:
    call division
    mov result,eax
    jmp display
display:
    mov edx,offset p4
    call WriteString
    mov eax,result
    call WriteInt
    call Crlf
    invoke ExitProcess,0
main ENDP
END main
&
;QUESTION 6
COMMENT &
.data
p1 byte "Enter a string: ",0
p byte "The string is palindrome",0
np byte "The string is not palindrome",0
input byte 50 dup(?)
siz dd ?
.code
isPalindrome PROC, value:PTR BYTE, s:DWORD
	LOCAL reversedString[51]:BYTE
	mov ecx, s
    mov esi, value          
    lea edi, reversedString
    add edi, ecx           
    dec edi                
    copyReverse:
        mov al, [esi]
        mov [edi], al
        inc esi
        dec edi
    loop copyReverse
	mov ecx, s
    mov esi, value
    lea edi, reversedString
	compare:
		mov al,[esi]
		mov bl,[edi]
		cmp al,bl
		jne notPalindrome
		inc esi
		inc edi
	loop compare
	mov eax, 1
    jmp done
    notPalindrome:
    mov eax, 0
    done:
	ret
isPalindrome ENDP
main PROC
    mov edx,offset p1
	call WriteString
	mov ecx,50
	mov edx,offset input
	call ReadString
	mov siz,eax
	INVOKE isPalindrome,ADDR input, siz
	cmp eax,1
	je palindrome
	mov edx,offset np
	call WriteString
	jmp done
	palindrome:
	mov edx,offset p
	call WriteString
	done:
	INVOKE ExitProcess,0
	main ENDP
	END main
&
;QUESTION 7
COMMENT &
.data
N EQU 3                    
prompt1 byte "Enter elements of Matrix A:", 0
prompt2 byte "Enter elements of Matrix B:", 0
resultPrompt byte "The resulting Matrix C is:", 0
space byte " ", 0          
matrixA dd N*N dup(?)      
matrixB dd N*N dup(?)      
matrixC dd N*N dup(?)   
.code
MatrixAdd PROC, matA:PTR DWORD, matB:PTR DWORD, matC:PTR DWORD, siz:DWORD
    mov ecx, siz           
    mov esi, matA          
    mov edi, matB          
    mov ebx, matC          
    xor edx, edx           
    addLoop:
        mov eax, [esi + edx*4]    
        add eax, [edi + edx*4]    
        mov [ebx + edx*4], eax    
        inc edx                   
    loop addLoop              
    ret
MatrixAdd ENDP
main PROC
    mov edx, OFFSET prompt1
    call WriteString
    call Crlf
    mov esi, OFFSET matrixA
    mov ecx, N*N           
    readMatrixA:
        call ReadInt
        mov [esi], eax
        add esi, 4
        loop readMatrixA
    mov edx, OFFSET prompt2
    call WriteString
    call Crlf
    mov esi, OFFSET matrixB
    mov ecx, N*N      
    readMatrixB:
        call ReadInt
        mov [esi], eax
        add esi, 4
        loop readMatrixB
    INVOKE MatrixAdd, OFFSET matrixA, OFFSET matrixB, OFFSET matrixC, N*N
    mov edx, OFFSET resultPrompt
    call WriteString
    call Crlf
    mov esi, OFFSET matrixC
    mov ecx, N*N          
    mov ebx, N            
    displayMatrixC:
        mov eax, [esi]
        call WriteInt     
        mov edx, OFFSET space
        call WriteString   
        add esi, 4
        dec ebx
        jnz skipNewline    
        call Crlf          
        mov ebx, N         
    skipNewline:
        loop displayMatrixC
    INVOKE ExitProcess, 0
main ENDP
END main
&
;QUESTION 8
Comment &
.data
N EQU 5
prompt byte "Enter Array Elements: ", 0
result byte "Sorted array: ", 0
space byte " ", 0
array dd N dup(?)
.code
BubbleSort PROC, arr:PTR DWORD, siz:DWORD
    LOCAL swapped:BYTE
    mov ecx, siz
    dec ecx
outerLoop:
    mov swapped, 0
    mov esi, arr
    mov edx, ecx
innerLoop:
    mov eax, [esi]
    cmp eax, [esi + 4]
    jle noSwap
    mov ebx, [esi + 4]
    mov [esi], ebx
    mov [esi + 4], eax
    mov swapped, 1
noSwap:
    add esi, 4
    dec edx
    jnz innerLoop
    cmp swapped, 0
    je done
    loop outerLoop
done:
    ret
BubbleSort ENDP
main PROC
    mov esi, OFFSET array
    mov ecx, N
inputLoop:
    mov edx, OFFSET prompt
    call WriteString
    call ReadInt
    mov [esi], eax
    add esi, 4
    loop inputLoop
    INVOKE BubbleSort, OFFSET array, N
    mov edx, OFFSET result
    call WriteString
    mov esi, OFFSET array
    mov ecx, N
displayLoop:
    mov eax, [esi]
    call WriteInt
    mov edx, OFFSET space
    call WriteString
    add esi, 4
    loop displayLoop
    call Crlf
    INVOKE ExitProcess, 0
main ENDP
END main
&
;QUESTION 10
COMMENT &
.data
promptChoice byte "Enter 1 for C to F, 2 for F to C: ", 0
promptTemp byte "Enter temperature: ", 0
resultCtoF byte "Temperature in Fahrenheit: ", 0
resultFtoC byte "Temperature in Celsius: ", 0
invalid byte "Invalid choice!", 0
space byte " ", 0
.code
CelsiusToFahrenheit PROC, temp:DWORD
    LOCAL result:DWORD
    mov eax, temp
    mov ebx, 9
    mul ebx
    mov ebx, 5
    div ebx
    add eax, 32
    mov result, eax
    mov edx, OFFSET resultCtoF
    call WriteString
    mov eax, result
    call WriteInt
    call Crlf
    ret
CelsiusToFahrenheit ENDP
FahrenheitToCelsius PROC, temp:DWORD
    LOCAL result:DWORD
    mov eax, temp
    sub eax, 32
    mov ebx, 5
    mul ebx
    mov ebx, 9
    div ebx
    mov result, eax
    mov edx, OFFSET resultFtoC
    call WriteString
    mov eax, result
    call WriteInt
    call Crlf
    ret
FahrenheitToCelsius ENDP
main PROC
    mov edx, OFFSET promptChoice
    call WriteString
    call ReadInt
    cmp eax, 1
    je celsius
    cmp eax, 2
    je fahrenheit
    jmp wrong
celsius:
    mov edx, OFFSET promptTemp
    call WriteString
    call ReadInt
    INVOKE CelsiusToFahrenheit, eax
    jmp done
fahrenheit:
    mov edx, OFFSET promptTemp
    call WriteString
    call ReadInt
    INVOKE FahrenheitToCelsius, eax
    jmp done
wrong:
    mov edx, OFFSET invalid
    call WriteString
    call Crlf
done:
    INVOKE ExitProcess, 0
main ENDP
END main
&
end