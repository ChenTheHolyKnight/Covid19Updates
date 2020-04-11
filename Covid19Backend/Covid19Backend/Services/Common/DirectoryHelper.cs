using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Common
{
    public class DirectoryHelper: IDirectoryHelper
    {
        public List<string> GetFilePathsInDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return new List<string>();
            return Directory.GetFiles(dirPath).ToList();
        }

        public List<string> GetFileNamesInDirectory(string dirPath)
        {
            List<string> filePaths = GetFilePathsInDirectory(dirPath);
            filePaths = filePaths.Select(path => Path.GetFileName(path)).ToList();

            return filePaths;
        }

        
    }
}
