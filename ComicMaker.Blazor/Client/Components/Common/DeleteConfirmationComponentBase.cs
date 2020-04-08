using Blazorise;
using ComicMaker.Blazor.Client.Messages;
using Microsoft.AspNetCore.Components;

namespace ComicMaker.Blazor.Client.Components.Common
{
    public class DeleteConfirmationComponentBase : ComponentBase
    {
        private DeleteConfirmationMessage _model;
        protected Modal Modal { get; set; }
        protected string Text { get; set; }
        protected void Yes()
        {
            HideModal();
            _model?.OnSuccess();
        }
        protected void No()
        {
           HideModal();
        }

        protected void HideModal()
        {
            Modal.Hide();
        }

        public void Execute(DeleteConfirmationMessage message)
        {
            _model = message;
            Text = message.Text;
            Modal.Show();
        }
    }
}