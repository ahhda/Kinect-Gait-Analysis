// Copyright © 2010-2011 Microsoft Corporation, All Rights Reserved.

using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Controls;

namespace DynamicMarkerGraphSample
{
    public partial class MainPage : UserControl
    {
        private volatile bool isUnloaded = false;
        private AutoResetEvent renderComplete = new AutoResetEvent(false);
        private Thread thread;
        private double phase = 0;

        const int N = 1000;
        double[] y = new double[N];

        public MainPage()
        {
            InitializeComponent();
            markers.MarkersBatchSize = 1000;

            // Start computation thread when Page appears on the screen
            Loaded += (s, e) =>
            {
                thread = new Thread(ModelRun);
                isUnloaded = false;
                thread.Start();
            };

            // Stop computation thread when Page is removed from the screen
            Unloaded += (s, e) =>
            {
                isUnloaded = true;
                renderComplete.Set();
                thread.Join();
            };
        }

        private void ModelRun()
        {
            while (!isUnloaded)
            {
                // Data array is updated
                for (int i = 0; i < N; i++)
                    y[i] = Math.Cos(i * Math.PI / 50 + phase);
                phase += 0.1;

                // Plot the computed array.
                // PlotY and Subscribe methods must be called from the UI dispatcher thread. 
                // Unlike ConcurrentMarkerGraphSample here we wait for each frame to be rendered.
                if (!isUnloaded)
                {
                    renderComplete.Reset();
                    Dispatcher.BeginInvoke(PlotData);
                    renderComplete.WaitOne();
                }
            }
        }

        private void PlotData()
        {
            // To increase responsiveness of the UI HeatmapGraph objects prepare 
            // images to be drawn in a background thread. The Plot method cancels
            // current incomplete images before starting a new one. This may result
            // in loss of certain or even all of the frames.
            // The following code shows how to wait until a certain data is actually drawn.
            
            long id = markers.PlotY(y); // receive a unique operation identifier
            markers.RenderCompletion // an observable of completed and cancelled operations
                .Where(rc => rc.TaskId == id) // filter out an operation with the known id
                .Subscribe(dummy => { renderComplete.Set(); }); // signal when the id is observed
        }
    }
}

