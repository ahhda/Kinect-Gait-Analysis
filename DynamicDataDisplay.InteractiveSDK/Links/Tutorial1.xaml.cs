// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Linq;
using System.Windows.Controls;

namespace Tutorial1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Compute x array of 1001 points from 0 to 100 with 0.1 step
            var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();

            // Compute y array as sin(x)/x function defined on x grid
            var y = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();

            // Plot data 
            linegraph.Plot(x, y);
        }
    }
}

