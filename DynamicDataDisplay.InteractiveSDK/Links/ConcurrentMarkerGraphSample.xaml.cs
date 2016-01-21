// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace ConcurrentMarkerGraphSample
{
    public partial class MainPage : UserControl
    {
        private volatile bool isUnloaded;
        private Thread thread;
        private double phase;

        public MainPage()
        {
            InitializeComponent();

            markers.MarkersBatchSize = 300;

            // Start computation thread when page appears on the screen
            Loaded += (s, e) =>
            {
                thread = new Thread(ModelRun);
                isUnloaded = false;
                thread.Start();
            };

            // Stop computation thread when page is removed from the screen
            Unloaded += (s, e) =>
            {
                isUnloaded = true;
                thread.Join();
            };
        }

        private void ModelRun()
        {
            const int N = 1000;
            double[] y = new double[N];
            for (int i = 0; i < N; i++)
                y[i] = Math.Cos(i * Math.PI / 50);

            while (!isUnloaded) // Run until page is on the screen
            {
                // Data array is updated
                for (int i = 0; i < N; i++)
                {
                    y[i] = Math.Cos(i * Math.PI / 50 + phase);
                }
                phase += 0.1;

                // Render data only if marker graph is not renderind something.
                // This reduce flickering, but not guarantee that each interation of computations
                // will be rendered.
                if (!markers.IsBusy)
                {
                    // Do not forget to clone changing data before passing to plot
                    double[] data = (double[])y.Clone(); 

                    // MarkerGraph.Plot method is thread safe.
                    // Note: PlotY, PlotXY and other similar methods of derived 
                    // classes are not thread safe and required Dispatcher.BeginInvoke
                    markers.Plot(null, data, Colors.Red, 5.0);
                }
            }
        }
    }
}

