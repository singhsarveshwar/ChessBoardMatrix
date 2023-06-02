using Assignment1;
namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void additionTest()
        {
            //3x3
            ChessMatrix ch1 = new ChessMatrix("input.txt", 3, 3);
            ChessMatrix ch2 = new ChessMatrix("input2.txt", 3, 3);
            List <int> test1 = new List<int>() { 7, 9, 11, 13, 15 };
            Assert.AreEqual(string.Join(",",(ch1.addition(ch2)).getList()), string.Join(",", test1));
            List<int> test2 = new List<int>() { 2, 4, 6};
            List<int> test3 = new List<int>() { 2, 4, 6};
            ChessMatrix ch3 = new ChessMatrix (test2 , 3, 3);
            ChessMatrix ch4 = new ChessMatrix(test3, 3, 3);
            Assert.AreEqual(string.Join(",", (ch3.addition(ch4)).getList()),"4,8,12");

            // 4x4 matrices
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, };
            List<int> b = new List<int>() { 9, 10, 11, 12, 13, 14, 15, 16 };
            ChessMatrix matrixA = new ChessMatrix(a, 4, 4);
            ChessMatrix matrixB = new ChessMatrix(b, 4, 4);
            Assert.AreEqual(string.Join(",", (matrixA.addition(matrixB)).getList()), "10,12,14,16,18,20,22,24");

            // 5x5 matrices
            List<int> c = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            List<int> d = new List<int>() { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            ChessMatrix matrixC = new ChessMatrix(c, 5, 5);
            ChessMatrix matrixD = new ChessMatrix(d, 5, 5);
            Assert.AreEqual(string.Join(",", (matrixC.addition(matrixD)).getList()), "15,15,15,15,15,15,15,15,15,15,15,15,15");
        }
        [TestMethod]
        public void mutliplicationTest()
        {
            //2x2,2x3,3x2,3x3
            ChessMatrix ch1 = new ChessMatrix("input.txt", 3, 3);
            ChessMatrix ch2 = new ChessMatrix("input2.txt", 3, 3);
            ChessMatrix chessMatrix = new ChessMatrix("input4.txt",2,2);
            ChessMatrix chessMatrix1 = new ChessMatrix("TextFile1.txt", 2, 2);
            Assert.AreEqual(string.Join(",", (ch1.multiplication(ch1)).getList()), "9,12,9,24,33");
            Assert.AreEqual(string.Join(",", (ch2.multiplication(ch1)).getList()), "24,27,24,69,78");
            Assert.AreEqual(string.Join(",", (chessMatrix.multiplication(chessMatrix)).getList()), "1,2");
            Assert.AreEqual(string.Join(",", (chessMatrix.multiplication(chessMatrix1)).getList()), "3,4");
            Assert.AreEqual(string.Join(",", (chessMatrix1.multiplication(chessMatrix1)).getList()), "9,12");
            List<int> test1 = new List<int>() {1,2,3};
            List<int> test2 = new List<int>() {1,2,3};
            List<int> test3 = new List<int>() { 4, 5 };
            List<int> test4 = new List<int>() { 5,6 };
            ChessMatrix ch3 = new ChessMatrix(test1, 2, 3);
            ChessMatrix ch4 = new ChessMatrix(test2 , 3, 2);
            ChessMatrix ch5 = new ChessMatrix (test3, 2,2);
            ChessMatrix ch6 = new ChessMatrix (test4 , 2,2);
            Assert.AreEqual(string.Join(",", (ch3.multiplication(ch4)).getList()), "7,6");
            Assert.AreEqual(string.Join(",", (ch4.multiplication(ch3)).getList()), "1,2,2,4,3,6");
            Assert.AreEqual(string.Join(",", (ch5.multiplication(ch6)).getList()), "20,24");

            // 4x4 matrices
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8,};
            List<int> b = new List<int>() { 9,10,11,12,13,14,15,16};
            ChessMatrix matrixA = new ChessMatrix(a, 4, 4);
            ChessMatrix matrixB = new ChessMatrix(b, 4, 4);
            Assert.AreEqual(string.Join(",", (matrixA.multiplication(matrixB)).getList()), "59,78,71,94,83,110,95,126");

            // 5x5 matrices
            List<int> c = new List<int>() { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
            List<int> d = new List<int>() { 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 2, 1 };
            ChessMatrix matrixC = new ChessMatrix(c, 5, 5);
            ChessMatrix matrixD = new ChessMatrix(d, 5, 5);
            Assert.AreEqual(string.Join(",", (matrixC.multiplication(matrixD)).getList()), "249,288,341,155,176,149,173,206,80,91,30,37,48");
        }
        [TestMethod]
        public void printTest()
        {
            //3x3
            List<int> testValues = new List<int>() { 1, 2, 3, 4, 5};
            ChessMatrix ch = new ChessMatrix(testValues, 3, 3);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ch.print();

                string expectedOutput = "1 0 2 \r\n0 3 0 \r\n4 0 5 \r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
            //4x4
            List<int> testValues1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            ChessMatrix ch1 = new ChessMatrix(testValues1, 4, 4);

            using (StringWriter sw1 = new StringWriter())
            {
                Console.SetOut(sw1);

                ch1.print();

                string expectedOutput1 = "1 0 2 0 \r\n3 0 4 0 \r\n5 0 6 0 \r\n7 0 8 0 \r\n";
                Assert.AreEqual(expectedOutput1, sw1.ToString());
            }

            //5x5
            //List<int> testValues2 = new List<int>() { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
         ///   ChessMatrix ch2 = new ChessMatrix(testValues2, 5, 5);

      ///      using (StringWriter sw2 = new StringWriter())
    //        {
  //              Console.SetOut(sw2);
//
///                ch2.print();

           //     string expectedOutput2 = "1 0 2 0 4\r\n0 5 0 6 0\r\n7 0 8 0 9\r\n0 10 0 11 0\r\n12 0 13 0 14\r\n";
           //    Assert.AreEqual(expectedOutput2, sw2.ToString());
           // }
        }
        [TestMethod]
        public void getValue()
        {
            //3x3
            List<int> test1 = new List<int>() { 0,0,0,0,0 };
            ChessMatrix ch1 = new ChessMatrix(test1, 3, 3);
            for (int j =0; j < 3; j++)
            {
                for (int i =0; i < 3; i++)
                {
                    Assert.AreEqual(ch1.getValue(i,j),0);
                }
            }
            // 4x4 matrices
            List<int> a = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8};
            ChessMatrix matrixA = new ChessMatrix(a, 4, 4);
            int k = 16;
            int c = 1;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (k % 2 == 0)
                    {
                        Assert.AreEqual(matrixA.getValue(i, j), c);
                        k--;c++;
                    }
                    else
                    {
                        Assert.AreEqual(matrixA.getValue(i, j), 0);
                        k--;
                    }
                }
            }
        }
    }
}