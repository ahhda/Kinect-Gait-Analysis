// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;

namespace StandaloneHeatmapSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Prepare data
            double[] coords = new double[11];
            for (int i = 0; i < 11; i++)
                coords[i] = i;

            Random r = new Random();
            double[,] data = new double[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    data[i, j] = r.NextDouble();
            
            // Now plot the data
            standaloneHeatmap.Plot(data, coords, coords);
        }
    }
}

