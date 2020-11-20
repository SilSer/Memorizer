using System;
using System.IO;

namespace Memorizer
{
    public class Start
    {
        private int direction;

        public void LangMenu()
        {
            Console.Write("Какое направление перевода будем учить?\n1 - С Русского на Иностранный\n2 - C Иностранного на Русский\n");
            try
            {
                direction = int.Parse(Console.ReadLine());
                switch(direction)
                {
                    case 1:
                        StartRus();
                        break;
                    case 2:
                        StartEng();
                        break;
                    default:
                        Console.WriteLine("Введтите только цифру");
                        LangMenu();
                        break;
                }
                

            }
            catch(FormatException)
            {
                Console.WriteLine("Введите только необходимые цифры");
                LangMenu();
            }

        }
        private void StartRus()
        {
            Console.WriteLine("Выберете правильный вариант на иностранном");
        }
        private void StartEng()
        {
            Console.WriteLine("Выберете правильный вариант на иностранном");
        }
    }
}