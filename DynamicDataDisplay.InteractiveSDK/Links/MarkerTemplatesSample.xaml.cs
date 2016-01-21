// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace MarkerTemplatesSample
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
                x[i] = i;
                c[i] = 100 + 200 * rand.NextDouble();
                d[i] = rand.Next(5, 15);
            }

            double[] y1 = new double[N];
            double[] y2 = new double[N];
            double[] y3 = new double[N];
            double[] y4 = new double[N];

            for (int i = 0; i < N; i++)
            {
                y[i] = Math.Cos(i * Math.PI / 30);
                y1[i] = Math.Cos(i * Math.PI / 30) - 1;
                y2[i] = Math.Cos(i * Math.PI / 30) - 2;
                y3[i] = Math.Cos(i * Math.PI / 30) - 3;
                y4[i] = Math.Cos(i * Math.PI / 30) - 4;
            }

            circleMarkers.PlotColorSize(x, y, c, d);
            boxMarkers.PlotColorSize(x, y1, c, d);
            diamondMarkers.PlotColorSize(x, y2, c, d);
            triangleMarkers.PlotColorSize(x, y3, c, d);
            crossMarkers.PlotColorSize(x, y4, c, d);
        }
    }
}

