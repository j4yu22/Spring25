#include <stdio.h>

// Function prototype
int minimum(int a, int b);


int main() {
    int choice;
    int keepGoing = 1;

    // Item selection loop with switch
    while (keepGoing) {
        printf("\nStore Menu:\n");
        printf("1. Apple - $0.99\n");
        printf("2. Banana - $0.79\n");
        printf("3. Milk - $2.49\n");
        printf("4. Bread - $1.99\n");
        printf("5. Eggs - $3.50\n");
        printf("6. Exit\n");
        printf("Select an item (1–5) or 6 to exit: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                printf("Apple costs $0.99\n");
                break;
            case 2:
                printf("Banana costs $0.79\n");
                break;
            case 3:
                printf("Milk costs $2.49\n");
                break;
            case 4:
                printf("Bread costs $1.99\n");
                break;
            case 5:
                printf("Eggs cost $3.50\n");
                break;
            case 6:
                keepGoing = 0;
                break;
            default:
                printf("Invalid selection.\n");
                break;
        }
    }

    // Loop counting up from 1 to 10
    printf("\nCounting up from 1 to 10:\n");
    for (int i = 1; i <= 10; i++) {
        printf("%d ", i);
    }
    printf("\n");

    // Loop counting down from 10 to 1
    printf("Counting down from 10 to 1:\n");
    for (int i = 10; i >= 1; i--) {
        printf("%d ", i);
    }
    printf("\n");

    // Array of 10 floats
    float numbers[10];
    printf("\nEnter 10 floating point numbers:\n");
    for (int i = 0; i < 10; i++) {
        printf("Number %d: ", i + 1);
        scanf("%f", &numbers[i]);
    }

    // Display numbers and calculate min, max, average
    float min = numbers[0];
    float max = numbers[0];
    float sum = 0;

    printf("\nNumbers entered:\n");
    for (int i = 0; i < 10; i++) {
        printf("%.2f ", numbers[i]);
        if (numbers[i] < min) min = numbers[i];
        if (numbers[i] > max) max = numbers[i];
        sum += numbers[i];
    }
    printf("\nMinimum: %.2f\n", min);
    printf("Maximum: %.2f\n", max);
    printf("Average: %.2f\n", sum / 10);

    // Minimum function with user input
    int num1, num2;
    printf("\nEnter two integers to compare: ");
    scanf("%d %d", &num1, &num2);
    int result = minimum(num1, num2);
    printf("The minimum of %d and %d is %d\n", num1, num2, result);

    return 0;
}


/*
 * Returns the smaller of two integers.
 *
 * Parameters:
 *     a (int): first number
 *     b (int): second number
 *
 * Returns:
 *     int: the minimum value between a and b
 */
int minimum(int a, int b) {
    return (a < b) ? a : b;
}
