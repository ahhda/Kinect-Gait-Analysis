// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace BubbleChartSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            const int N = 100;
            double[] x = new double[N];
            double[] y = new double[N];
            double[] c = new double[N];
            double[] d = new double[N];

            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                x[i] = rand.Next(N);
                y[i] = rand.Next(N);
                c[i] = 100 + 200 * rand.NextDouble();
                d[i] = 200 * rand.NextDouble();
            }

            markers.PlotColorSize(x, y, c, d);
        }
    }
}

