using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using ComicMaker.Blazor.Client.Components.Common;
using ComicMaker.Blazor.Client.Messages;
using ComicMaker.Blazor.Client.Services.Interfaces;
using ComicMaker.Blazor.Shared.Common.Commands;
using ComicMaker.Blazor.Shared.Common.Models;
using ComicMaker.Blazor.Shared.Common.Queries;
using ComicMaker.Blazor.Shared.Projects.Models;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Projects
{
    public class ProjectListComponentBase : ListComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IProjectService ProjectService { get; set; }

        public DeleteConfirmationComponent DeleteConfirmation { get; set; }

        [Parameter]
        public IList<ProjectSummary> Items { get; set; } = new List<ProjectSummary>();

        public bool IsLoading { get; set; } = false;

        public Modal CreateModal { get; set; }
        
        public void ShowCreate()
        {
            CreateModal.Show();
        }

        public void HideCreate()
        {
            CreateModal.Hide();
        }

        protected void LoadByItem(ProjectSummary model)
        {
            NavigationManager.NavigateTo($"project/{model.Id}");
        }

        protected void DeleteById(string id)
        {
            DeleteConfirmation.Execute(new DeleteConfirmationMessage(async () =>
            {
                var option = await ProjectService.Delete(new DeleteByIdCommand(id));
                option.MatchSome(async x =>
                {
                    ToastService.ShowSuccess("Deleted Successfully");
                    //Feedback.Process(x);
                    Items.Remove(Items.FirstOrDefault(item => item.Id == id));
                });
                option.MatchNone(x => { Feedback.Process(x); });
                StateHasChanged();
            }));
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadList();
            await base.OnInitializedAsync();
        }


        protected async Task LoadList()
        {
            Console.WriteLine("Loading....");
            IsLoading = true;
            var option = await ProjectService.GetList(new GetListQuery());
            option.MatchSome(x =>
            {
                Items = x;
                IsLoading = false;
            });
            option.MatchNone(x =>
            {
                IsLoading = false;
                Feedback.Process(x);
            });
        }
    }
}