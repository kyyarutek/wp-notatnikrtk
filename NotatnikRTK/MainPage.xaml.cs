using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.IO.IsolatedStorage;

namespace NotatnikRTK
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var appStorage = IsolatedStorageFile.GetUserStoreForApplication();
            string fileName = "simple.txt";
            using (var file = appStorage.OpenFile(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                using (var writer = new StreamWriter(file))
                {
                    writer.Write(textBox1.Text);
                }

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            { 
            using(StreamReader sr= new StreamReader(store.OpenFile("simple.txt", FileMode.Open, FileAccess.Read)))
            {
                textBox1.Text = sr.ReadToEnd();
            
            }
            
            }
        }
        }
    }
