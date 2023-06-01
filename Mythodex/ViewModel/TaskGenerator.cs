using LoremNET;
using Mythodex.Model;
using System.Collections.ObjectModel;

namespace Mythodex.ViewModel
{
    internal static class TaskGenerator
    {
        public static Task Next()
        {
            return new Task { Title = "Загаловок", Description = "Описание", Priority = 1 };
        }
        public static ObservableCollection<Task> Next(int i)
        {
            var collection = new ObservableCollection<Task>();
            for (int j = 0; j < i; j++)
                collection.Add(Next());
            return collection;
        }
        public static string NextString()
        {
            return Lorem.Sentence(12);
        }
    }
}
