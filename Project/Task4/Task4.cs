using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Project
{
    public class Task4
    {
        //private string pathFile = @"C:\Users\Евгений\Desktop\Задачи от Перфомас лаб\Project\Project\Task4\File3.txt";

        private int[] massiv;
        private int count = 0;

        /// <summary>
        /// Основная работа.
        /// </summary>
        public void Work(string pathFile)
        {
            ClearElements();
            if ( CheckFiles(pathFile).Item2 == true)
            {
                CreateMasssiv(pathFile);
                Sort();
            }
            else
            {
                Console.WriteLine(CheckFiles(pathFile).Item1);
            }
        }

        private void ClearElements()
        {
            massiv = null;
            count = 0;
        }

        private void CreateMasssiv(string pathFile)
        {
            var lines = File.ReadAllLines(pathFile);
            massiv = new int[lines.Length];
            for (int i=0; i<lines.Length;i++)
            {
                massiv[i] = int.Parse(lines[i]);
            }
        }


        private void Sort()
        {
            var summa = massiv.Sum();
            var element = summa / massiv.Length;
            for(int i=0; i< massiv.Length;i++)
            {
                if (massiv[i] < element)
                {
                    while (massiv[i] != element)
                    {
                        massiv[i]++;
                        count++;
                    }
                }
                else if (massiv[i] > element)
                {
                    while (massiv[i] != element)
                    {
                        massiv[i]--;
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            Console.WriteLine();
        }

        /// <summary>
        /// Проверка файлов.
        /// </summary>
        /// <returns></returns>
        private (string, bool) CheckFiles(string pathFile)
        {
            string text = "";
            bool contains = true;
            if (!File.Exists(pathFile))
            {
                text = "Нет файла: File3.txt\r\n";
                contains = false;
            }
            return (text, contains);
        }
    }
}
