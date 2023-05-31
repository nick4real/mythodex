using Mythodex.Model;
using LoremNET;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Mythodex.ViewModel
{
    internal class ViewModelProjectTemplate : INotifyPropertyChanged
    {
        private ProjectDesk projectDesk;
        public ProjectDesk ProjectDesk
        {
            get { return projectDesk; }
            set
            {
                projectDesk = value;
                OnPropertyChanged(nameof(ProjectDesk));
            }
        }

        public ViewModelProjectTemplate()
        {
            ProjectDesk = new ProjectDesk();
            ProjectDesk.ColumnCollection = new ObservableCollection<Column>()
            {
                new Column()
                {
                    Name = TaskLipsumGenerator.NextString(),
                    TaskCollection = TaskLipsumGenerator.Next(3)
                },
                new Column()
                {
                    Name = TaskLipsumGenerator.NextString(),
                    TaskCollection = TaskLipsumGenerator.Next(3)
                },
                new Column()
                {
                    Name = TaskLipsumGenerator.NextString(),
                    TaskCollection = TaskLipsumGenerator.Next(3)
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
