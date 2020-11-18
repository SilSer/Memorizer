using System;
using System.Collections.Generic;
using System.IO;

namespace Memorizer
{
    class NewWord
    {
        private string engWord;
        private string rusWord;
        private string selectedTopic;
        private readonly string dirPath = new NewTopic().topicDir;
        private string[] topicList;

        public void Add()
        {
            Console.WriteLine("Выберете номер темы, в которую хотите добавить слово");
            topicList = Directory.GetFiles(dirPath);
            for (int i = 0; i< topicList.Length; i++ )
            {                
                Console.WriteLine($"{i + 1} - {CutPath(topicList[i])}");
            }

            try
            {
                int temp = int.Parse(Console.ReadLine());
                selectedTopic = topicList[temp - 1];

            }
            catch(FormatException)
            {
                Console.WriteLine("Введите только номер");
                this.Add();
            }
            Console.WriteLine($"Вы выбрали тему {CutPath(selectedTopic)}");
            Console.WriteLine("Ввежите иносстранное слово:");
            engWord = Console.ReadLine();
            Console.WriteLine("Введите его русский перевод");
            rusWord = Console.ReadLine();

            using(StreamWriter write = new StreamWriter(selectedTopic, true))
            {
                write.WriteLine(engWord + "\t" + rusWord);
            }
            Console.ReadKey();
        }
        private string CutPath(string s)
        {
            s = Path.GetFileName(s.Substring(0, s.Length - 4));
            return s;
        }
    }
}
