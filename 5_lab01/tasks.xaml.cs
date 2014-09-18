using Microsoft.Win32;
using System;
using System.Windows;
using System.IO;
using System.Text;


namespace _5_lab01
{
    /// <summary>
    /// Interaction logic for tasks.xaml
    /// </summary>
    public partial class tasks : Window
    {
        public tasks()
        {
            InitializeComponent();
        }

        private void firstTask_Click(object sender, RoutedEventArgs e)
        {
            //получаем адресс файла
            string  filename       =   getFileName("");
            int     numberOfLines  =   getNumberOfLines( 0, filename),
                    count          =   0;


            // забиваем массив
            int[] mass = getMass(numberOfLines, filename, 0);


            //считаем количество элементов массива, удовлетворяющих условию
            for (int i = 1; i < numberOfLines - 1; i++)
                if (mass[i] > mass[i - 1] && mass[i] > mass[i + 1])
                    count++;

            lbOne.Items.Add("Количество элементов масива, больших своих соседей: " + count + "\n");
        }

        private void secondTask_Click(object sender, RoutedEventArgs e)
        {
            string  filename        =   getFileName("");
            int numberOfLines       =   getNumberOfLines(0, filename);

            // забиваем массив
            int[] mass = getMass(numberOfLines, filename, 0);

            for (int i = 0; i < numberOfLines - 1; i++)
                if(mass[i] > 25)
                {
                    lbOne.Items.Add("Номер первого элемента массива, большего 25: " + (i+1) + "\n");
                    break;
                }
                    

        }

        private void thirdTask_Click(object sender, RoutedEventArgs e)
        {
            string filename = getFileName("");
            int numberOfLines = getNumberOfLines(0, filename),
                summ = 0;

            // забиваем массив
            int[] mass = getMass(numberOfLines, filename, 0);

            for (int i = 0; i < numberOfLines; i++)
                if (mass[i] > mass[1])
                  
                    summ += mass[i];

            lbOne.Items.Add("Сумма элеметов, больших 2ого элемента массива: " + summ + "\n");

        }



        public string getFileName(string filename)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
                filename = dlg.FileName;

            return filename;
        }

        public int getNumberOfLines(int numberOfLines, string filename)
        {
            var reader = File.OpenText(filename);
            while (reader.ReadLine() != null)
                numberOfLines++;


            return numberOfLines;

        }

        public int[] getMass(int numberOfLines, string filename, int index)
        {
            int[] mass = new int[numberOfLines];

            foreach (string number in File.ReadLines(filename))
            {
                mass[index] = int.Parse(number);
                index++;
            }

            return mass;
        }
    }
}