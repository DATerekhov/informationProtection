using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace WpfInformProtection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private static int smesh = (int)'а';
        private static int alphLength = 32;
        public string inputText;
        public static string Encrypt (string text, string keyWord)
        {
            StringBuilder ans = new StringBuilder();
            for (var i = 0; i < text.Length; i++)
            {
                int num = (text[i] + keyWord[i % keyWord.Length] - 2 * smesh);
                char c = (char)(num + smesh);
                ans.Append(c);
            }
            return ans.ToString();
        }

        private void bGo_Click(object sender, RoutedEventArgs e)
        {
            tbOutput.Text = Encrypt(tbInput.Text, "ключ");
        }

        private void bFileIn_Click(object sender, RoutedEventArgs e)
        {
            var myDialog = new OpenFileDialog();
            myDialog.Filter = "Все файлы (*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;

            if (myDialog.ShowDialog() == true)
            {
                tbInput.Text = myDialog.FileName.ToString().Split('\\').Last();
                Stream myStream = null;

                if ((myStream = myDialog.OpenFile()) != null)
                {
                    var file = new StreamReader(myStream);
                    var counter = 0;
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        counter++;
                        if (counter > 1)
                        {
                            tbInput.Text = "";
                            MessageBox.Show("Error");
                            return;
                        }
                        inputText = line;
                    }
                }
                myStream.Close();
            }
        }
    }
}
