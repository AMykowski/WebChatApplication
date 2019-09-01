using System.Collections.Generic;
using WebChat.Models;

namespace WebChat.ViewModels
{
    
    /// <summary>   A ViewModel for the conversation. </summary>
    ///
    /// <remarks>   Artur, 01/09/2019. </remarks>
    
    public class ConversationViewModel
    {

        /// <summary>   Gets or sets the current user. </summary>
        ///
        /// <value> The current user. </value>


        public string CurrentUser { get; set; }

        /// <summary>   Gets or sets the receiver user. </summary>
        ///
        /// <value> The receiver user. </value>


        public string ReceiverUser { get; set; }

       
        /// <summary>   Gets or sets the old messages. </summary>
        ///
        /// <value> The old messages. </value>


        public List<ChatMessage> OldMessages { get; set; }

    }
}