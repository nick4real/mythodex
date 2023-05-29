using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Mythodex.ViewModel
{
    internal static class TaskDataManager
    {
        public static void SaveTaskCollection(ObservableCollection<Task> collection, DateTime date)
        {
            string fileName = Path.Combine(ApplicationPaths.DatesFolder, DateConverter.ConvertToSaveFormat(date));

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Task>));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, collection);
            }
        }
        public static ObservableCollection<Task> LoadTaskCollection(DateTime date)
        {
            string fileName = Path.Combine(ApplicationPaths.DatesFolder, DateConverter.ConvertToSaveFormat(date));

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Task>));
                using (StreamReader reader = new StreamReader(fileName))
                {
                    return (ObservableCollection<Task>)serializer.Deserialize(reader);
                }
            }

            return new ObservableCollection<Task>();
        }
    }
}
