// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace MarkerGraphSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            const int N = 1000;
            double[] y = new double[N];

            for (int i = 0; i < N; i++)
                y[i] = Math.Cos(i * Math.PI / 50);

            markers.PlotY(y);
        }
    }
}

