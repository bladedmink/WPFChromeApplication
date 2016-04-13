using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OwinServer;

namespace WPFChromeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Start the web server 'http://localhost:9000'
            OwinServer.Program server = new OwinServer.Program();
            server.ConfigureOwinMiddleware();

            // Load the address into the chrome browser
            browser.Address = "http://localhost:9000/index.html";
        }


    }
}
