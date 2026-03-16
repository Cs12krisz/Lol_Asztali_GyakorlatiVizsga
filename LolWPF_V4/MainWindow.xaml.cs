using LolCLI_V4;
using LolCLI_V4.Models;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
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

namespace LolWPF_V4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void cbxOszlopok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string propertyName = cbxOszlopok.SelectedItem.ToString();

            dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.GetType().GetProperty(propertyName).GetValue(x));

        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            cbxOszlopok.SelectedIndex = -1;
            dtgHosok.ItemsSource = Program.hosok;
        }

        private void btMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = $"{cbxOszlopok.SelectedValue}.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                    foreach (var item in dtgHosok.ItemsSource as IOrderedEnumerable<Hos>)
                    {
                        streamWriter.WriteLine($"{item.Name};{item.Title};{item.Category};{item.Tag};{item.HP};{item.Attackdamage};{item.Attackdamageperlevel}");
                    }
                    streamWriter.Close();
                    MessageBox.Show("Sikeres mentés");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Program.Feladat1();
            dtgHosok.ItemsSource = Program.hosok;
            cbxOszlopok.ItemsSource = typeof(Hos).GetProperties().Select(x => x.Name);
        }
    }
}