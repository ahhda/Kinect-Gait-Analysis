// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace Tutorial2
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Compute data
            const int N = 100;
            double[] y = new double[N];
            for (int j = 0; j < N; j++)
                y[j] = Math.Cos(j * Math.PI / 30);

            // Plot line connecting points. Note that we use only Y coordinate. 
            // X is computed automatically as zero-based index of Y array element
            line.PlotY(y);

            // Plot points
            markers.PlotY(y);

            // Compute errors as random numbers
            Random r = new Random();
            double[] err = new double[N];
            for (int i = 0; i < N; i++)
                err[i] = 0.1 + 0.5 * r.NextDouble();

            // Plot error bars
            errors.PlotError(y, err);

        }
    }
}

