using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Archivizor_Project.Classes
{
    public class Info
    {
        public static List<String> GetInformation(String itemPath, bool isFile, bool isFolder, bool isDrive)
        {
            if (isFile)
            {
                //getting info of a file
                FileInfo fileInfo = new FileInfo(itemPath);
                List<String> fileList = new List<String>();
                fileList.Add(fileInfo.Name);
                fileList.Add(fileInfo.FullName);
                fileList.Add(fileInfo.Length.ToString() + " bytes");
                fileList.Add(fileInfo.CreationTime.ToString());
                fileList.Add(fileInfo.LastWriteTime.ToString());
                fileList.Add(fileInfo.Attributes.ToString());
                return fileList;
            }
            else if(isFolder)
            {
                //getting info of a directory
                DirectoryInfo dirInfo = new DirectoryInfo(itemPath);
                List<String> dirList = new List<String>();
                dirList.Add(dirInfo.Name);
                dirList.Add(dirInfo.FullName);
                dirList.Add(DirSize(dirInfo) + " bytes");
                dirList.Add(dirInfo.CreationTime.ToString());
                dirList.Add(dirInfo.LastWriteTime.ToString());
                dirList.Add(dirInfo.Attributes.ToString());
                return dirList;
            }
            else
            {
                //getting info of a logical drive
                DriveInfo driveInfo = new DriveInfo(itemPath);
                List<String> driveList = new List<String>();
                driveList.Add(driveInfo.Name);
                driveList.Add(driveInfo.Name);
                driveList.Add(driveInfo.TotalSize.ToString() + " bytes");
                driveList.Add(String.Empty);
                driveList.Add(String.Empty);
                driveList.Add(String.Empty);
                return driveList;
            }
        }

        //this function gets the size of a directory
        private static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }
    }
}
