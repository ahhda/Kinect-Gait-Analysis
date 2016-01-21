// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Linq;
using System.Windows.Controls;

namespace TwoScalesSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            double[] x = Enumerable.Range(-100, 201).Select(i => i / 10.0).ToArray();
            double[] y1 = x.Select(v => Math.Abs(v) < 1e-10 ? 1 : Math.Sin(v) / v).ToArray();
            double[] y2 = x.Select(v => v * v * v).ToArray();

            sinc.Plot(x, y1);
            xcube.Plot(x, y2);
        }
    }
}

