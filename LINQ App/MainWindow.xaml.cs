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

namespace LINQ_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Windows";
        public MainWindow()
        {
            InitializeComponent();

            // Doing all the work without LINQ
            LINQ1();
        }

        public void LINQ1()
        {
            ShowLargeFilesWithoutLinq(path);
        }

        public void LINQ2()
        {
            ShowLargeFilesWithLinq(path);
        }

        private void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            foreach( FileInfo file in files)
            {
                MessageBox.Show($"{file.Name, -20}  :{file.Length, 10:N0}");
            }
        }

       private void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles() orderby file.Length descending select file;
            string display = "";
            foreach( var file in query.Take(5))
            {
                display = display + $"{file.Name,-20}  :{file.Length,10:N0}" + "\r\n";
            }
            MessageBox.Show(display);
        }

        public void LambdaPractice()
        {
            /*
             * foreach( var employee in developers.Where( employee => employee.Name.NameStartsWithS("S"))
             * {
             * console.WriteLine(employee.Name)
             * }
             * 
             * */
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
