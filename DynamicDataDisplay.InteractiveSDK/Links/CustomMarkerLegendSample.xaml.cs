// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Research.DynamicDataDisplay;

namespace CustomMarkerLegendSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            const int N = 100;
            double[] x = new double[N];
            double[] y = new double[N];
            double[] y2 = new double[N];

            for (int j = 0; j < N; j++)
            {
                double s = (j + 1) * Math.PI / 30;
                x[j] = s;
                y[j] = Math.Cos(s);
                y2[j] = Math.Sin(s) / s;
            }

            markers.MarkersBatchSize = 100;
            markers.Plot(x, y, y);

            markers2.MarkersBatchSize = 100;
            markers2.Plot(x, y2, y2);
        }

        private void OnLegendItemMouseLeave(object sender, MouseEventArgs e)
        {
            var markers = (MarkerGraph)((FrameworkElement)sender).DataContext;
            markers.Sources["D"].Data = 10;
        }

        private void OnLegendItemMouseEnter(object sender, MouseEventArgs e)
        {
            var markers = (MarkerGraph)((FrameworkElement)sender).DataContext;
            markers.Sources["D"].Data = 20;
        }
    }
}

