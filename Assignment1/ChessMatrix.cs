using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using static Assignment1.ChessMatrix;

namespace Assignment1
{
    public class ChessMatrix
    {
        public class UnEqualDimensionError : Exception
        {
            public UnEqualDimensionError(string message) : base(message)
            {
            }
        }
        public class MatrixRowColError : Exception {};
        private  List<int> Matrix = new List<int>();
        private  int rows;
        private  int cols;
        public ChessMatrix(List<int> a, int row, int col)
        {
            this.Matrix = a;
            this.rows = row;
            this.cols = col;
        }
        public ChessMatrix (String Filename, int row, int col)
        {
            int size = 0;
            rows = row; cols = col; 
            Matrix = new List<int> ();
            TextFileReader reader = new TextFileReader(Filename);
            while (reader.ReadInt(out int e))
            {
                
                    this.Matrix.Add(e);
                    size++;
                
            }
        }
        public int getRow() { return rows; }
        public int getColumn() { return cols; }
        public List<int> getList() { return Matrix; }
        public int getValue(int i, int j)
        {
            int k = j * this.rows + i;

            if (k % 2 == 0 )
            {
             
                return Matrix[k / 2];
               
            }
            else
            {
               
                return 0;
            }
        }
        public void print()
        {
            for (int j=0; j < this.rows; j++ )
                {
                for( int i = 0; i <this.cols; i++ )
                {
                    Console.Write(this.getValue(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
        public ChessMatrix addition(ChessMatrix A)
        {
            try
              {
                ChessMatrix ch;
                List<int> a = new List<int>(this.rows * this.cols);
                if ((this.Matrix).Count != (A.Matrix).Count) throw new UnEqualDimensionError("Not same Dimension");
                for (int i = 0; i < this.Matrix.Count; i++)
                {
                    a.Add(this.Matrix[i] + A.Matrix[i]);
                }

                ch = new ChessMatrix(a, this.rows, this.cols);
                return ch;
            }
            catch (UnEqualDimensionError e){ Console.WriteLine(e.ToString()); return null; }
        }
        public ChessMatrix multiplication(ChessMatrix A) {

            if ((this.Matrix).Count != (A.Matrix).Count) throw new UnEqualDimensionError("Not same Dimension");
            ChessMatrix ch;
            int sum = 0;
            List<int> p = new List<int>();
            for (int j = 0; j < A.cols; j++)
            {
                for (int i = 0; i < this.rows; i++)
                {
                    sum = 0;
                    for (int k = 0; k < A.rows; k++)
                    {
                        sum = sum + (this.getValue(i, k) * A.getValue(k, j));
                    }
                    if (sum != 0)
                    {
                        p.Add(sum);
                    }
                }
            }
            ch = new ChessMatrix(p, A.cols, this.rows);
            return ch;
        }

        
    }
}
