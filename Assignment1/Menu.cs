using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment1
{
    class Menu
    {
        public class MatrixRowColError : Exception { };
        public class Empty : Exception { };
        public class EmptyError : Exception
        {
            public EmptyError(string message) : base(message)
            {
            }
        }
        private List<ChessMatrix> chz = new List<ChessMatrix>();
    private static int GetMenuInput()
    {
        int v;
        Console.WriteLine("\n********************************");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Multiplication");
        Console.WriteLine("3. GetValue");
        Console.WriteLine("4. Print");
        Console.WriteLine("5. Store ChessMatrixes");
        Console.WriteLine("****************************************");

        v = int.Parse(Console.ReadLine());

        return v;
    }

    public void Run()
    {
        int v;
        do
        {
            v = GetMenuInput();
            switch (v)
            {
                case 0:
                    Console.WriteLine("\nBye!");
                    break;
                case 1:
                    Addition();
                    
                    break;
                case 2:
                    Multiplication();
                   
                    break;
                case 3:
                    GetValue();

                    break;
                case 4:
                        Print();

                        break;
                case 5:
                        enterMatrix();
                        break;
                    default:

                    Console.WriteLine("\nInvalid option");
                    break;

            }
        } while (v != 0);
    }
        private void enterMatrix()
        {
            Console.WriteLine("Enter number of ChessMatrixes to be Stored");
            int numberOfMatrix = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 1 for input by Textfile,Enter 2 for input by List<int>");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
            case 1:
            for (int i = 0; i < numberOfMatrix; i++)
                {
                Console.WriteLine("Enter numberrows , columns for and TextFile name" + (i+1));
                int row = int.Parse(Console.ReadLine());
                int cols = int.Parse(Console.ReadLine());
                String name = Console.ReadLine();
                ChessMatrix temp = new ChessMatrix(name, row, cols);
                        chz.Add(temp);
                 }
                    break;
            case 2:
            for (int i = 0;i < numberOfMatrix; i++)
                    {
                        Console.WriteLine("Enter numberrows , columns for and List<integers>'s size" + (i+1));
                        int row = int.Parse(Console.ReadLine());
                        int cols = int.Parse(Console.ReadLine());
                        int size = int.Parse(Console.ReadLine());
                        List<int> ints = new List<int>();
                        for(int j =0; j< size;j++)
                        {
                            Console.WriteLine("Enter List element at" + (j + 1));
                        }
                        ChessMatrix temp = new ChessMatrix(ints, row, cols);
                        chz.Add(temp);
                    }
            break;
                default:

                    Console.WriteLine("\nInvalid option");
                    break;


            }

        }

        private void Addition()
        {
            int option;
            try
            {
                
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 1");
                        int rows = int.Parse(Console.ReadLine());
                        int cols = int.Parse(Console.ReadLine());
                        String nametxt1 = Console.ReadLine();
                        ChessMatrix matrix1 = new ChessMatrix(nametxt1, rows, cols);
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 2");
                        int rows2 = int.Parse(Console.ReadLine());
                        int cols2 = int.Parse(Console.ReadLine());
                        String nametxt2 = Console.ReadLine();
                        ChessMatrix matrix2 = new ChessMatrix(nametxt2, rows2, cols2);

                        ChessMatrix ch = matrix1.addition(matrix2);
                        ch.print();
                        break;
                    case 2:
                        Console.WriteLine("Enter number of rows,columns and List size for input for Matrix 1");
                        int rowsL = int.Parse(Console.ReadLine());
                        int colsL = int.Parse(Console.ReadLine());
                        int size = int.Parse(Console.ReadLine());
                        List<int> matrix1L = new List<int>();
                        for (int i = 0; i < size; i++)
                        {
                            matrix1L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix3 = new ChessMatrix(matrix1L, rowsL, colsL);
                        Console.WriteLine("\"Enter number of rows,columns and List size for input for Matrix 2");
                        int rows2L = int.Parse(Console.ReadLine());
                        int cols2L = int.Parse(Console.ReadLine());
                        int size2 = int.Parse(Console.ReadLine());
                        List<int> matrix2L = new List<int>();
                        for (int i = 0; i < size2; i++)
                        {
                            matrix2L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix4 = new ChessMatrix(matrix2L, rows2L, cols2L);

                        ChessMatrix ch1 = matrix3.addition(matrix4);
                        ch1.print();
                        break;
                    case 3:
                        
                        if (chz.Count == 0) { 
                            Console.WriteLine("empty storage fill storage first, try again from staring ");
                            break; };
                        for(int i =0; i < chz.Count;i++)
                        {
                            chz[i].print();
                        }
                        Console.WriteLine("Enter which 2 ChessMatrix you want to ADD");
                        int first = int.Parse(Console.ReadLine());
                        int second = int.Parse(Console.ReadLine());
                        chz[first].addition(chz[second]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
            }
        }
        
    private void Multiplication()
    {
            int option;
            try
            {
                
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 1");
                        int rows = int.Parse(Console.ReadLine());
                        int cols = int.Parse(Console.ReadLine());
                        String nametxt1 = Console.ReadLine();
                        ChessMatrix matrix1 = new ChessMatrix(nametxt1, rows, cols);
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 2");
                        int rows2 = int.Parse(Console.ReadLine());
                        int cols2 = int.Parse(Console.ReadLine());
                        String nametxt2 = Console.ReadLine();
                        ChessMatrix matrix2 = new ChessMatrix(nametxt2, rows2, cols2);

                        ChessMatrix ch = matrix1.multiplication(matrix2);
                        ch.print();
                        break;
                    case 2:
                        Console.WriteLine("Enter number of rows,columns and List size for input for Matrix 1");
                        int rowsL = int.Parse(Console.ReadLine());
                        int colsL = int.Parse(Console.ReadLine());
                        int size = int.Parse(Console.ReadLine());
                        List<int> matrix1L = new List<int>();
                        for (int i = 0; i < size; i++)
                        {
                            matrix1L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix3 = new ChessMatrix(matrix1L, rowsL, colsL);
                        Console.WriteLine("\"Enter number of rows,columns and List size for input for Matrix 2");
                        int rows2L = int.Parse(Console.ReadLine());
                        int cols2L = int.Parse(Console.ReadLine());
                        int size2 = int.Parse(Console.ReadLine());
                        List<int> matrix2L = new List<int>();
                        for (int i = 0; i < size2; i++)
                        {
                            matrix2L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix4 = new ChessMatrix(matrix2L, rows2L, cols2L);

                        ChessMatrix ch1 = matrix3.multiplication(matrix4);
                        ch1.print();
                        break;
                    case 3:
                        if (chz.Count == 0)
                        {
                            Console.WriteLine("empty storage fill storage first, try again from staring ");
                            break;
                        };
                        Console.WriteLine("Printing All Stored ChessMatrixes");
                        for (int i = 0; i < chz.Count; i++)
                        {
                            chz[i].print();
                        }
                        Console.WriteLine("Enter which 2 ChessMatrix you want to ADD");
                        int first = int.Parse(Console.ReadLine());
                        int second = int.Parse(Console.ReadLine());
                        chz[first].multiplication(chz[second]);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
               
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
            }
        }
        private void GetValue()
    {
            int option;
            try
            {
                
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 1");
                        int rows = int.Parse(Console.ReadLine());
                        int cols = int.Parse(Console.ReadLine());
                        String nametxt1 = Console.ReadLine();
                        ChessMatrix matrix1 = new ChessMatrix(nametxt1, rows, cols);

                        Console.WriteLine("Enter i and j th position to get Value");
                        int i = int.Parse(Console.ReadLine());
                        int j = int.Parse(Console.ReadLine());
                        //String nametxt2 = Console.ReadLine();
                        //ChessMatrix matrix2 = new ChessMatrix(nametxt2, rows2, cols2);
                        Console.WriteLine(matrix1.getValue(j, i));

                       
                        break;
                    case 2:
                        Console.WriteLine("Enter number of rows,columns and List size for input for Matrix 1");
                        int rowsL = int.Parse(Console.ReadLine());
                        int colsL = int.Parse(Console.ReadLine());
                        int size = int.Parse(Console.ReadLine());
                        List<int> matrix1L = new List<int>();
                        for (int k = 0; k < size; k++)
                        {
                            matrix1L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix3 = new ChessMatrix(matrix1L, rowsL, colsL);

                        Console.WriteLine("Enter i and j th position to get Value");
                        int n = int.Parse(Console.ReadLine());
                        int m = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine(matrix3.getValue(m, n));
                        break;
                    case 3:
                        if (chz.Count == 0)
                        {
                            Console.WriteLine("empty storage fill storage first, try again from staring ");
                            break;
                        };
                        Console.WriteLine("Printing All Stored ChessMatrixes");
                        for (int k = 0; k < chz.Count; k++)
                        {
                            chz[k].print();
                        }
                        Console.WriteLine("Enter which ChessMatrix you want to");
                        int first = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter i and j th position to get Value");
                        int o = int.Parse(Console.ReadLine());
                        int p = int.Parse(Console.ReadLine());
                        chz[first].getValue(p,o);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
            }
        }
    
    private void Print()
    {
            int option;
            try
            {

                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter number of rows,columns and Name of Textfile for input for Matrix 1");
                        int rows = int.Parse(Console.ReadLine());
                        int cols = int.Parse(Console.ReadLine());
                        String nametxt1 = Console.ReadLine();
                        ChessMatrix matrix1 = new ChessMatrix(nametxt1, rows, cols);
                        matrix1.print();
                        break;
                    case 2:
                        Console.WriteLine("Enter number of rows,columns and List size for input for Matrix 1");
                        int rowsL = int.Parse(Console.ReadLine());
                        int colsL = int.Parse(Console.ReadLine());
                        int size = int.Parse(Console.ReadLine());
                        List<int> matrix1L = new List<int>();
                        for (int k = 0; k < size; k++)
                        {
                            matrix1L.Add(int.Parse(Console.ReadLine()));
                        }
                        ChessMatrix matrix3 = new ChessMatrix(matrix1L, rowsL, colsL);
                        matrix3.print();

                        break;
                    default:
                        Console.WriteLine("\nInvalid option");
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(" To Enter ChessMatrix Value by text file Press 1");
                Console.WriteLine("To Enter ChessMatrix Value by List<integer> Press 2");
                Console.WriteLine("To Use ChessMatrix From Stored ChessMatrixes Press 3 ");
                option = int.Parse(Console.ReadLine());
            }

        }
    }
}
