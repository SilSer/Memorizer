using System;
using System.IO;
using System.Collections.Generic;

namespace Memorizer
{
    class Tools
    {
        public readonly string topicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Memorizer";



        public string[] GetTopicList()
        {
            string [] topicList = Directory.GetFiles(topicDir);
            for (int i = 0; i < topicList.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {CutPath(topicList[i])}");
            }
            Console.WriteLine("0 - Назад");
            return topicList;
        }
        public string SelectTopic(string[] topicList, int num)
        {
            string selectedTopic = topicList[num - 1];
            return selectedTopic;
        }           

        public void AddWordToFile(string path, string s1, string s2)
        {
            using StreamWriter write = new StreamWriter(path, true);
            write.WriteLine(s1 + "\t" + s2);
        }
        public string CutPath(string s)
        {
            s = Path.GetFileName(s[0..^4]);
            return s;
        }
        public string CheckForMainMenu(string s)
        {
            if ($"{s}" == "0")
            {
                new MainMenu().Menu();
            }
            return s;
        }
        public int CheckForMainMenu(int s)
        {
            if (s == 0)
            {
                new MainMenu().Menu();
            }
            return s;
        }
        public Dictionary<string, string> FillDirtionary(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                Dictionary<string, string> dictionaryTool=new Dictionary<string, string>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { '\t' });

                    dictionaryTool.Add(words[0], words[1]);
                }
                return dictionaryTool;
            }
        }

    }
}
