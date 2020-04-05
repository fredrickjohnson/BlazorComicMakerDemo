using System.Collections.Generic;
using ComicMaker.Projects.Models;

namespace ComicMaker.Projects.Data.Interfaces
{
    public interface IProjectQueryRepository
    {
        IEnumerable<ProjectSummary> GetAllForAccount(string accountId);
    }
}