using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class CollapseButtonComponentBase : ComponentBase
    {
        [Parameter]
        public string Class { get; set; }

        [Parameter]
        public EventCallback Clicked { get; set; }

        [Parameter]
        public bool Toggle { get; set; }

        protected void OnClick()
        {
            Clicked.InvokeAsync(Toggle);
        }
    }
}
