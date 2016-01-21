// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;

namespace MatrixDisplaySample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Create random integer matrix
            const int n = 300, m = 250;
            Random r = new Random();            
            int[,] data = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    data[i, j] = r.Next(100);

            for (int i = 0; i <= n; i++)
            {
                var l = new Line
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.Black),
                    Visibility = System.Windows.Visibility.Collapsed
                };
                Plot.SetX1(l, -0.5 + i);
                Plot.SetX2(l, -0.5 + i);
                Plot.SetY1(l, -0.5);
                Plot.SetY2(l, m - 0.5);
                lines.Children.Add(l);
            }

            for (int i = 0; i <= m; i++)
            {
                var l = new Line
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush(Colors.Black),
                    Visibility = System.Windows.Visibility.Collapsed
                };
                Plot.SetY1(l, -0.5 + i);
                Plot.SetY2(l, -0.5 + i);
                Plot.SetX1(l, -0.5);
                Plot.SetX2(l, n - 0.5);
                lines.Children.Add(l);
            }

            // Fix aspect ratio for plotter so matrix cell will always be square
            plotter.AspectRatio = 1.0;

            // Plot matrix data in bitmap mode. Note that grid is offset by -0.5 so integer grid point
            // corresponds to matrix cell centers
            matrix.Plot(data,
                        Enumerable.Range(0, data.GetLength(0) + 1).Select(i => i - 0.5).ToArray(),
                        Enumerable.Range(0, data.GetLength(1) + 1).Select(i => i - 0.5).ToArray());
        }

        private void lines_PlotTransformChanged(object sender, EventArgs e)
        {
            var v = (lines.ScaleX < 20 || lines.ScaleY < 20) ? (Visibility.Collapsed) : (Visibility.Visible);
            foreach (var c in lines.Children)
                if (c.Visibility != v)
                    c.Visibility = v;
        }
    }
}
