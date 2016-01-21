// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows.Controls;
using Microsoft.Research.DynamicDataDisplay;

namespace PlotSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // This lines are workaround of a XAML parser bug - XAML doesn't understand "-Infinity"
            Plot.SetY1(va, Double.NegativeInfinity);
            Plot.SetX1(ha, Double.NegativeInfinity);
        }
    }
}

