using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicMaker.Blazor.Client.Messages
{
    public class DeleteConfirmationMessage
    {
        public DeleteConfirmationMessage(Action action) : this("Are you sure you want to delete this item?", action)
        {

        }

        public DeleteConfirmationMessage(string text, Action onSuccess)
        {
            Text = text;
            OnSuccess = onSuccess;
        }

        public string Text { get; private set; }
        public Action OnSuccess { get; private set; }
    }
}
