using ConsoleApp32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Auth auth = new Auth();
            auth.Auth1();
            cmbList.ItemsSource = auth.otvet;
            
            btnTest.Click += BtnTest_Click;

               
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            if (cmbList.SelectedIndex <0)
            {
                MessageBox.Show("выберите группу");
            }
            else
            {
                Auth auth = new Auth();
                auth.auth3(cmbList.SelectedItem as string);
                foreach (var s in auth.Student)
                {
                    textB.Text += s.name + "\n";
                }
            }
        }
    }
}