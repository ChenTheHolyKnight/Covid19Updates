using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.Common
{
    public interface IDirectoryHelper
    {
        public List<string> GetFilePathsInDirectory(string dirPath);
        public List<string> GetFileNamesInDirectory(string dirPath);
    }
}
