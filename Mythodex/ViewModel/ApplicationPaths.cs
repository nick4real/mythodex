using System;
using System.IO;

namespace Mythodex.ViewModel
{
    internal static class ApplicationPaths
    {
        public static string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mythodex");
        public static string DatesFolder = Path.Combine(AppDataFolder, "Dates");
        public static string ProjectsFolder = Path.Combine(AppDataFolder, "Projects");
        public static void Check()
        {
            if (!Directory.Exists(AppDataFolder))
            {
                Directory.CreateDirectory(AppDataFolder);
            }

            if (!Directory.Exists(DatesFolder))
            {
                Directory.CreateDirectory(DatesFolder);
            }

            if (!Directory.Exists(ProjectsFolder))
            {
                Directory.CreateDirectory(ProjectsFolder);
            }
        }
    }
}
