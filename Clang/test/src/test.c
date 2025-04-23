/*
 ============================================================================
 Name        : test.c
 Author      : 
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>

int main(void) {
	int myVar = 0;
	printf("Enter a number: ");
	scanf("%d", &myVar);
	char myName[20];
	printf("Enter your name: ");
	scanf("%s", myName);
	printf("Hello %s\n", myName);

	printf("You entered: %d\n", myVar);

	printf("Hello World.");
	return EXIT_SUCCESS;
}
