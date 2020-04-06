using ComicMaker.Common.Commands;
using ComicMaker.Common.Services.Implementations;

namespace ComicMaker.Accounts.Commands
{
    public class CreateCharacterCommand : CommandQueryBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; } = IdFactory.Empty();
    }
}