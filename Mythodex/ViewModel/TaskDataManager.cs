using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mythodex.ViewModel
{
    internal static class TaskDataManager
    {
        public static void SaveTaskCollection(ObservableCollection<Task> collection, DateTime date)
        {
            string fileName = Path.Combine(ApplicationPaths.DatesFolder, DateConverter.ConvertToSaveFormat(date));
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, collection);
            }
        }
        public static ObservableCollection<Task> LoadTaskCollection(DateTime date)
        {
            string fileName = Path.Combine(ApplicationPaths.DatesFolder, DateConverter.ConvertToSaveFormat(date));
            if (File.Exists(fileName))
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (ObservableCollection<Task>)formatter.Deserialize(stream);
                }
            }

            return new ObservableCollection<Task>();
        }
        private static void SaveObservableCollection(ObservableCollection<Task> collection, string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, collection);
            }
        }
    }
}
