// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Controls;

namespace BingMapAreaMarkers
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Read data from file
            Stream crop_stream = this.GetType().Assembly.GetManifestResourceStream("BingMapAreaMarkers.crop_area.csv");
            List<double> lat = new List<double>(), lon = new List<double>(), data = new List<double>();
            StreamReader sr = new StreamReader(crop_stream);
            string s = sr.ReadLine();
            while (!string.IsNullOrEmpty(s))
            {
                var a = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                lon.Add(Double.Parse(a[0], CultureInfo.InvariantCulture));
                lat.Add(Double.Parse(a[1], CultureInfo.InvariantCulture));
                data.Add(Double.Parse(a[2], CultureInfo.InvariantCulture));
                s = sr.ReadLine();
            }
            sr.Close();

            markers.PlotColor(lon.ToArray(), lat.ToArray(), data.ToArray());
        }
    }
}

