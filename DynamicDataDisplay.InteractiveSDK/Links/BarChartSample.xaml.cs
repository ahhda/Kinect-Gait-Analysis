// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace BarChartSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            int N = 100;
            double[] y = new double[N];

            Random r = new Random();
            double k;

            for (int i = 0; i < N; i++)
            {
                k = r.NextDouble();
                y[i] = k < 0.5 ? r.Next(100) : -r.Next(100);
            }

            barChart.PlotBars(y);
        }
    }
}

