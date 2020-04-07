using System.Collections.Generic;

namespace ComicMaker.Blazor.Client.Models
{
    public class TabService
    {
        public string SelectedTab { get; set; } = string.Empty;

        public IList<TabItem> Items { get; set; } = new List<TabItem>();

        public TabService()
        {
            
        }

        private void SetActive(TabItem item)
        {
            item.ButtonClass = "bg-white";
            item.IconClass = $"{item.Icon}";
            item.TextClass = "";
        }

        private void SetInActive(TabItem item)
        {
            item.ButtonClass = "";
            item.IconClass = $"{item.Icon} text-white";
            item.TextClass = "text-white";
        }

        public void OnSelected(TabItem selectedItem)
        {
            if (selectedItem == null) return;

            SelectedTab = selectedItem.Name;
            foreach (var item in Items)
            {
                if (item == selectedItem)
                {
                    SetActive(item);
                }
                else
                {
                    SetInActive(item);
                }
            }
        }
    }
}
