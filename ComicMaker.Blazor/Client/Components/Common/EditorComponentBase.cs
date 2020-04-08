using Blazored.Toast.Services;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public abstract class EditorComponentBase : ComponentBase
    {
        [Inject]
        public IToastService ToastService { get; set; }

        public FeedbackComponent Feedback { get; set; }

        public Validations Validations { get; set; }
    }
}