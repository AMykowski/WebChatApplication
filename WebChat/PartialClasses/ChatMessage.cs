﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Repositories;

namespace WebChat.Models
{
    public partial class ChatMessage
    {
        /// <summary>
        /// Gets all messages directly from db
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static List<ChatMessage> GetMessages(DbConnector dc)
        {
            return dc.ChatMessageRepository.Get().ToList();
        }
    }
}