﻿using System;
using System.Collections.Generic;
using ComicMaker.Blazor.Client.Components.Common;
using ComicMaker.Blazor.Client.Factories;
using ComicMaker.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Projects
{
    public class ProjectDetailComponentBase : EditorComponentBase
    {
        public TabService Tabs = new TabServiceFactory()
            .AddTab("Scenes", "fas fa-home")
            .AddTab("Backgrounds","fas fa-users")
            .AddTab("Layouts", "fas fa-users")
            .AddTab("Characters", "fas fa-users")
            .Build();
            
        public Collapser ShowImages { get; set; } = new Collapser();

        public Collapser ShowAudio { get; set; } = new Collapser();

        public IList<string> Images { get; set; } = new List<string>
        {
            "",
            ""
        };

        public Graphic Test { get; set; } = new Graphic();

        public IList<string> Colors { get; set; } = new List<string>();

        protected void Preview()
        {

        }

        protected void Undo()
        {
            this.Test.X += 10;
            this.Test.Update();
        }

        protected void UTest()
        {
            Console.WriteLine("Hello World");
        }

        protected void Redo()
        {
            this.Test.X -= 10;
            this.Test.Update();
            //this.Test.Xs = this.Test.X + "px";
        }

        public bool EnableRedo { get; set; } = true;

        public bool EnableUndo { get; set; } = true;
    }
}
