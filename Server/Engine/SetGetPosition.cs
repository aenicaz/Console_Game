using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;

namespace WcfService.Engine
{
    public class SetGetPosition
    {
        private static string path = @"C:\Users\good\Desktop\Project\Game\Aggar\Console_Game\Server\App_Data\UserData\LastPosition.txt";
        public static Point LoadLastPosition(string login)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] word = line.Split(' '); //разбиваем строку "логин позиция"

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
        public static void SaveLastPoint(string login, Point position)
        {
                /*
                string fullFile = String.Empty;
                bool find = false;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] word = line.Split(' '); //разбиваем строку "логин позиция"
                    if (word[1] == login)
                    {
                        word[2] = position.ToString();
                        find = true;
                    }
                    fullFile += word[1] + " ";
                    fullFile += word[2] + "\n";
                }

                if(!find)
                {
                    StreamWriter writer = new StreamWriter(path, true);
                    writer.Write($"\n{login} {position.ToString()}");
                    return;
                }
                */
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