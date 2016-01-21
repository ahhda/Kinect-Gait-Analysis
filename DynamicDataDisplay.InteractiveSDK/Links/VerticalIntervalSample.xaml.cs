// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace VerticalIntervalSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            const int N = 100;
            double[] y = new double[N];
            for (int j = 0; j < N; j++)
                y[j] = Math.Cos(j * Math.PI / 30);

            double[] obs1 = new double[N], obs2 = new double[N];            
            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                // Observation bounds. Note that they don't need to be ordered
                obs1[i] = y[i] + 0.5*(r.NextDouble() - 0.5);
                obs2[i] = y[i] + 0.5*(r.NextDouble() - 0.5);
            }

            // Plot intervals
            markers.PlotIntervals(obs1, obs2);
            // Plot points
            markers2.PlotY(y);
        }
    }
}

