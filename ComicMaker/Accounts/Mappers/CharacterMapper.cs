using System.Collections.Generic;
using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Entities;
using ComicMaker.Projects.Models;
using Newtonsoft.Json;

namespace ComicMaker.Accounts.Mappers
{
    public class CharacterMapper
    {
        public static Character Map(CharacterEntity source)
        {
            return new Character
            {
                Id = source.RowKey,
                Name = source.Name,
                Description = source.Description,
                Width = source.Width,
                Height = source.Height,
                Parts = JsonConvert.DeserializeObject<IList<Part>>(source.PartsAsString)
            };
        }

        public CharacterEntity Map(CreateCharacterCommand source)
        {
            var destination = new CharacterEntity
            {
                Name = source.Name,
                Description = source.Description
            };
            return destination;
        }

        public CharacterEntity Map(UpdateCharacterCommand source, CharacterEntity destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            return destination;
        }
    }
}