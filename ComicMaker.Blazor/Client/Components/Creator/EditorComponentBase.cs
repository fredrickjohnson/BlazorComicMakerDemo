using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Creator
{
    public class EditorComponentBase : ComponentBase
    {
        public TabService Tabs = new TabServiceFactory()
            .AddTab("Assets","fas fa-photo-video")
            .AddTab("Tests","fas fa-photo-video")
            .AddTab("Dragons","fas fa-photo-video")
            .Build();
            
        public bool ShowImages { get; set; } = true;

        public bool ShowAudio { get; set; } = false;
    }
}
