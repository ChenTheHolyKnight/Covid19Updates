using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.GitHubDataAcquiringService.Helpers
{
    public class GitHelper:IGitHelper
    {
        private const string REPO_URL = "https://github.com/CSSEGISandData/COVID-19.git";
        private const string DATA_LOCATION = @"./Data";
        public void Clone()
        {
            if (IsDirectoryEmpty())
                Repository.Clone(REPO_URL, DATA_LOCATION);
        }

        public void Pull()
        {

        }

        private bool IsDirectoryEmpty()
        {
            return !Directory.EnumerateFileSystemEntries(DATA_LOCATION).Any();
        }
    }
}
