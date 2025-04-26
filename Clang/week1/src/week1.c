/*
 ============================================================================
 Name        : week1.c
 Author      : 
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>  // Needed for printf and scanf functions

int main() {
    // 1. Declare an integer variable
    int number;

    // Ask the user to enter an integer
    printf("Enter an integer: ");
    // Read the integer from the user
    scanf("%d", &number);
    // Display the entered integer
    printf("You entered: %d\n\n", number);


    // 2. Declare a floating-point variable
    float value;

    // Ask the user to enter a floating-point number
    printf("Enter a floating-point number: ");
    // Read the floating-point number from the user
    scanf("%f", &value);

    // Display the floating-point number in three different formats
    printf("Scientific notation: %e\n", value);   // Scientific notation (e.g., 1.23e+03)
    printf("Fixed-point notation: %f\n", value);   // Standard decimal notation (e.g., 1230.000000)
    printf("Shortest representation: %g\n\n", value); // Shortest of %e or %f depending on the number


    // 3. Declare a character array to store a string
    char name[50];  // Can store up to 49 characters + null terminator '\0'

    // Ask the user to enter a string
    printf("Enter a string (max 49 characters): ");
    // Read the string (no '&' needed with arrays)
    scanf("%49s", name);

    // Display the entered string
    printf("You entered: %s\n\n", name);


    // 4. Declare two integer variables to find the minimum
    int num1, num2, min;

    // Ask the user to enter two integers
    printf("Enter first integer: ");
    scanf("%d", &num1);

    printf("Enter second integer: ");
    scanf("%d", &num2);

    // Use if/else to determine the minimum value
    if (num1 < num2) {
        min = num1;
    } else {
        min = num2;
    }

    // Display the minimum value
    printf("The smaller number is: %d\n", min);

    return 0;  // Indicate that the program ended successfully
}
