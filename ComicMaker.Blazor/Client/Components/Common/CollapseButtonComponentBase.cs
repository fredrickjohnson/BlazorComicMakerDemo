using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class CollapseButtonComponentBase : ComponentBase
    {
        [Parameter]
        public EventCallback Clicked { get; set; }

        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public Collapser Model { get; set; }

        protected void OnClick()
        {
            Clicked.InvokeAsync(Model);
        }
    }
}
