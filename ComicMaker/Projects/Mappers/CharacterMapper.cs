using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Entities;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Entities;
using ComicMaker.Projects.Models;
using ComicMaker.Projects.Services.Interfaces;
using Newtonsoft.Json;

namespace ComicMaker.Projects.Mappers
{
    public class CharacterMapper
    {
        private readonly IProjectPartitionKeyGenerator _partitionKeyGenerator;

        public CharacterMapper(IProjectPartitionKeyGenerator partitionKeyGenerator)
        {
            _partitionKeyGenerator = partitionKeyGenerator;
        }

        public static Character Map(CharacterEntity source)
        {
            return new Character
            {
                Id = source.RowKey,
                Name = source.Name,
                Description = source.Description,
            };
        }

        public CharacterEntity Map(CreateCharacterCommand source)
        {
            var destination = new CharacterEntity
            {
                ProjectId = source.ProjectId,
                AccountId = source.Credentials.AccountId,
                Name = source.Name,
                Description = source.Description
            };
            return destination;
        }

        public CharacterEntity Map(UpdateCharacterCommand source, CharacterEntity destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.PartsAsString = JsonConvert.SerializeObject(source.Parts);
            return destination;
        }
    }
}