using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public abstract class ListComponentBase : ComponentBase
    {
        [Inject]
        protected IToastService ToastService { get; set; }

        public FeedbackComponent Feedback { get; set; }
    }
}