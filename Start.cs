using System;
using System.Collections.Generic;
using System.IO;

namespace Memorizer
{
    public class Start
    {
        private int direction;
        private string selectedTopic;
        private string[] topicList;
        private string selectedTopicName;
        private Dictionary<string, string> dictionary=new Dictionary<string, string>();
        Tools tools = new Tools();

        public void LangMenu()
        {           
            Console.WriteLine("Выберете номер темы, в которую хотите добавить слово");
            try
            {
                topicList = tools.GetTopicList();

                int num = int.Parse(Console.ReadLine());
                tools.CheckForMainMenu(num);

                selectedTopic = tools.SelectTopic(topicList, num);
                selectedTopicName = tools.CutPath(selectedTopic);
            }
            catch (Exception)
            {
                Console.WriteLine($"Что то не то");
                LangMenu();
            }

            Console.Write($"Вы выбрали тему {selectedTopicName}\n\n");

            dictionary = tools.FillDirtionary(selectedTopic);

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
                Console.WriteLine("Вводите только цифры цифры");
                LangMenu();
            }

        }
        private void StartRus()
        {
            Console.WriteLine("Выберете правильный вариант на иностранном");

            List<string> engSetFull = new List<string>();
            List<string> rusSetFull = new List<string>();
            Random rnd = new Random();

            foreach (var s in dictionary)    //Создаём два отдельных списка со значениями из словаря
            {
                rusSetFull.Add(s.Value);
                engSetFull.Add(s.Key);
            }

            string rus = rusSetFull[rnd.Next(rusSetFull.Count)]; 
            string rightAnswer = GetKeyByValue(rus);                //сопоставлению выбранному рандомному слову паре из словоря

            Console.WriteLine(rus);

            List<string> answers = new List<string>();              //создаем первый список, в котором есть одно правильное значение и 3 рандомных
            answers.Add(rightAnswer);
            for (int i=0; answers.Count!=4; i++)
            {
                string temp = engSetFull[rnd.Next(engSetFull.Count)];
                if(!answers.Contains(temp))
                {
                    answers.Add(temp);
                }                    
            }

            
            List<string> answersRand = new List<string>();          //список какждый раз наполняется в случайной последовательности значениями из предыдущего списка
            for (int i=0; answersRand.Count!=4; i++)
            {
                string temp = answers[rnd.Next(answers.Count)];
                if (!answersRand.Contains(temp))
                {
                    answersRand.Add(temp);
                }
            }

            for(int i=0; i<answersRand.Count;i++)
            {
                Console.WriteLine($"{i+1} - {answersRand[i]}");
            }

            int answer = int.Parse(Console.ReadLine());
            tools.CheckForMainMenu(answer);
            try
            {
                if (answersRand[answer - 1] == rightAnswer)
                {
                    Console.WriteLine("ПРАВИЛЬНО!!!!");
                    StartRus();
                }
                else
                {
                    Console.WriteLine($"Ответ не верный ({rightAnswer})");
                    StartRus();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Нет такого вариата ответа");
                StartRus();
            }
            catch(Exception)
            {
                Console.WriteLine("Что-то не то. Попробуй ещё раз");
                StartRus();
            }
           
        }
        private void StartEng()
        {
            Console.WriteLine("Выберете правильный вариант на иностранном");

            List<string> engSetFull = new List<string>();
            List<string> rusSetFull = new List<string>();
            Random rnd = new Random();

            foreach (var s in dictionary)    //Создаём два отдельных списка со значениями из словаря
            {
                rusSetFull.Add(s.Value);
                engSetFull.Add(s.Key);
            }

            string eng = engSetFull[rnd.Next(engSetFull.Count)];
            string rightAnswer = GetValueByKey(eng);

            Console.WriteLine(eng);

            List<string> answers = new List<string>();              //создаем первый список, в котором есть одно правильное значение и 3 рандомных
            answers.Add(rightAnswer);
            for (int i = 0; answers.Count != 4; i++)
            {
                string temp = rusSetFull[rnd.Next(rusSetFull.Count)];
                if (!answers.Contains(temp))
                {
                    answers.Add(temp);
                }
            }

            List<string> answersRand = new List<string>();          //список какждый раз наполняется в случайной последовательности значениями из предыдущего списка
            for (int i = 0; answersRand.Count != 4; i++)
            {
                string temp = answers[rnd.Next(answers.Count)];
                if (!answersRand.Contains(temp))
                {
                    answersRand.Add(temp);
                }
            }

            for (int i = 0; i < answersRand.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {answersRand[i]}");
            }

            int answer = int.Parse(Console.ReadLine());
            tools.CheckForMainMenu(answer);
            try
            {
                if (answersRand[answer - 1] == rightAnswer)
                {
                    Console.WriteLine("ПРАВИЛЬНО!!!!");
                    StartEng();
                }
                else
                {
                    Console.WriteLine($"Ответ не верный ({rightAnswer})");
                    StartEng();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Нет такого вариата ответа");
                StartEng();
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то не то. Попробуй ещё раз");
                StartEng();
            }


        }
        private string GetKeyByValue(string s)
        {
            foreach (var temp in dictionary)
            {
                if (temp.Value.Equals(s))
                    return temp.Key;
            }
            return null;
        }

        private string GetValueByKey(string s)
        {
            foreach (var temp in dictionary)
            {
                if (temp.Key.Equals(s))
                    return temp.Value;
            }
            return null;
        }
    }
}