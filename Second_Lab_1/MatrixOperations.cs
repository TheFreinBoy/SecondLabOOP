using System;
using Da;
using System.Text;

namespace Da
{
    public partial class MyMatrix
    {
         public static MyMatrix operator +(MyMatrix left, MyMatrix right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left), "Ліва матриця не може бути null.");
            if (right == null) throw new ArgumentNullException(nameof(right), "Правий матриця не може бути null.");
            
            if (left.Height != right.Height || left.Width != right.Width)
            {
                throw new ArgumentException("Матриці повинні мати однакові розміри для додавання.");
            }

            MyMatrix result = new MyMatrix(new double[left.Height, left.Width]);

            for (int i = 0; i < left.Height; i++)
            {
                for (int j = 0; j < left.Width; j++)
                {
                    result[i, j] = left[i, j] + right[i, j]; 
                }
            }

            return result; 
        }
        public static MyMatrix operator *(MyMatrix left, MyMatrix right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left), "Ліва матриця не може бути null.");
            if (right == null) throw new ArgumentNullException(nameof(right), "Правий матриця не може бути null.");
            
            if (left.Width != right.Height)
            {
                throw new ArgumentException("Кількість стовпчиків першої матриці повинна дорівнювати кількості рядків другої матриці.");
            }

            MyMatrix result = new MyMatrix(new double[left.Height, right.Width]);

            for (int i = 0; i < left.Height; i++)
            {
                for (int j = 0; j < right.Width; j++)
                {
                    for (int k = 0; k < left.Width; k++) 
                    {
                        result[i, j] += left[i, k] * right[k, j];
                    }
                }
            }

            return result; 
        }
        private double[,] GetTransponedArray()
        {
            int rows = matrix.GetLength(0); 
            int cols = matrix.GetLength(1); 
          
            double[,] transposed = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = matrix[i, j]; 
                }
            }

            return transposed; 
        }
        public MyMatrix GetTransponedCopy()
        {
            double[,] transposedArray = GetTransponedArray(); 
            return new MyMatrix(transposedArray); 
        }
        public void TransponeMe()
        {
            double[,] transposedArray = GetTransponedArray(); 
            matrix = transposedArray; 
        }            
    }
}