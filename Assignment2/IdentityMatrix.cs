using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class IdentityMatrix
    {
        public int NumberOfRowsAndColumns { get; set; }

        private readonly double[,] _identityMatrix;

        public double this[int rowIndex, int columnIndex]
        {
            get
            {
                return _identityMatrix[rowIndex, columnIndex];
            }
            set
            {
                _identityMatrix[rowIndex, columnIndex] = value;
            }
        }
        public IdentityMatrix(int NumberOfRowsAndColumns)
        {
            this.NumberOfRowsAndColumns = NumberOfRowsAndColumns;

            _identityMatrix = new double[NumberOfRowsAndColumns, NumberOfRowsAndColumns];

            for (int i = 0; i < NumberOfRowsAndColumns; i++)
            {
                for (int j = 0; j < NumberOfRowsAndColumns; j++)
                {
                    if (i == j)
                    {
                        _identityMatrix[i, j] = 1;
                    }
                    else
                    {
                        _identityMatrix[i, j] = 0;
                    }
                }
            }
        }
    }
}
