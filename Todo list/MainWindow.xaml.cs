using System;
using System.IO;
using System.Collections;
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

namespace Todo_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String dir = @"D:\\Todo\\todo.md";
            if (File.Exists(dir))
            {
                String[] lines = System.IO.File.ReadAllLines("D:\\Todo\\todo.md");
                foreach (String line in lines)
                {
                    list.Items.Add(line);
                }
            }
        }
        
        private void text_MouseEnter(object sender, MouseEventArgs e)
        {
            text.Text = "";
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ArrayList tasks = new ArrayList();
            String dr = @"D:\\Todo";
            if (!Directory.Exists(dr))
            {
                System.IO.Directory.CreateDirectory(dr);
            }
            tasks.Add(text);
            if (tasks.Count > 0)
            {
                for(int i = 0; i < tasks.Count; i++)
                {
                    String k = tasks[i].ToString().Substring(32);
                    list.Items.Add(k.Trim());
                    if (File.Exists("D:\\Todo\\todo.md"))
                    {
                        FileStream file = new FileStream("D:\\Todo\\todo.md", FileMode.Append);
                        
                        StreamWriter sw = new StreamWriter(file);
                        sw.Write(k.Trim()+"\n");
                        sw.Flush();
                        sw.Close();
                        file.Close();
                    }
                    else
                    {
                        FileStream file = new FileStream("D:\\Todo\\todo.md", FileMode.CreateNew);
                        StreamWriter sw = new StreamWriter(file);
                        sw.Write(k.Trim()+"\n");
                        sw.Flush();
                        sw.Close();
                        file.Close();
                    }
                }
            }
                
        }
    }
}
