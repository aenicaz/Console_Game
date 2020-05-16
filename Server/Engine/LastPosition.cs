using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;

namespace WcfService.Engine
{
    public class LastPosition
    {
        private static string path = @"C:\Users\good\Desktop\Project\Game\Aggar\Console_Game\Server\App_Data\UserData\LastPosition.txt";
        //Загрузка последней позиции
        public static Point LoadLastPosition(string login)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] word = line.Split(' '); //разбиваем строку "логин позиция"
                    //проверяем первое слово в строке
                    if (word[0] == login)
                    {
                        string pos = word[1].Replace(';', ',');
                        Point point = Point.Parse(pos);
                        return point;
                    }
                }
                return new Point(0,0);
            }
        }

        //Сохранение последней позиции игрока
        public static void SaveLastPoint(string login, Point position)
        {
                string[] text = File.ReadAllLines(path);
                for(int i = 0; i < text.Length; i++)
                {
                    string[] word = text[i].Split(' ');
                    if (word[0] == login)
                    {
                        word[1] = position.ToString();
                        text[i] = word[0] + " " + word[1];
                        File.WriteAllLines(path, text);
                        return;
                    }

                    
                }

                File.AppendAllText(path, $"\n{login} {position.ToString()}");

            }
        }
}

