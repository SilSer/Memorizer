using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Memorizer
{
    public class MainMenu
    {
        private int answer;
        public void Menu()
        {
            Console.Write("1 - Начать изучение\n" +
                "2 - Добавить новую тему\n" +
                "3 - Добавить новое слово\n" +
                "0 - Выход\n");           
            try
            { 
                answer= int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        new Start();
                        break;
                    case 2:
                        new NewTopic().Create();
                        break;
                    case 3:
                        new NewWord().AddWord();
                        break;
                    case 0:
                        Console.WriteLine("Всего доброго!");

                        Task.Delay(1);
                        Process.GetCurrentProcess().Kill();
                        break;
                    default:
                        Console.WriteLine("Нет такого номера меню");
                        this.Menu();
                        break;

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите только цифру меню");
                this.Menu();
            }
               
                
        }
    }
}