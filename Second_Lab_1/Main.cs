using System;
using System.Text;
using Da;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        MyMatrix matrix1 = CreateMatrix("перша");
        Console.WriteLine("\nПерша матриця:");
        Console.WriteLine(matrix1);

        MyMatrix transposedMatrix = matrix1.GetTransponedCopy();
        Console.WriteLine("\nТранспонована матриця:");
        Console.WriteLine(transposedMatrix);

        MyMatrix matrix2 = CreateMatrix("друга");
        Console.WriteLine("\nДруга матриця:");
        Console.WriteLine(matrix2);
       
        MyMatrix sumMatrix = matrix1 + matrix2;
        Console.WriteLine("\nСума матриць:");
        Console.WriteLine(sumMatrix);
              
        MyMatrix productMatrix = matrix1 * matrix2;
        Console.WriteLine("\nДобуток матриць:");
        Console.WriteLine(productMatrix);
               
    }

    private static MyMatrix CreateMatrix(string order)
    {
        Console.WriteLine("Виберіть спосіб створення матриці:");
        Console.WriteLine("1. Копіювання з іншого об'єкта MyMatrix");
        Console.WriteLine("2. Двовимірний масив типу double[,]");
        Console.WriteLine("3. Зубчастий масив double[][] (прямокутний)");
        Console.WriteLine("4. Масив рядків");
        Console.WriteLine("5. Рядок з числами (пробіли, табуляції, переведення рядка)");
        Console.Write("Введіть номер варіанту: ");
        
        int choice = int.Parse(Console.ReadLine());
        MyMatrix matrix = null;

        switch (choice)
        {
            case 1:
                double[,] initialArray = { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } };
                MyMatrix originalMatrix = new MyMatrix(initialArray);
                matrix = new MyMatrix(originalMatrix);
                Console.WriteLine("\nСтворено матрицю шляхом копіювання:");
                break;

            case 2:           
                Console.Write("Введіть кількість рядків: ");
                int rows2D = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість стовпців: ");
                int cols2D = int.Parse(Console.ReadLine());
                double[,] array2D = new double[rows2D, cols2D];
                
                for (int i = 0; i < rows2D; i++)
                {
                    Console.WriteLine($"Введіть елементи рядка {i + 1} через пробіл:");
                    string[] rowElements = Console.ReadLine().Split();
                    for (int j = 0; j < cols2D; j++)
                    {
                        array2D[i, j] = double.Parse(rowElements[j]);
                    }
                }
                matrix = new MyMatrix(array2D);
                Console.WriteLine("\nСтворено матрицю з двовимірного масиву:");
                break;

            case 3:
                Console.Write("Введіть кількість рядків: ");
                int rowsJagged = int.Parse(Console.ReadLine());
                double[][] jaggedArray = new double[rowsJagged][];
                
                for (int i = 0; i < rowsJagged; i++)
                {
                    Console.WriteLine($"Введіть елементи рядка {i + 1} через пробіл:");
                    string[] rowElements = Console.ReadLine().Split();
                    jaggedArray[i] = Array.ConvertAll(rowElements, double.Parse);
                }
                matrix = new MyMatrix(jaggedArray);
                Console.WriteLine("\nСтворено матрицю із зубчастого масиву:");
                break;

            case 4:
                Console.Write("Введіть кількість рядків: ");
                int rowsStringArray = int.Parse(Console.ReadLine());
                string[] lines = new string[rowsStringArray];
                
                for (int i = 0; i < rowsStringArray; i++)
                {
                    Console.WriteLine($"Введіть елементи рядка {i + 1} через пробіл:");
                    lines[i] = Console.ReadLine();
                }
                matrix = new MyMatrix(lines);
                Console.WriteLine("\nСтворено матрицю з масиву рядків:");
                break;

            case 5:
                Console.WriteLine("Введіть всю матрицю в одному рядку. Використовуйте пробіли для розділення чисел та ';' для розділення рядків:");
                string input = Console.ReadLine();               
                string matrixString = input.Replace(";", "\n");
                matrix = new MyMatrix(matrixString);
                break;


            default:
                Console.WriteLine("Неправильний вибір");
                return null;
        }

        return matrix;
    }
}
