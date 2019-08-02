using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PrintSample.UWP
{
    public sealed partial class MainPage
    {
        public static MainPage Current;
        //private PrintHelper printHelper;
        //public Canvas PageCanvas;
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new PrintSample.App());
        }
        
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    };
}
