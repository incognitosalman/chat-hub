using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Contracts.ExternalServices
{
    // These are the methods will be called on the client side
    public interface IChatHubClient
    {
        Task OnSendToAllAsync(string message);
        Task OnSendToCallerAsync(string message);
        Task OnSendToIndividualAsync(string message);
        Task OnSendToOthersAsync(string message);
        Task OnAddToGroupAsync(string group, string message);
        Task OnRemoveFromGroupAsync(string group, string message);
        Task OnSendToGroupAsync(string group, string message);
        Task OnUserConnectedAsync(string message);
        Task OnUserDisconnectedAsync(string message);
    }
}