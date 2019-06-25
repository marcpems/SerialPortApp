// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.

namespace ReadApp
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO.Ports;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<string> ReceivedData { get; } = new ObservableCollection<string>();
        private SerialPort port;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ReceivedData.Add(port.ReadExisting());
            });
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                port = new SerialPort("COM3");
                port.DataReceived += Port_DataReceived;
                port.Open();
                ReceivedData.Add("COM3 port is now open and listening...");
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.ToString()).ShowAsync();
            }
        }
    }
}
