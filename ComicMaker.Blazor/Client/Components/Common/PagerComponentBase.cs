using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Models;
using ComicMaker.Blazor.Shared.Common.Models;
using Microsoft.AspNetCore.Components;
using Optional.Collections;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class PagerComponentBase : ComponentBase
    {
        private PagedResult _model = new PagedResult();
        private int _prevPage = 1;
        private int _nextPage = 1;

        [Parameter]
        public EventCallback<int> OnPage { get; set; }

        [Parameter]
        public PagedResult Model
        {
            set => ModelToView(value);
            get => _model;
        }

        protected bool HasNext { get; set; } = true;
        protected bool HasPrev { get; set; } = false;
        public PageItemModel SelectedPage { get; set; } = null;
        protected IList<PageItemModel> Pages { get; set; } = new List<PageItemModel>();
        

        private void ModelToView(PagedResult model)
        {
            _model = model;
            if (model.TotalItems == 0)
            {
                _prevPage = 1;
                _nextPage = 1;
                HasPrev = false;
                HasNext = false;
                Pages = new List<PageItemModel>();
            }
            else
            {
                _prevPage = Math.Clamp(model.CurrentPage - 1, 1, model.TotalPages);
                _nextPage = Math.Clamp(model.CurrentPage + 1, 1, model.TotalPages);
                var startPage = model.CurrentPage - 2;
                var endPage = model.CurrentPage + 2;
                if (startPage <= 0)
                {
                    endPage -= startPage - 1;
                    startPage = 1;
                }

                if (endPage > model.TotalPages)
                {
                    endPage = model.TotalPages;
                    if (endPage > 5)
                    {
                        startPage = endPage - 4;
                    }
                }


                HasPrev = model.CurrentPage > 1;
                HasNext = model.CurrentPage < model.TotalPages;

                var list = new List<PageItemModel>();
                for (var i = startPage; i <= endPage; i++)
                {
                    list.Add(new PageItemModel(i));
                }

                Pages = list;
                Pages.FirstOrNone(x => x.Page == model.CurrentPage).MatchSome(x => { SelectedPage = x; });
            }
        }

        protected async Task Next()
        {
            await OnPage.InvokeAsync(_nextPage);
        }

        protected async Task Test(PageItemModel value)
        {
            await OnPage.InvokeAsync(value.Page);
        }

        protected async Task Prev()
        {
            await OnPage.InvokeAsync(_prevPage);
        }
    }
}
