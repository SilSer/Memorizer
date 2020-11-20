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
        private string[] topicList;
        private string selectedTopicName;


        public void AddWord()
        {
            Tools tools = new Tools();
            
            Console.WriteLine("Выберете номер темы, в которую хотите добавить слово");
            try
            {
                topicList=tools.GetTopicList();

                int num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    new MainMenu().Menu();
                }

                selectedTopic = tools.SelectTopic(topicList, num);
                selectedTopicName = tools.CutPath(selectedTopic);
            }
            catch (Exception)
            {
                Console.WriteLine($"Что то не то");
                AddWord();
            }

            Console.Write($"Вы выбрали тему {selectedTopicName}\n\n");

            AddToFile();
        } 
        private void AddToFile()
        {
            Tools tools = new Tools();

            Console.WriteLine("Введите иносстранное слово:      (0 - Назад)");
            engWord = Console.ReadLine();
            tools.CheckForMainMenu(engWord);

            Console.WriteLine("Введите его русский перевод      (0 - Назад)");
            rusWord = Console.ReadLine();
            tools.CheckForMainMenu(rusWord);

            tools.AddWordToFile(selectedTopic, engWord, rusWord);

            AddToFile();
        }

            
                
           
        
        

        
    }
}
