﻿using System.Collections.Generic;
using System.Text;
using ComicMaker.Common.Entities;
using ComicMaker.Common.Models;
using ComicMaker.Common.Services.Implementations;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Entities
{
    public class CharacterEntity : TableEntity, IAccountEntity
    {
        public string AccountId { get; set; } = IdFactory.Empty();
        public string ProjectId { get; set; } = IdFactory.Empty();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PartsAsString { get; set; } = List.Empty();
    }
}
