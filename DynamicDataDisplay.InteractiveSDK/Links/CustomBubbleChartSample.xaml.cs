// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace CustomBubbleChartSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent(); 
            
            const int N = 200;
            double[] x = new double[N];
            double[] y = new double[N];
            double[] d = new double[N];

            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                x[i] = rand.Next(N);
                y[i] = rand.Next(N);
                d[i] = 100 * rand.NextDouble();
            }

            markers.Plot(x, y, d);
        }
    }
}

