using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Contracts.ExternalServices;
using Infrastructure.ExternalServices.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.ExternalServices.HubServices
{
    public class ChatHubService : IChatHubService
    {
        private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;

        public ChatHubService(IHubContext<ChatHub, IChatHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task OnAddToGroupAsync(string group, string message)
        {
            throw new NotImplementedException();
        }

        public Task OnRemoveFromGroupAsync(string group, string message)
        {
            throw new NotImplementedException();
        }

        public Task OnSendToAllAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task OnSendToCallerAsync(string message)
        {
            throw new NotImplementedException();
        }

        public async Task OnSendToGroupAsync(string group, string message)
        {
            await _hubContext.Clients.Group(group)
                                     .OnSendToGroupAsync(group, message);
        }

        public Task OnSendToIndividualAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task OnSendToOthersAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task OnUserConnectedAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task OnUserDisconnectedAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}