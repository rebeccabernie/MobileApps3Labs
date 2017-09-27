using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _03_ElementBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }

    public class Adder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Arg1 {
            get { return arg1; }
            set
            {
                arg1 = value;
                if (PropertyChanged != null)
                {
                    // Raise the property changed event handler - calls update method on data bound values, answer value gets current value
                    PropertyChanged(this, new PropertyChangedEventArgs("AnswerValue")); // Answer Value is changed
                }
            }
        }
        private int arg1;
        public int Arg2 {
            get { return arg2; }
            set
            {
                arg2 = value;
                if (PropertyChanged != null)
                {
                    // Raise the property changed event handler - calls update method on data bound values, answer value gets current value
                    PropertyChanged(this, new PropertyChangedEventArgs("AnswerValue")); // Answer Value is changed
                }
            }
        }
        private int arg2;

        public int AnswerValue { get { return arg1 + arg2; } }

    }
}
