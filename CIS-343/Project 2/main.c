#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <ctype.h>
#include "matrix.h"

void menu();
void load(Matrix *m);
void print(Matrix *m);

int main()
{
	Matrix *matA = NULL, *matB = NULL, *matC = NULL;
	char choice, which;
	int rows, cols, k;

	while (true) {
		menu();
		scanf("%c",&choice);
		getchar(); // ignore newline character
		choice = toupper(choice);

		if (choice == 'Q') {
			break;
		}

		switch (choice) {
			case 'C':	// create the matrices to work with
				do {
					printf("Enter number of rows and columns for Matrix A: ");
					scanf("%d%d", &rows, &cols);
					getchar();	// ignore newline character
					if (rows <= 0 || cols <= 0) {
						printf("Invalid dimensions. Try again...\n");
					}
				} while (rows <= 0 || cols <= 0);
				matA = create(rows,cols);
				load(matA);
				do {
					printf("Enter number of rows and columns for Matrix B: ");
					scanf("%d%d", &rows, &cols);
					getchar();	// ignore newline character
					if (rows <= 0 || cols <= 0) {
						printf("Invalid dimensions. Try again...\n");
					}
				} while (rows <= 0 || cols <= 0);
				matB = create(rows,cols);
				load(matB);
				break;
			case 'P':	// print the matrices
				if (matA == NULL || matB == NULL) {
					break;
				}
				printf("Matrix A:\n");
				print(matA);
				printf("Matrix B:\n");
				print(matB);
				break;
			case 'A':	// add matrices
				if (matA == NULL || matB == NULL) {
					break;
				}
				if (matA->rows == matB->rows && matA->columns == matB->columns) {
					matC = add(matA, matB);
					print(matC);
				} else {
					printf("Add failed: Matrix A and B do not have same size.\n");
				}
				break;
			case 'S':	// subtract matrices
				if (matA == NULL || matB == NULL) {
					break;
				}
				if (matA->rows == matB->rows && matA->columns == matB->columns) {
					matC = subtract(matA, matB);
					print(matC);
				} else {
					printf("Subtract failed: Matrix A and B do not have same size.\n");
				}
				break;
			case 'T':	// transpose a matrix
				if (matA == NULL || matB == NULL) {
					break;
				}
				printf("Transpose matrix A or B? (enter A or B): ");
				scanf("%c", &which);
				getchar();	// ignore newline character
				which = toupper(which);
				if (which == 'A') {
					matC = transpose(matA);
					print(matC);
				} else if (which == 'B') {
					matC = transpose(matB);
					print(matC);
				} else {
					printf("Invalid input.\n");
				}
				break;
			case 'K':	// multiply one of the matrices with a scalar value
				if (matA == NULL || matB == NULL) {
					break;
				}
				printf("Enter scalar value for k: ");
				scanf("%d", &k);
				getchar();	// ignore newline character
				printf("Scalar multiply matrix A or B? (enter A or B): ");
				scanf("%c", &which);
				which = toupper(which);
				getchar();	// ignore newline character
				if (which == 'A') {
					matC = scalarMultiply(matA, k);
					print(matC);
				} else if (which == 'B') {
					matC = scalarMultiply(matB, k);
					print(matC);
				} else {
					printf("Invalid input.\n");
				}
				break;
			case 'M':	// multiply the matrices
				if (matA == NULL || matB == NULL) {
					break;
				}
				if (matA->columns == matB->rows) {
					matC = multiply(matA, matB);
					print(matC);
				} else {
					printf("Multiply failed: Number of columns in Matrix A must be same as the number of rows in Matrix B.\n");
				}
				break;
		}	// end of switch
	}	// end of while

	printf("Bye.\n");
	return EXIT_SUCCESS;
}

void menu()
{
	printf("****** Matrix Operations Menu ******\n");
	printf("C: Create Matrices A and B\n");
	printf("P: Print Matrices A and B\n");
	printf("A: Add [A + B]\n");
	printf("S: Subtract [A - B]\n");
	printf("T: Transpose [A' OR B']\n");
	printf("K: Scalar Multiply [k * A OR k * B]\n");
	printf("M: Multiply [A * B]\n");
	printf("Q: Quit\n");
	printf("Enter your selection (C,P,A,S,T,K,M,Q): ");
}

/****************************************************************************
 *	If rows and column of matrix is valid (>0) then read matrix data and	*
 *	set the "data" array with these values. Use "setValueAt" function to	*
 *	set the values of the matrix. If dimensions are not valid, do nothing.	*
 ***************************************************************************/
void load(Matrix *m)
{
	int value;
	if (m->rows <= 0 || m->columns <= 0 || m->data == NULL) {
		return;
	}

	for (int i = 1; i <= m->rows; i++) {
		printf("Enter %d integer values for row %d: ", m->columns, i);
		for (int j = 1; j <= m->columns; j++) {
			scanf("%d", &value);
			setValueAt(m,i-1,j-1,value);
		}
	}
	getchar(); // ignore newline character
}

/****************************************************************************
 * Print the values of matrix in a table form. You must use "getValueAt"	*
 * function to retrieve matrix elements.									*
 ***************************************************************************/
void print(Matrix *m)
{
	for (int i = 0; i < m->rows; i++) {
		for (int j = 0; j < m->columns; j++) {
			printf("%d ", getValueAt(m,i,j));
		}
		printf("\n");
	}
}
