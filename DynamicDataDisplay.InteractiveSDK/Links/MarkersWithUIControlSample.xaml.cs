// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Windows;
using System.Windows.Controls;

namespace MarkersWithUIControlSample
{
    public partial class MainPage : UserControl
    {
        const int N = 1000;
        double[] y = new double[N];
        
        public MainPage()
        {
            InitializeComponent();
          
            for (int i = 0; i < N; i++)
                y[i] = Math.Cos(i * Math.PI / 50);
            
            // Array y is mutable so pass copy of this array to Plot
            markers.PlotY((double[])y.Clone());
        }

        private void phaseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((phaseSlider != null) && (ampSlider != null))
            {
                for (int i = 0; i < N; i++)
                    y[i] = ampSlider.Value * Math.Cos(i * Math.PI / 50 + phaseSlider.Value);

                markers.PlotY((double[])y.Clone());
            }
        }

        private void ampSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((phaseSlider != null) && (ampSlider != null))
            {
                for (int i = 0; i < N; i++)
                    y[i] = ampSlider.Value * Math.Cos(i * Math.PI / 50 + phaseSlider.Value);

                markers.PlotY((double[])y.Clone());
            }
        }
    }
}

