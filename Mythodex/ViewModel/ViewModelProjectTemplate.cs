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
using System.Windows.Threading;

namespace Mythodex.ViewModel
{
    internal class ViewModelProjectTemplate : INotifyPropertyChanged
    {
        private DispatcherTimer timer;
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

        public ViewModelProjectTemplate(string projectName)
        {
            ProjectDesk = TaskDataManager.LoadProjectFile(projectName);
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;

            void Timer_Tick(object sender, EventArgs e)
            {
                TaskDataManager.SaveProjectFile(ProjectDesk, projectName);
            }

            timer.Start();
        }

        public void Clearup()
        {
            timer.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
