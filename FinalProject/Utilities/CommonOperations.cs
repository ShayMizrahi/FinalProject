
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using System;
using System.IO;


namespace FinalProject.Utilities
{
    [SetUpFixture]
    public class CommonOperations
    {

        // Path to working directory for the current project
        public static string workingDirectory = Environment.CurrentDirectory;
        // Path to primary 'Finalproject' folder of the current project
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // Report folder name
        public static string ReportFolderName = "Reporting "
            + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + @"\";
        // Path to report folder
        public static string ReportFolderPath = projectDirectory + @"\ExtentReport\";
        // Screenshot folder name
        public static string ScreenshotFolderName = @"Screenshot\";
        // Path to Screenshot folder
        public static string ScreenshotFolderPath = ReportFolderPath + ReportFolderName;

        public ConfigurationDrivers config;

        [OneTimeSetUp]
        public void BeforTests()
        {
            CreatNewFolder(projectDirectory, "ExtentReport");
            CreatNewFolder(ReportFolderPath, ReportFolderName);
            CreatNewFolder(ScreenshotFolderPath, ScreenshotFolderName);
            IReportMng.IReporter.InitReport();
        }


        [OneTimeTearDown]
        public void AfterAllTests()
        {
            IReportMng.IReporter.CloseReport();
        }

        /// <summary>
        /// Creat new folder if not exist
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FolderName"></param>
        public static void CreatNewFolder(string Path, string FolderName)
        {
            if (!Directory.Exists(Path + FolderName))
            {
                Directory.CreateDirectory(Path + FolderName);
            }
        }

    }

}

