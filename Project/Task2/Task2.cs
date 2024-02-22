using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    /// <summary>
    /// Окружность.
    /// </summary>
    public class Task2
    {
        //private string pathFile1 = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Perfom\Project\Task2\File1.txt";
        //private string pathFile2 = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Perfom\Project\Task2\File2.txt";
        //C:\Users\e.p.emyrov\Desktop\VisualStudioProjects\Perfomance\PerfomanceLab\Project\Task2\File2.txt

        //C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Perfom\Project\Task2

        private List<double[]> listFile2 = new List<double[]>();
        private double centreX = -1;
        private double centreY = -1;
        private double radius = -1;

        /// <summary>
        /// Основная работа.
        /// </summary>
        public void Work(string pathFile1, string pathFile2)
        {
            //Console.WriteLine(pathFile1);
            //Console.WriteLine(pathFile2);
            ClearElements();
            if (CheckFiles(pathFile1, pathFile2).Item2 == true)
            {
                ReadCircle(pathFile1);
                ReadCoordinates(pathFile2);
                FindindDistance();
            }
            else
            {
                Console.WriteLine(CheckFiles(pathFile1, pathFile2).Item1);
            }
        }

        private void ReadValues()
        {
            Console.WriteLine("");
        }

        private void ClearElements()
        {
            centreX = -1;
            centreY = -1;
            radius = -1;
            listFile2.Clear();
        }

        /// <summary>
        /// Проверка файлов.
        /// </summary>
        /// <returns></returns>
        private (string, bool) CheckFiles(string pathFile1, string pathFile2)
        {
            string text = "";
            bool contains = true;
            if (!File.Exists(pathFile1))
            {
                text = "Нет файла: File1.txt\r\n";
                contains = false;
            }
            if (!File.Exists(pathFile2))
            {
                contains = false;
                text += "Нет файла: File2.txt\r\n";
            }
            return (text, contains);
        }

        /// <summary>
        /// Чтение окружности.
        /// </summary>
        private void ReadCircle(string pathFile1)
        {
            try
            {
                var lines = File.ReadAllLines(pathFile1);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                    {
                        String[] words = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int y = 0; y < words.Length; y++)
                        {
                            try
                            {
                                double res = double.Parse(words[y]);
                                if (y == 0)
                                {
                                    centreX = res;
                                }
                                if (y > 0)
                                {
                                    centreY = res;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Введены некорректные данные координат в файле задания окружности! - " + lines[i]);
                            }
                        }
                    }
                    if (i > 0)
                    {
                        try
                        {
                            radius = double.Parse(lines[i]);
                        }
                        catch
                        {
                            Console.WriteLine("Введено некорректное значение радиуса в файле задания окружности! - " + lines[i]);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Не существует файла - File1.txt!");
            }
        }

        /// <summary>
        /// Чтение координат.
        /// </summary>
        private void ReadCoordinates(string pathFile2)
        {
            try
            {
                var lines = File.ReadAllLines(pathFile2);
                foreach (var line in lines)
                {

                    double[] mas = new double[2];
                    String[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        mas[0] = double.Parse(words[0]);
                        mas[1] = double.Parse(words[1]);
                        listFile2.Add(mas);
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные координат в файле задания точек! - " + line);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Не существует файла - File2.txt!");
            }
        }

        private void FindindDistance()
        {
            for(int i = 0; i< listFile2.Count;i++)
            {
                var dist = Math.Sqrt(Math.Pow((listFile2[i][0] - centreX),2) + Math.Pow((listFile2[i][1] - centreY),2));
                
                if (dist == radius)
                {
                    Console.WriteLine(0);
                }
                else if (dist< radius)
                {
                    Console.WriteLine(1);
                }
                else if (dist > radius)
                {
                    Console.WriteLine(2);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
