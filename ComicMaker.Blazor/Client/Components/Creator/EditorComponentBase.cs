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
            
        public Collapser ShowImages { get; set; } = new Collapser();

        public Collapser ShowAudio { get; set; } = new Collapser();
    }
}
