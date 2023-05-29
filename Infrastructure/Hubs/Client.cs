using Application.HUb;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    
    public class Client : Hub
    {

        private readonly IChatAdmin chatAdmin;
        public Client(IChatAdmin chatAdmin)
        {

            this.chatAdmin = chatAdmin;
        }

        // metod haii samt client inja daryaft mishan va mishse jabab dad 
        // dis va diss bazi

        public async Task joinRoom(Guid RommId)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, RommId.ToString());

        }


        public async Task LeaveRoom(Guid RoomId)
        {


            await Groups.RemoveFromGroupAsync(Context.ConnectionId, RoomId.ToString());
        }


        public async Task SendNewMessage(string Sender, string Message)
        {
            //     var roomId = await chatAdmin.GetGrope(Context.ConnectionId);
            MesegeDro x = new MesegeDro()
            {

                mesege = Message,
                Sender = Sender,
                Time = DateTime.Now
            };
            var s = Context.ConnectionId;
            var d = await chatAdmin.GetGrope(s);
            await chatAdmin.SaveChatMasseges(d, x);
            await Clients.Groups(d.ToString()).SendAsync("GetNewMasseg", x.Sender, x.mesege, x.Time.ToShortDateString());


            //  await Clients.All.SendAsync("GetMasseg", Sender, Message,DateTime.Now.ToShortDateString());


        }
        public override async Task OnConnectedAsync()
        {

            if (Context.User.Identity.IsAuthenticated)
            {
                await base.OnConnectedAsync();
                return;
            };
            var s = Context.ConnectionId;
            var d = await chatAdmin.CreaatGrop(s);
            await Groups.AddToGroupAsync(s, d.ToString());
            await Clients.Caller.SendAsync("GetNewMasseg", "poshiban", "vaaazzz  0_o=0_o");

            //      await Clients.Caller.SendAsync("GetMasseg", "Admin", " ssalam vazzet");
            await base.OnConnectedAsync();
            //   await  return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            return base.OnDisconnectedAsync(exception);
        }




    }
}
