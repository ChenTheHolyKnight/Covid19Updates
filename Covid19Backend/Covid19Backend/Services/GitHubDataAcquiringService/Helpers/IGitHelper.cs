using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Services.GitHubDataAcquiringService.Helpers
{
    public interface IGitHelper
    {
        public void Clone();
        public void Pull();
    }
}
