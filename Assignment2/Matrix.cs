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

            double sum = 0;

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    sum = matrixA[i, j] + matrixB[i, j];
                    resultMatrix[i, j] = sum;
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

        //A * A^(-1) = A^(-1) * A= Identity matrix
        public static Matrix Inverse(Matrix matrix)
        {
            if(matrix.NumberOfRows != matrix.NumberOfColumns)
            {
                throw new Exception("Matrix must be square matrix to find its inverse.");
            }

            Matrix inverseMatrix = new Matrix(matrix.NumberOfRows, matrix.NumberOfColumns);

            //special case for 2x2 matrix:
            //A = { a , b }
            //    { c , d }
            //inverse of A = 1/(|ad-bc|) { d , -b }
            //                           { -c , a }
            if (matrix.NumberOfRows == 2)
            {
                double determinant = Math.Abs(DeterminantOfMatrix(inverseMatrix,inverseMatrix.NumberOfRows));
                if (determinant == 0)
                {
                    throw new Exception("Can not find inverse, because determinant of matrix A is zero.");
                }

                Console.WriteLine($"\nDeterminant of matrix is {determinant}");
                
                Matrix MatrixII = new Matrix(matrix.NumberOfRows, matrix.NumberOfRows);
                MatrixII[0, 0] = matrix[1, 1];
                MatrixII[1, 1] = matrix[0, 0];
                MatrixII[0, 1] = -(matrix[0, 1]);
                MatrixII[1, 0] = -(matrix[1, 0]);

                for (int i = 0; i < inverseMatrix.NumberOfRows; i++)
                {
                    for (int j = 0; j < inverseMatrix.NumberOfColumns; j++)
                    {
                        inverseMatrix[i, j] = Math.Round( 1/(determinant) * (MatrixII[i, j]) , 2 );
                    }
                }
                return inverseMatrix;
            }

            //TO DO for square matrices with dimenion 3 and above
            throw new Exception("Program does not support inverse for matrices with dimension 3 and above.");

            //return inverseMatrix;
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
            Matrix IdentityMatrix = new Matrix(matrix.NumberOfRows, matrix.NumberOfColumns);
            for (int i = 0; i < IdentityMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < IdentityMatrix.NumberOfColumns; j++)
                {
                    if (i==j)
                    {
                        IdentityMatrix[i, j] = 1;
                    }
                    else
                    {
                        IdentityMatrix[i, j] = 0;
                    }
                }
            }

            var mult = Multiplication(matrix, transpose);
            return Equals(mult, IdentityMatrix);
        }

        //Two matrices are equal if all three of the following conditions are met:
        //Each matrix has the same number of rows.
        //Each matrix has the same number of columns.
        //Corresponding elements within each matrix are equal.
        public static bool Equals(Matrix A,Matrix B)
        {
            if (A == null && B==null)
            {
                throw new Exception("Matrix is empty!");
            }
            if (A.NumberOfRows != B.NumberOfRows && A.NumberOfColumns != B.NumberOfColumns)
            {
                return false;
            }

            for (int i = 0; i < A.NumberOfRows; i++)
            {
                for (int j = 0; j < B.NumberOfRows; j++)
                {
                    if (A[i,j] != B[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public static double DeterminantOfMatrix(Matrix mat, int n)
        {
            if (mat.NumberOfRows != mat.NumberOfColumns)
            {
                throw new Exception("Matrix must be square to calculate determinant");
            }

            double D = 0; // Initialize result 

            if (n == 1)
                return mat[0, 0];


            // To store cofactors 
            Matrix temp = new Matrix(mat.NumberOfRows,mat.NumberOfColumns);

            // To store sign multiplier 
            int sign = 1;

            // Iterate for each element 
            // of first row 
            for (int f = 0; f < n; f++)
            {

                // Getting Cofactor of mat[0][f] 
                getCofactor(mat, temp, 0, f, n);
                D += sign * mat[0, f] * DeterminantOfMatrix(temp, n-1);

                // terms are to be added with  
                // alternate sign 
                sign = -sign;
            }
            return D;
        }
        private static void getCofactor(Matrix A, Matrix temp, int p, int q, int n)
        {
            int i = 0, j = 0;

            // Looping for each element of the matrix 
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    //  Copying into temporary matrix only those element 
                    //  which are not in given row and column 
                    if (row != p && col != q)
                    {
                        temp[i,j++] = A[row,col];

                        // Row is filled, so increase row index and 
                        // reset col index 
                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

    }
}
