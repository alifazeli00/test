using Application.HUb;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
   

    public class Suport : Hub
    {
        private readonly IChatAdmin chatAdmin;
        private readonly IHubContext<Client> Client;

        public Suport(IChatAdmin chatAdmin, IHubContext<Client> Client)
        {
            this.Client = Client;
            this.chatAdmin = chatAdmin;
        }
        public override async Task OnConnectedAsync()
        {
            var rooms = await chatAdmin.GetAlll();
            await Clients.Caller.SendAsync("GetRooms", rooms);
            await Client.Clients.All.SendAsync("GetNewMasseg", "poshiban", "vaaazzz  0_o=0_o");
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
            //   await ChatClient.Clients.Group(roomId.ToString()).SendAsync("GetNewMasseg", x.Sender, x.mesege, x.Time);


            await Client.Clients.Group(roomId.ToString()).SendAsync("GetNewMasseg", x.Sender, x.mesege, x.Time);

            await Clients.All.SendAsync("GetNewMasseg", "s", "s", DateTime.Now.ToString());

            await Client.Clients.All.SendAsync("GetNewMasseg", "s", "s", DateTime.Now.ToString());
            await Client.Clients.All.SendAsync("GetNewMasseg", "poshiban", "vaaazzz  0_o=0_o");

        }


        public async Task LoadMessage(Guid Rommid)
        {
            var meage = await chatAdmin.GetMassege(Rommid);
            await Clients.Caller.SendAsync("GetMasseg", meage);


        }

    }
}
