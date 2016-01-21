// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Linq;
using System.Windows.Controls;

namespace Tutorial4
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            var x = Enumerable.Range(100, 1000).Select(i => i / 10000.0).ToArray();
            var y = x.Select(v => v * Math.Sin(1 / v)).ToArray();

            linegraph.Plot(x, y);
        }
    }
}

