using System;
using System.IO;

namespace Memorizer
{
    class NewTopic
    {
        private string topicName;
        public readonly string topicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Memorizer";

        public void Create()
        {
            Console.WriteLine("Введите название новой темы");
            topicName = Console.ReadLine()+".txt";
            DirectoryInfo dirInfo = new DirectoryInfo(topicDir);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            FileInfo fileInfo = new FileInfo(topicDir + "/" + topicName);
            if(!fileInfo.Exists)
            {
                fileInfo.Create();
            }
            else
            {
                Console.WriteLine("Тема с таким именем уже существует");
                this.Create();
            }
            if(dirInfo.Exists)
            {
                Console.WriteLine($"Тема {fileInfo.Name[0..^4]} успешно создана!");
            }
            new MainMenu().Menu();
        }
    }
}
