// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Linq;
using System.Windows.Controls;

namespace AxisScrollSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            double[] x = Enumerable.Range(0, 1000).Select(i => i / 10.0).ToArray();
            cos.Plot(x, x.Select(z => Math.Cos(z)).ToArray());
        }
    }
}

