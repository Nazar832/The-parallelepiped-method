using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ParallelepipedMethod
{
    public partial class MyForm : Form
    {
        private int p1, p2;

        private int iInitial, iFinal;
        private int jInitial, jFinal;

        private int maxGraphSize = 5000;

        private bool currentLoopIsParallel = false;

        private int numberOfCurrentLoop = 1;
        private int loopsNumber = 3;

        private double[,] X_sequential;
        private double[,] X_parallel;

        private int rowsNumber;
        private int colsNumber;

        // події, які сигналізують, що відповідні ітерації виконані
        private static ManualResetEventSlim[,] readyEvents;

        public MyForm()
        {
            InitializeComponent();

            nextLoopButton_Click(null, EventArgs.Empty);
        }
        
        private void initializeMatrixes()
        {
            rowsNumber = iFinal - iInitial + 1;
            colsNumber = jFinal - jInitial + 1;

            X_sequential = new double[rowsNumber, colsNumber];
            X_parallel = new double[rowsNumber, colsNumber];

            Random rnd = new Random();
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < colsNumber; j++)
                {
                    double value = Math.Pow(i, 3) * Math.Sqrt(i * j); // задання 1-го набору вхідних даних
                    //double value = 0; // задання 2-го набору вхідних даних
                    //double value = i / (j + 1); // задання 3-го набору вхідних даних

                    X_sequential[i, j] = value;
                    X_parallel[i, j] = value;
                }
            }
        }

        // функція перетворення двовимірного масиву X в одновимірний "стрічковий" вигляд для того, щоб намалювати графік
        private double[] makeArrayFromMatrix(double[,] matrix)
        {
            int colsNumber = matrix.GetLength(1);
            int rowsNumber = matrix.Length > maxGraphSize ? Math.Max(maxGraphSize / colsNumber, 1) : matrix.GetLength(0);

            double[] arr = new double[Math.Min(maxGraphSize, matrix.Length)];
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < colsNumber; j++)
                {
                    int index = i * colsNumber + j;
                    if (index == maxGraphSize) return arr;
                    arr[index] = matrix[i, j];
                }
            }

            return arr;
        }

        private bool resultsMatch()
        {
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < colsNumber; j++)
                {
                    if (X_sequential[i, j] != X_parallel[i, j]) return false;                                       
                }
            }

            return true;
        }

        // послідовний цикл
        private void sequentialLoop()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (numberOfCurrentLoop)
            {
                case 1:
                    for (int i = iInitial; i <= iFinal; i++)
                    {
                        for (int j = jInitial; j <= jFinal; j++)
                        {
                            int row = i - iInitial;
                            int col = j - jInitial;

                            bool dependsOnRowMinus2ColMinus1 = row - 2 >= 0 && col - 1 >= 0;
                            bool dependsOnRowMinus2ColPlus1 = row - 2 >= 0 && col + 1 < colsNumber;

                            double value1 = dependsOnRowMinus2ColMinus1 ? X_sequential[row - 2, col - 1] : X_sequential[row, col];
                            double value2 = dependsOnRowMinus2ColPlus1 ? X_sequential[row - 2, col + 1] : X_sequential[row, col];

                            for (int y = 0; y < 100; y++) X_sequential[row, col] = Math.Pow(Math.Sin(value1), 3) + Math.Sqrt(value2) + 10;
                        }
                    }
                    break;
                case 2:
                    for (int i = iInitial; i <= iFinal; i++)
                    {
                        for (int j = jInitial; j <= jFinal; j++)
                        {
                            int row = i - iInitial;
                            int col = j - jInitial;
                            bool iterationIsDependent = row - 2 >= 0 && col - 1 >= 0;
                            double value = iterationIsDependent ? X_sequential[row - 2, col - 1] : X_sequential[row, col];
                            for (int y = 0; y < 100; y++) X_sequential[row, col] = Math.Log(value + 2) / (20 * Math.Exp(value));
                        }
                    }
                    break;
                case 3:
                    for (int i = iInitial; i <= iFinal; i++)
                    {
                        for (int j = jInitial; j <= jFinal; j++)
                        {
                            int row = i - iInitial;
                            int col = j - jInitial;
                            bool iterationIsDependent = row - 3 >= 0 && 2 * col - 3 >= 0 && 2 * col - 3 < colsNumber;
                            double value = iterationIsDependent ? X_sequential[row - 3, 2 * col - 3] : X_sequential[row, col];
                            for (int y = 0; y < 100; y++) X_sequential[row, col] = Math.Log(Math.Cos(2 * Math.Pow(value, 4)) + 10);
                        }
                    }
                    break;
            }

            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;
            sequentialTimeTextBox.Text = Math.Round(elapsedTime.TotalMilliseconds).ToString();
        }

        // паралельний цикл
        private void parallelLoop()
        {           
            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (numberOfCurrentLoop) 
            {
                case 1:
                    for (int k = 1; k <= p1; k++)
                    {
                        int localK = k;
                        ThreadPool.QueueUserWorkItem(state1 =>
                        {
                            for (int l = 1; l <= p2; l++)
                            {
                                int localL = l;
                                ThreadPool.QueueUserWorkItem(state2 =>
                                {
                                    for (int i = localK + iInitial - 1; i <= iFinal; i += p1)
                                    {
                                        for (int j = localL + jInitial - 1; j <= jFinal; j += p2)
                                        {
                                            int row = i - iInitial;
                                            int col = j - jInitial;

                                            bool dependsOnRowMinus2ColMinus1 = row - 2 >= 0 && col - 1 >= 0;
                                            bool dependsOnRowMinus2ColPlus1 = row - 2 >= 0 && col + 1 < colsNumber;

                                            if (dependsOnRowMinus2ColMinus1) readyEvents[row - 2, col - 1].Wait();
                                            if (dependsOnRowMinus2ColPlus1) readyEvents[row - 2, col + 1].Wait();

                                            double value1 = dependsOnRowMinus2ColMinus1 ? X_parallel[row - 2, col - 1] : X_parallel[row, col];
                                            double value2 = dependsOnRowMinus2ColPlus1 ? X_parallel[row - 2, col + 1] : X_parallel[row, col];

                                            for (int y = 0; y < 100; y++) X_parallel[row, col] = Math.Pow(Math.Sin(value1), 3) + Math.Sqrt(value2) + 10;
                                            readyEvents[row, col].Set();
                                        }
                                    }
                                });
                            }
                        });
                    }
                    break;
                case 2:
                    for (int k = 1; k <= p1; k++)
                    {
                        int localK = k;
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            for (int l = 1; l <= p2; l++)
                            {
                                for (int i = localK + iInitial - 1; i <= iFinal; i += p1)
                                {
                                    for (int j = l + jInitial - 1; j <= jFinal; j += p2)
                                    {
                                        int row = i - iInitial;
                                        int col = j - jInitial;
                                        bool iterationIsDependent = row - 2 >= 0 && col - 1 >= 0;
                                        if (iterationIsDependent) readyEvents[row - 2, col - 1].Wait();
                                        double value = iterationIsDependent ? X_parallel[row - 2, col - 1] : X_parallel[row, col];
                                        for (int y = 0; y < 100; y++) X_parallel[row, col] = Math.Log(value + 2) / (20 * Math.Exp(value));
                                        readyEvents[row, col].Set();
                                    }
                                }
                            }
                        });
                    }
                    break;
                case 3:
                    for (int k = 1; k <= p1; k++)
                    {
                        int localK = k;
                        ThreadPool.QueueUserWorkItem(state1 =>
                        {
                            for (int l = 1; l <= p2; l++)
                            {
                                int localL = l;
                                ThreadPool.QueueUserWorkItem(state2 => {
                                    for (int i = localK + iInitial - 1; i <= iFinal; i += p1)
                                    {
                                        for (int j = localL + jInitial - 1; j <= jFinal; j += p2)
                                        {
                                            int row = i - iInitial;
                                            int col = j - jInitial;
                                            bool iterationIsDependent = row - 3 >= 0 && 2 * col - 3 >= 0 && 2 * col - 3 < colsNumber;
                                            if (iterationIsDependent) readyEvents[row - 3, 2 * col - 3].Wait();
                                            double value = iterationIsDependent ? X_parallel[row - 3, 2 * col - 3] : X_parallel[row, col];
                                            for (int y = 0; y < 100; y++) X_parallel[row, col] = Math.Log(Math.Cos(2 * Math.Pow(value, 4)) + 10);
                                            readyEvents[row, col].Set();
                                        }
                                    }
                                });                               
                            }
                        });
                    }
                    break;
            }

            // чекаємо повного завершення циклу
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < colsNumber; j++)
                {
                    readyEvents[i, j].Wait();
                }
            }

            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;
            parallelTimeTextBox.Text = Math.Round(elapsedTime.TotalMilliseconds).ToString();
        }

        private void nextLoopButton_Click(object sender, EventArgs e)
        {
            nextLoopButton.Enabled = false;

            if (!currentLoopIsParallel) {
                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
                chart.Series[1].IsVisibleInLegend = false;

                doResultsMatchLabel.Text = "";

                sequentialTimeTextBox.Clear();
                parallelTimeTextBox.Clear();

                chart.Titles[0].Text = "Результати виконання " + numberOfCurrentLoop + "-ї пари циклів";

                // встановлення параметрів для поточного циклу
                switch (numberOfCurrentLoop)
                {
                    case 1:
                        p1 = 2; p2 = 6;
                        iInitial = 1; iFinal = 100000;
                        jInitial = 1; jFinal = 6;
                        break;
                    case 2:
                        p1 = 60000; p2 = 1;
                        iInitial = 1; iFinal = 60000;
                        jInitial = 1; jFinal = 24;
                        break;
                    case 3:
                        p1 = 3; p2 = 9;
                        iInitial = 1; iFinal = 75000;
                        jInitial = 1; jFinal = 9;
                        break;
                }

                initializeMatrixes();

                sequentialLoop();

                chart.Series[0].Points.DataBindY(makeArrayFromMatrix(X_sequential));

                currentLoopIsParallel = true;
            }
            else
            {
                chart.Series[1].Points.Clear();
                chart.Series[1].IsVisibleInLegend = true;

                readyEvents = new ManualResetEventSlim[rowsNumber, colsNumber];
                for (int i = 0; i < rowsNumber; i++)
                {
                    for (int j = 0; j < colsNumber; j++)
                    {
                        readyEvents[i, j] = new ManualResetEventSlim(false);
                    }
                }

                parallelLoop();

                currentLoopIsParallel = false;
                numberOfCurrentLoop = numberOfCurrentLoop % loopsNumber + 1;

                chart.Series[1].Points.DataBindY(makeArrayFromMatrix(X_parallel));

                // порівняння результатів послідовного та паралельного виконання
                doResultsMatchLabel.Text = resultsMatch() ? "Результати співпадають!" : "Результати не співпадають!";
            }

            nextLoopButton.Enabled = true;
        }      
    }
}
