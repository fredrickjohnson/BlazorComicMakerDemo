using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class LoadingComponentBase : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }
    }
}
