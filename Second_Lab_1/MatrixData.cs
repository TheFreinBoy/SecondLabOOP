using System;
using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace Da
{
    public partial class MyMatrix
    {
        private double [,] matrix;
        // 1
        public MyMatrix(MyMatrix other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            int rows = other.matrix.GetLength(0);
            int cols = other.matrix.GetLength(1);
            matrix = new double[rows, cols];
            Array.Copy(other.matrix, matrix, other.matrix.Length);
        }

        // 2
        public MyMatrix(double[,] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            matrix = (double[,])array.Clone();
        }

        // 3
        public MyMatrix(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0) throw new ArgumentException("Зубчастий масив пустий");           
            int cols = jaggedArray[0].Length;
            if (!jaggedArray.All(row => row.Length == cols))
                throw new ArgumentException("Зубчастий масив не є прямокутним");

            matrix = new double[jaggedArray.Length, cols];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
            
        }

        // 4
        public MyMatrix(string[] lines)
        {
            if (lines == null || lines.Length == 0) throw new ArgumentException("Вхідний рядковий масив порожній або нульовий");

            string[] firstLineValues = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int cols = firstLineValues.Length;

            matrix = new double[lines.Length, cols];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != cols) throw new ArgumentException("Рядки мають різну кількість стовпців");

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }
        }

        // 5
        public MyMatrix(string matrixString)
        {
            if (string.IsNullOrWhiteSpace(matrixString)) throw new ArgumentException("Вхідний рядковий масив порожній або нульовий");

            string[] lines = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] firstLineValues = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int cols = firstLineValues.Length;

            matrix = new double[lines.Length, cols];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != cols) throw new ArgumentException("Рядки мають різну кількість стовпців");

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }
        }
        public double this[int row, int col]
        {
            get
            {               
                if (row < 0 || row >= Height || col < 0 || col >= Width)
                    throw new IndexOutOfRangeException("Індекси поза межами матриці");

                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Height || col < 0 || col >= Width)
                    throw new IndexOutOfRangeException("Індекси поза межами матриці");

                matrix[row, col] = value;
            }
            
        }
        public double getElement(int row, int col)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
                throw new IndexOutOfRangeException("Індекси поза межами матриці");

            return matrix[row, col];
        }
        public void setElement(int row, int col, double value)
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
                throw new IndexOutOfRangeException("Індекси поза межами матриці");

            matrix[row, col] = value;
        }   
        public int Height
        {
            get
            {
                return matrix.GetLength(1);
            }
        }
        public int Width
        {
            get
            {
                return matrix.GetLength(0);
            }
        }
        public int Get_Height()
        {
            return matrix.GetLength(0);
        }
        public int Get_Width()
        {
            return matrix.GetLength(1);
        }

        
        public override string ToString()
        {
            string result = ""; 
            int rows = Height; 
            int cols = Width; 

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j].ToString(); 

                    if (j < cols - 1)
                    {
                        result += " "; 
                    }
                }
                result += "\n"; 
            }

            return result;
        }
    }
}