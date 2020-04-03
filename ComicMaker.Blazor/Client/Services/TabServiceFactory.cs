using System.Linq;

namespace ComicMaker.Blazor.Client.Services
{
    public class TabServiceFactory
    {
        private readonly TabService _model = new TabService();
        public TabServiceFactory AddTab(string name, string icon)
        {
            _model.Items.Add(new TabItem { Icon = icon, Name = name });
            return this;
        }
        public TabService Build()
        {
            _model.OnSelected(_model.Items.FirstOrDefault());
            return _model;
        }
    }
}