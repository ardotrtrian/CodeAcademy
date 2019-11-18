using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Matrix
    {
        private static readonly Random random = new Random();

        private readonly double[,] _matrix;

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                return _matrix[rowIndex, columnIndex];
            }
            set
            {
                _matrix[rowIndex, columnIndex] = value;
            }
        }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

        //Initializing the matrix with random numbers
        public Matrix(int NumberOfRows, int NumberOfColumns)
        {
            this.NumberOfRows = NumberOfRows;
            this.NumberOfColumns = NumberOfColumns;
            _matrix = new double[NumberOfRows, NumberOfColumns];

            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    _matrix[row, column] = Math.Round(random.NextDouble() * (9.0)+1.0 , 2);
                }
            }
        }

        //Adding two matrices
        public static Matrix Addition(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null && matrixB == null)
            {
                throw new Exception("Matrix is empty");
            }

            //to add two matrices they must have the same size
            if (matrixA.NumberOfRows != matrixB.NumberOfRows && matrixA.NumberOfColumns != matrixB.NumberOfColumns)
            {
                throw new Exception("Entered matrices aren't the same size");
            }

            Matrix resultMatrix = new Matrix(matrixA.NumberOfRows, matrixA.NumberOfColumns);

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return resultMatrix;
        }

        //Inorder two multiply two matrices, first matrix's columns count must be equal second matrix's row count.
        //and the result matrix will have first matrix's row count and second matrix's column count.
        public static Matrix Multiplication(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == null && matrixB == null)
            {
                throw new Exception("Matrix is empty");
            }
            if (matrixA.NumberOfColumns != matrixB.NumberOfRows)
            {
                throw new Exception("Can't multiply. Matrices are not compatible.");
            }

            Matrix resultMatrix = new Matrix(matrixA.NumberOfRows, matrixB.NumberOfColumns);

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < matrixA.NumberOfColumns; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
            return resultMatrix;
        }

        //Multiplying a matrix by a number
        public static Matrix ScalarMultiplication(Matrix matrix, int constant)
        {
            if (matrix == null)
            {
                throw new Exception("Matrix is empty");
            }

            Matrix resultMatrix = new Matrix(matrix.NumberOfRows, matrix.NumberOfColumns);

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] * constant;
                }
            }
            return resultMatrix;
        }

        //The transpose of a matrix is an operator which flips a matrix over its diagonal, 
        //that is it switches the row and column indices of the matrix by producing another matrix 
        public static Matrix Transpose(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new Exception("Matrix is empty");
            }

            Matrix resultMatrix = new Matrix(matrix.NumberOfColumns, matrix.NumberOfRows);

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    resultMatrix[j,i] = matrix[i,j];
                }
            }

            return resultMatrix;
        }

        public static double Maximum(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new Exception("Matrix is empty");
            }

            double max = matrix[0,0];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }

            return max;
        }

        public static double Minimum(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new Exception("Matrix is empty");
            }

            double min = matrix[0, 0];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }

            return min;
        }

        public static bool IsOrthogonal(Matrix matrix) //if a matrix is orthogonal, we multiply the matrix to its transpose.
                                                       //if result is identity matrix , then input matrix is orthogonal.
        {
            if (matrix == null)
            {
                throw new Exception("Matrix is empty");
            }
            if (matrix.NumberOfRows != matrix.NumberOfColumns)
            {
                throw new Exception("Matrix must be square");
            }

            Matrix transpose = Transpose(matrix);
            IdentityMatrix IdentityMatrix = new IdentityMatrix(matrix.NumberOfRows);

            var mult = Multiplication(matrix, transpose);
            var multII = Multiplication(transpose, matrix);
            return Equal(mult, IdentityMatrix) && Equal(multII, IdentityMatrix);
        }

        //Two matrices are equal if all three of the following conditions are met:
        //Each matrix has the same number of rows.
        //Each matrix has the same number of columns.
        //Corresponding elements within each matrix are equal.
        public static bool Equal(Matrix A,IdentityMatrix B)
        {
            if (A == null && B==null)
            {
                throw new Exception("Matrix is empty!");
            }
            if (A.NumberOfRows != B.NumberOfRowsAndColumns && A.NumberOfColumns != B.NumberOfRowsAndColumns)
            {
                return false;
            }

            for (int i = 0; i < A.NumberOfRows; i++)
            {
                for (int j = 0; j < B.NumberOfRowsAndColumns; j++)
                {
                    if (A[i,j] != B[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static IdentityMatrix Inverse(Matrix matrix)
        {
            // Matrix in not initialized
            if (matrix == null)
            {
                throw new Exception("Matrix is Empty");
            }

            // Matrix is not square
            if (matrix.NumberOfColumns != matrix.NumberOfRows)
            {
                throw new Exception("Matrix must be square to find inverse.");
            }

            IdentityMatrix IdentityMatrix = new IdentityMatrix(matrix.NumberOfColumns);

            Matrix current = new Matrix(matrix.NumberOfColumns, matrix.NumberOfColumns);

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    current[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < current.NumberOfColumns; i++)
            {
                double curr = current[i, i];

                for (int k = 0; k < current.NumberOfColumns; k++)
                {
                    current[i, k] /= curr;
                    IdentityMatrix[i, k] /= curr;
                }

                for (int j = 0; j < current.NumberOfColumns; j++)
                {
                    if (j == i) continue;

                    double currentCoefficient = current[j, i];

                    for (int k = 0; k < current.NumberOfRows; k++)
                    {
                        current[j, k] -= current[i, k] * currentCoefficient;
                        IdentityMatrix[j, k] -= IdentityMatrix[i, k] * currentCoefficient;
                    }
                }
            }
            return IdentityMatrix;
        }
    }
}
