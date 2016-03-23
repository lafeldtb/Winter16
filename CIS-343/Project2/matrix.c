/* Authors: Ben LaFeldt and Mattie Phillips */

#include <stdlib.h>
#include <limits.h>
#include "matrix.h"

/****************************************************************************
 * Creates and returns a pointer to a matrix object with the specified		*
 * number of rows and columns. The "data" field is set to a dynamically 	*
 * created array of ints of size rows * columns.							*
 *																			*
 * If the value of rows or columns is zero or negative, return NULL.		*
 ***************************************************************************/
Matrix *create(int rows, int columns)
{
		Matrix *result = NULL;
		result = calloc(sizeof(Matrix), sizeof(int));
		result->rows = rows;
		result->columns = columns;
		result->data = 	calloc(sizeof(rows * columns), sizeof(int));
		return result;
}

/****************************************************************************
 * Returns the matrix element at (row,column). Return INT_MIN (limits.h)	*
 * if either row and/or column is invalid. Row and column values start at 	*
 * zero. DO NOT modify the input matrix.									*
 ***************************************************************************/
int getValueAt(Matrix *m, int row, int column)
{
	if(row >= (m->rows) || row < 0 || column >= m->columns || column < 0)
		return INT_MIN;
	else
	{
		return m->data[row*(m->columns) + column ];
	}
	
}

/****************************************************************************
 * If the row and column values are valid, sets the matrix element at 		*
 * (row,column) with the parameter value. Row and column values start at	*
 * zero.																	*
 ***************************************************************************/
void setValueAt(Matrix *m, int row, int column, int value)
{
	if(!(row >= m->rows || row < 0 || column >= m->columns || column < 0))
	{
		m->data[row*(m->columns) + column] = value;
	}
}

/****************************************************************************
 * If the input matrices are compatible, then performs matrix addition and	*
 * returns a pointer to the result matrix.									*
 * Use create(), getValueAt(), and setValueAt() functions to implement this	*
 * function. If the input matrices are not compatible, return NULL.			*
 * DO NOT modify the input matrices.										*
 ***************************************************************************/
Matrix *add(Matrix *m1, Matrix *m2)
{
	Matrix *result = NULL;
	
	// TO DO
	if(m1->rows == m2->rows && m1->columns == m2->columns)
	{
		result = create(m1->rows, m1->columns);
		for(int row = 0; row < m1->rows; row++)
		{
			for(int col = 0; col < m1->columns; col++)
			{
				setValueAt(result, row, col, (getValueAt(m1, row,col) +
					 getValueAt(m2,row,col)));
				
			}
		}
	}

	return result;
}

/****************************************************************************
 * If the input matrices are compatible, then performs matrix subtraction	*
 * and returns a pointer to the result matrix.								*
 * Use create(), getValueAt(), and setValueAt() functions to implement this	*
 * function. If the input matrices are not compatible, return NULL.			*
 * DO NOT modify the input matrices.										*
 ***************************************************************************/
Matrix *subtract(Matrix *m1, Matrix *m2)
{
	Matrix *result = NULL;
	
	// TO DO
	if(m1->rows == m2->rows && m1->columns == m2->columns)
	{
		result = create(m1->rows, m1->columns);
		for(int row = 0; row < m1->rows; row++)
		{
			for(int col = 0; col < m1->columns; col++)
			{
				setValueAt(result, row, col, (getValueAt(m1, row,col) -
					 getValueAt(m2,row,col)));
				
			}
		}
	}

	return result;
}

/****************************************************************************
 * Creates the transpose matrix of the input matrix and returns a pointer	*
 * to the result matrix. Use create(), getValueAt(), and setValueAt() 		*
 * functions to implement this function.									*
 * DO NOT modify the input matrix.											*
 ***************************************************************************/
Matrix *transpose(Matrix *m)
{
	Matrix *result = NULL;
	
	// TO DO
	result = create(m->columns, m->rows);
	for(int row = 0; row < m->rows; row++)
	{
		for(int col = 0; col < m->columns; col++)
		{
			setValueAt(result,col,row,getValueAt(m, row, col));
		}
	}	

	return result;
}

/****************************************************************************
 * Creates a matrix that is the product of the given scalar value and		*
 * the input matrix and returns a pointer to the result matrix.				*
 * Use create(), getValueAt(), and setValueAt() functions to implement 		*
 * this function.															*
 * DO NOT modify the input matrix.											*
 ***************************************************************************/
Matrix *scalarMultiply(Matrix *m, int scalar)
{
	Matrix *result = NULL;
	
	// TO DO
	result = create(m->rows, m->columns);
	for(int row = 0; row < m->rows; row++)
	{
		for(int col = 0; col < m->columns; col++)
		{
			setValueAt(result,row,col,scalar*getValueAt(m,row,col));
		}
	}

	return result;
}

/****************************************************************************
 * If the input matrices are compatible, then multiplies the input matrices	*
 * and returns a pointer to the result matrix. Use create(), getValueAt(), 	*
 * and setValueAt() functions to implement this function.					*														*
 *																			*
 * If the input matrices are not compatible, return NULL.					*
 * DO NOT modify the input matrices.										*											*
 ***************************************************************************/
Matrix *multiply(Matrix *m1, Matrix *m2)
{
	Matrix *result = NULL;
	
	if(m1->rows == m2->rows && m1->columns == m2->columns)
	{
		result = create(m1->rows, m1->columns);
		for(int row = 0; row < m1->rows; row++)
		{
			for(int col = 0; col < m1->columns; col++)
			{
				//printf("1. Row: %d Col: %d\n", row, col);
				int value = (getValueAt(m1, row,col) * getValueAt(m2,row,col));
				//printf("2. Row: %d Col: %d\n", row, col);
				setValueAt(result, row, col, value);				
			}
		}
	}
	
	return result;
}