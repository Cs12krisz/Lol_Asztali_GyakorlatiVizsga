using LolCLI_V4;
using LolCLI_V4.Models;
using Microsoft.Win32;
using System.IO;
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
            Program.Feladat1();
            dtgHosok.ItemsSource = Program.hosok;
            cbxOszlopok.ItemsSource = new string[] { "Name", "Title", "Category", "Tag", "HP", "Attackdamage", "Attackdamageperlevel" };
        }

        private void cbxOszlopok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbxOszlopok.SelectedItem)
            {
                case "Name":

                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Name); break;
                case "Title":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Title); break;
                case "Category":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Category); break;
                case "Tag":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Tag); break;
                case "HP":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.HP); break;
                case "Attackdamage":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Attackdamage); break;
                case "Attackdamageperlevel":
                    dtgHosok.ItemsSource = Program.hosok.OrderByDescending(x => x.Attackdamageperlevel); break;
            }




        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            cbxOszlopok.SelectedIndex = -1;
            dtgHosok.ItemsSource = Program.hosok;
        }

        private void btMentes_Click(object sender, RoutedEventArgs e)
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
            }
        }
    }
}