// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace HeatmapPaletteSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            const int N = 1000;
            const int M = 500;

            double[] x = new double[N + 1];
            double[] y = new double[M + 1];
            double[,] f = new double[N, M]; // Gradinent fill

            for (int i = 0; i <= N; i++)
                x[i] = -Math.PI + 2 * i * Math.PI / N;

            for (int j = 0; j <= M; j++)
                y[j] = -Math.PI / 2 + j * Math.PI / M;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    f[i, j] = Math.Sqrt(x[i] * x[i] + y[j] * y[j]) * Math.Abs(Math.Cos(x[i] * x[i] + y[j] * y[j]));

            heatmap.Plot(f, x, y);
        }
    }
}

