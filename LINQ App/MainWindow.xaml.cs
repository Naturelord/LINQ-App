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
        List<Movies> movies = new List<Movies>
    {
        new Movies { Title = "Narnia", Rating = 8.9f , Year = 1958},
        new Movies { Title = "Up", Rating = 8.0f , Year = 1976},
        new Movies { Title = "The King's Speech", Rating = 8.5f , Year = 2010},
        new Movies { Title = "Star Wars", Rating = 8.7f , Year = 2003},
        new Movies { Title = "The Dark Knight", Rating = 8.7f , Year = 1999}
    };
        string path = @"C:\Windows";
        public MainWindow()
        {
            InitializeComponent();

            // Doing all the work without LINQ
            //LINQ1();
            // Using Linq to find the large files
            //LINQ2():
            // Practice LINQ with Movies Class

        }

        public void LINQWithMovies()
        {

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

        public void funcTest()
        {
            // Func<>
            Func<int, int> square = x => x * x;
            // Func takes up to 17 types, THE LAST always being the return type
            Func<int, int, int> add = (x, y) => x + y;
            // If you have more than 1 paramater you must use a parenthesis set.

            // if you include curly braces you have to add the return statement.

            // ACTION
            // Will only take one argument and will not return anything ( void returns only )
            Action<int> write = x => Console.WriteLine(x);
            Console.WriteLine(square(add(3,5)));
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
