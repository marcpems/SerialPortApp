// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.

namespace SerialPortApp
{
    using System;
    using System.IO.Ports;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void SeralButton2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var p = new SerialPort("COM4");
                p.Open();
                p.WriteLine(DateTimeOffset.UtcNow.ToString());
                p.Close();
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.ToString() + "\r\n\r\nDid you start the ReadApp and open the COM port?", "Error").ShowAsync();
            }
        }
    }
}
