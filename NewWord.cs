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

        public void AddWord()
        {
            
            
            Console.WriteLine("Выберете номер темы, в которую хотите добавить слово");
            topicList = Directory.GetFiles(dirPath);
            for (int i = 0; i < topicList.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {CutPath(topicList[i])}");
            }
            Console.WriteLine("0 - Назад");
            try
            {
                int temp = int.Parse(Console.ReadLine());
                if (temp == 0)
                {
                    new MainMenu().Menu();
                }
                selectedTopic = topicList[temp - 1];

            }
            catch (FormatException)
            {
                Console.WriteLine("Введите только номер");
                this.AddWord();
            }
            Console.WriteLine($"Вы выбрали тему {CutPath(selectedTopic)}");

           
            Console.WriteLine("Введите иносстранное слово:      (0 - Назад)");
            engWord = Console.ReadLine();
            Check(engWord);
            Console.WriteLine("Введите его русский перевод      (0 - Назад)");
            rusWord = Console.ReadLine();
            Check(rusWord);

            using (StreamWriter write = new StreamWriter(selectedTopic, true))
            {
                write.WriteLine(engWord + "\t" + rusWord);
            }
            this.AddWord();
                
           
        }
        private string CutPath(string s)
        {
            s = Path.GetFileName(s.Substring(0, s.Length - 4));
            return s;
        }

        private string Check(string s)
        {
            if ($"{s}"=="0")
            {
                new MainMenu().Menu();
            }
            return s;
        }
    }
}
