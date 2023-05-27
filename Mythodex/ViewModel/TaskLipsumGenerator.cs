using LoremNET;
using Mythodex.Model;
using System.Collections.ObjectModel;

namespace Mythodex.ViewModel
{
    internal static class TaskLipsumGenerator
    {
        public static Task Next()
        {
            return new Task { Title = Lorem.Sentence(8), Description = Lorem.Sentence(20), Priority = 3 };
        }
        public static ObservableCollection<Task> Next(int i)
        {
            var collection = new ObservableCollection<Task>();
            for (int j = 0; j < i; j++)
                collection.Add(Next());
            return collection;
        }
    }
}
