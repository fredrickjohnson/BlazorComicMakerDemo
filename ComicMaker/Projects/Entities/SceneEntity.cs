using ComicMaker.Common.Entities;
using ComicMaker.Common.Models;
using ComicMaker.Common.Services.Implementations;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Entities
{
    public class SceneEntity : TableEntity, IAccountEntity
    {
        public string ProjectId { get; set; } = IdFactory.Empty();
        public string AccountId { get; set; } = IdFactory.Empty();
        public string Name { get; set; } = string.Empty;
        public string TopText { get; set; } = string.Empty;
        public string BottomText { get; set; } = string.Empty;
        public int TopRows { get; set; } = 0;
        public int BottomRows { get; set; } = 0;
        public string Background { get; set; } = string.Empty;

        public string ElementsAsString = List.Empty();
    }
}