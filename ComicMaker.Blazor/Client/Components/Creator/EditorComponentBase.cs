using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Creator
{
    public class EditorComponentBase : ComponentBase
    {

        public bool ShowImages { get; set; } = true;

        public bool ShowAudio { get; set; } = false;
    }
}
