using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class MessageToGroupRequest
    {
        public string group { get; set; }
        public string message { get; set; }

        public MessageToGroupRequest(string _group, string _message)
        {
            group = _group;
            message = _message;
        }
    }
}