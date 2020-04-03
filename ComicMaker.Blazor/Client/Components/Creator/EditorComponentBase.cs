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
            .AddTab("Home", "fas fa-home")
            .AddTab("Variables","fas fa-times")
            .AddTab("Props", "fas fa-couch")
            .AddTab("Characters","fas fa-users")
            .AddTab("Interactions", "fas fa-scroll")
            .Build();
            
        public Collapser ShowImages { get; set; } = new Collapser();

        public Collapser ShowAudio { get; set; } = new Collapser();

        protected void Preview()
        {

        }

        protected void Undo()
        {

        }

        protected void Redo()
        {

        }

        public bool EnableRedo { get; set; } = true;

        public bool EnableUndo { get; set; } = true;
    }
}
