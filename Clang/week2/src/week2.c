#include <stdio.h>
#include <stdlib.h>

int foo(int myVar2);

int main(int argc, char *argv[]) {
	int myVar = 0;
	int myVar2 = 0;

	myVar = foo(&myVar2);

	return 0;
}


int foo(int *myVar2) {
	int myVar = 0;
	char myName[20];
	printf("Enter your name: ");
	scanf("%s", myName);
	printf("Hello %s\n", myName);
	printf("Please enter a number: ");
	scanf("%d", &myVar);
	printf("You entered: %d\n", myVar);
	return myVar;
}
