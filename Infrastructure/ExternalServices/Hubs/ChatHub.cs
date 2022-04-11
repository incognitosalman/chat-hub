using Application.Common.Contracts.ExternalServices;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ExternalServices.Hubs
{
    public class ChatHub : Hub<IChatHubClient>
    {
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public async Task SendToAll(string message)
        {
            //TODO: Add your code here

            await Clients.All.OnSendToAllAsync(message);
        }

        public async Task SendToIndividual(string connectionId, string message)
        {
            //TODO: Add your code here

            await Clients.Client(connectionId).OnSendToIndividualAsync(message);
        }
        public async Task SendToCaller(string message)
        {
            //TODO: Add your code here

            await Clients.Caller.OnSendToCallerAsync(message);
        }

        public async Task SendToOthers(string message)
        {
            //TODO: Add your code here

            await Clients.Others.OnSendToOthersAsync(message);
        }

        public async Task AddToGroup(string groupName)
        {
            //TODO: Add your code here

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.OnAddToGroupAsync(groupName, $"User {Context.ConnectionId} added to group {groupName}");
            await Clients.Others.OnSendToOthersAsync($"User {Context.ConnectionId} added to group {groupName}");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            //TODO: Add your code here

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.OnRemoveFromGroupAsync(groupName, $"User {Context.ConnectionId} removed from group {groupName}");
            await Clients.Others.OnSendToOthersAsync($"User {Context.ConnectionId} removed from group {groupName}");
        }

        public async Task SendToGroup(string groupName, string message)
        {
            //TODO: Add your code here

            await Clients.Group(groupName).OnSendToGroupAsync(groupName, message);
        }

        public override Task OnConnectedAsync()
        {
            //TODO: Add your code here

            _logger.LogInformation($"User {Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //TODO: Add your code here

            _logger.LogInformation($"User {Context.ConnectionId} disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}