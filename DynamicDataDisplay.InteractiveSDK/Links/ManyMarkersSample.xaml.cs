// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;

namespace ManyMarkersSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            var y = LoadData();
            var x = Enumerable.Range(0, y.Length).Select(p => (double)p).ToArray();

            markers.MarkersBatchSize = 750;
            markers.Plot(x, y);
        }

        private static double[] LoadData()
        {
            List<double> data = new List<double>(11000);
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("r0001.csv", UriKind.Relative));
            using (var sr = new StreamReader(sri.Stream))
            {
                var s = sr.ReadLine();
                while ((s = sr.ReadLine()) != null)
                {
                    var d = double.Parse(s, CultureInfo.InvariantCulture);
                    data.Add(d);
                }
            }
            return data.ToArray();
        }
    }
}

