// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Threading;
using System.Windows.Controls;

namespace Tutorial3
{
    public partial class MainPage : UserControl
    {
        private volatile bool isUnloaded = false;
        private Thread thread;
        private double phase = 0;

        public MainPage()
        {
            InitializeComponent();

            // Start computation thread when page appears on the screen
            Loaded += (s, e) =>
            {
                thread = new Thread(ModelRun);
                isUnloaded = false;
                thread.Start();
            };

            // Stop computation thread when page is removed from the screen
            Unloaded += (s, e) =>
            {
                isUnloaded = true;
                thread.Join();
            };
        }

        /// <summary>Performs computations. Runs until isUnloaded became true.</summary>
        private void ModelRun()
        {
            const int N = 1000;
            const int M = 500;

            // 1D arrays for grid 
            double[] x = new double[N + 1];
            double[] y = new double[M + 1];

            // Size of data array here is one less than size of the grid.
            // HeatmapGraph will render in bitmap mode, when grid of size (N+1) x (M+1) 
            // defines N x M rectangular cells filled with solid color according to 
            // corresponding element of data array.
            double[,] f = new double[N, M]; 

            // Coordinate grid is constant and it is initialized once
            for (int i = 0; i <= N; i++)
                x[i] = -Math.PI + 2 * i * Math.PI / N;

            for (int j = 0; j <= M; j++)
                y[j] = -Math.PI / 2 + j * Math.PI / M;

            while (!isUnloaded) // Run until page is on the screen
            {
                // Compute next iteration and store it in data array
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        f[i, j] = Math.Sqrt(x[i] * x[i] + y[j] * y[j])
                                  * Math.Abs(Math.Cos(x[i] * x[i] + y[j] * y[j] + phase));
                phase += 0.1;

                // Uncomment next line to simulate delay in computations
                // Thread.Sleep(1000);

                // Plot the computed array. 
                //
                // The Plot method must be called from the UI dispatcher thread. 
                // We pass a clone of the data array to the Plot method to prevent 
                // concurrent modification of the plotted data. 
                Dispatcher.BeginInvoke(
                    new Action<object>(data => heatmap.Plot((double[,])data, x, y)),
                    f.Clone());
            }
        }
    }
}

