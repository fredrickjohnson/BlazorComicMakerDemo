using System.Collections.Generic;
using Blazored.Toast.Services;
using ComicMaker.Blazor.Shared.Common.Models;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class FeedbackComponentBase : ComponentBase
    {
        [Inject]
        protected IToastService ToastService { get; set; }

        protected bool Show { get; set; } = false;

        private OperationResult _model = new OperationResult();
        protected IList<ErrorMessage> Messages { get; set; } = new List<ErrorMessage>();

        public void Clear()
        {
            Messages.Clear();
            Show = false;
            StateHasChanged();
        }
        
        public void Process(OperationResult model)
        {
            Messages.Clear();
            foreach(var errorMessage in model.Errors)
            {
                switch (errorMessage.Code)
                {
                    case "Toast.Info":
                        ToastService.ShowInfo(errorMessage.Text);
                        break;
                    case "Toast.Success":
                        ToastService.ShowSuccess(errorMessage.Text);
                        break;
                    case "Toast.Error":
                        ToastService.ShowError(errorMessage.Text);
                        break;
                    case "Toast.Warning":
                        ToastService.ShowWarning(errorMessage.Text);
                        break;
                    default:
                        Messages.Add(errorMessage);
                        break;
                }
            }
            Show = true;
            StateHasChanged();
        }
    }
}
