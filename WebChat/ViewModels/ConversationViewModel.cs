using System.Collections.Generic;
using WebChat.Models;

namespace WebChat.ViewModels
{
    public class ConversationViewModel
    {
        

        public string CurrentUser { get; set; }

        public string ReceiverUser { get; set; }

        public List<ChatMessage> OldMessages { get; set; }

    }
}