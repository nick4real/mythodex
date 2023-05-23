using Mythodex.Model;
using LoremNET;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace Mythodex.ViewModel
{
    internal static class DragItemGenerator
    {
        public static DragItem Next()
        {
            return new DragItem { ItemName = Lorem.Sentence(8), ItemDescription = Lorem.Sentence(20), ItemValue = 19 };
        }
        public static ObservableCollection<DragItem> Next(int i)
        {
            var collection = new ObservableCollection<DragItem>();
            for (int j = 0; j < i; j++)
                collection.Add(Next());
            return collection;
        }
    }
}
