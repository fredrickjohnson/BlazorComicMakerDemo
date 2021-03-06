﻿using System.ComponentModel.DataAnnotations;
using ComicMaker.Blazor.Client.Components.Common;
using ComicMaker.Blazor.Client.Extensions;
using ComicMaker.Blazor.Client.Services.Interfaces;
using ComicMaker.Blazor.Shared.Projects.Commands;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Projects
{
    public class ProjectUpdateComponentBase : EditorComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public void Save()
        {
            Validations.ValidateAll().OnSuccess(async () =>
            {
                Validations.ClearAll();
                Feedback.Clear();

                var option = await ProjectService.Update(new UpdateProjectCommand
                {
                    Name = Name,
                    Description = Description,
                });
                option.MatchSome(x =>
                {
                    ToastService.ShowSuccess("Updated Successfully");
                    Feedback.Process(x);
                });
                option.MatchNone(x => Feedback.Process(x));
            });
        }
    }
}