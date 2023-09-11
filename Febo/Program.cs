using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Febo
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User(){ Id = 2, FName = "Щукин", LName = "Венедикт", MName = "Андреевич", Age = 21},
                new User(){ Id = 3, FName = "Белов", LName = "Мартын", MName = "Дмитриевич", Age = 25},
                new User(){ Id = 4, FName = "Тарасов", LName = "Сергей", MName = "Игоревич", Age = 28},
                new User(){ Id = 5, FName = "Винников", LName = "Андрей", MName = "Максимович", Age = 20},
                new User(){ Id = 6, FName = "Винников", LName = "Андррейй", MName = "Максимович", Age = 20},

                new User(){ Id = 7, FName = "Горбунов", LName = "Сергей", MName = "Максимович", Age = 30},
                
            };

            //  Проверка на схожесть
            for (int i = 0; i < users.Count; i++)
            {
                int rep = 0;
                for (int j = 0; j < users.Count; j++)
                {
                    if (CheckWord(users[i].LName, users[j].LName) && CheckWord(users[i].MName, users[j].MName))
                        rep++;
                    if (TerWord(users[i].LName, users[j].LName) && TerWord(users[i].MName, users[j].MName))
                        rep++;
                    if (rep > 1 && !users[j].Rep)
                    {
                        users[j].Rep = true;
                        j--;
                    }
                }
            }            


            //  Вывод
            foreach (var u in users)
            {
                if (!u.Rep)
                    Console.WriteLine($"ID: {u.Id}, {u.FName} {u.LName} {u.MName}, {u.Age}  {u.Rep}");
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ID: {u.Id}, {u.FName} {u.LName} {u.MName}, {u.Age} {u.Rep}");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            Console.ReadKey();
        }

        //  Проверка самого слова 
        public static bool CheckWord(string word1, string word2)
        {
            string strLong, strShort;
            strLong = (word1.Length >= word2.Length) ? word1 : word2;
            strShort = (word1.Length < word2.Length) ? word1 : word2;

            int error_count = 0;
            for (int i = 0; i < strShort.Length; i++)
            {
                if (strLong[i] != strShort[i])
                {
                    error_count++;
                }
            }
            double proc = (double)error_count / word1.Length;

            return proc < 0.65;
        }

        //  Термы 
        public static bool TerWord(string word1, string word2)
        {
            string strLong, strShort;
            strLong = (word1.Length >= word2.Length) ? word1 : word2;
            strShort = (word1.Length < word2.Length) ? word1 : word2;

            int error_count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                for (int j = 0; j < word2.Length; j++)
                {
                    if (word2.Length -1 > j)
                    {
                        if (!(word1.Contains(word2[j]) && word1.Contains(word2[j + 1])))
                            error_count++;
                    }
                    else
                        error_count++;
                }
            }

            double proc = (double)error_count / word1.Length;

            return proc < 0.65;
        }
    }
}
