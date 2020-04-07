using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Models;
using ComicMaker.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class TabBarComponentBase : ComponentBase
    {
        [Parameter]
        public TabService Model { get; set; }
    }
}
