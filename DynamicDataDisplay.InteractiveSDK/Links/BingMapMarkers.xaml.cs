// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System.Windows.Controls;
using System.Windows.Media;

namespace BingMapMarkers
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            double[] lon = { -1.3174, 16.1450064726981, 36.8418531340113, -0.12456397132825092, 
                               37.61806507988748, 2.2946168987417703, -73.98587708777025, 25.852425882170028 };
            double[] lat = { 51.7828, 69.2923853345889, -1.26065068958957, 51.50064068372273, 
                               55.751810400951186, 48.85851040838576, 40.74829606871251, -17.923747000541198 };
            string[] str = { "cambridgeshire", "Northland", "Southern point", "Big Ben", "Moscow Kremlin", "Eiffel Tower", "Empire State Building", "Victoria Falls" };

            markers.Plot(lon, lat, Colors.Red, 10, str);
        }
    }
}

