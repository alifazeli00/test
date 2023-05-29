using Application.HUb;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace EndPointOnlineShop.Hubs
{
    public class adminsaporttest:Hub
    {
        private readonly IChatAdmin chatAdmin;
        private readonly IHubContext<Client> ChatClient;

        public adminsaporttest(IChatAdmin ChatAdmin, IHubContext<Client> ChatClient)
        {
            this.ChatClient = ChatClient;
            chatAdmin = ChatAdmin;
        }
        public override async Task OnConnectedAsync()
        {
            var rooms = await chatAdmin.GetAlll();
            await Clients.Caller.SendAsync("GetRooms", rooms);
            await base.OnConnectedAsync();


        }


        public override Task OnDisconnectedAsync(Exception exception)
        {

            return base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessage(Guid roomId, string text)
        {

            MesegeDro x = new MesegeDro()
            {

                mesege = text,
                Time = DateTime.Now,
                Sender = Context.User.Identity.Name

            };
            await chatAdmin.SaveChatMasseges(roomId, x);
               await ChatClient.Clients.Group(roomId.ToString()).SendAsync("GetNewMasseg", x.Sender, x.mesege, x.Time);




        }


        public async Task LoadMessage(Guid Rommid)
        {
            var meage = await chatAdmin.GetMassege(Rommid);
            await Clients.Caller.SendAsync("GetMasseg", meage);


        }
    }
}
