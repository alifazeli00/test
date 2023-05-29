using Application.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HUb
{
    public interface IChatAdmin
    {

     Task<Guid> CreaatGrop(string CId);
        Task<Guid> GetGrope(string Cid);
        Task <List<Guid>> GetAlll();

        Task SaveChatMasseges(Guid RommId, MesegeDro Req);
        Task <List<MesegeDro>> GetMassege(Guid RommId);

    }
    public class ChatAdmin : IChatAdmin
    {
        private readonly IDataBaceContext context;
        public ChatAdmin(IDataBaceContext context)
        {
            this.context = context;
        }
        public async Task<Guid> CreaatGrop(string CId)
        {
            //"A0MTCCj4uzuoJj4aCa9C8A"
            var res = context.ChatRoms.SingleOrDefault(p=>p.ConectionId == CId);
            if (res != null)
            {
                return await Task.FromResult(res.Id);

            }


            ChatRoms x = new ChatRoms()
            {
                Id = Guid.NewGuid(),
                ConectionId = CId


            };
            context.ChatRoms.Add(x);
            context.SaveChanges();
            return await Task.FromResult(x.Id);
        }

        public async Task<List<Guid>>  GetAlll()
        {
            var res = context.ChatRoms.Include(p=>p.ChatMassege).Where(p=>p.ChatMassege.Any()).Select(p => p.Id).ToList();
            return await Task.FromResult(res);




        }

        public async Task<Guid> GetGrope(string Cid)
        {

            var res = context.ChatRoms.Include(p=>p.ChatMassege).SingleOrDefault(p => p.ConectionId == Cid);
            return await Task.FromResult(res.Id);

        }

        public Task<List<MesegeDro>> GetMassege(Guid RommId)
        {
            var res = context.ChatMassege.Where(p => p.ChatRomsId == RommId).Select(p => new MesegeDro
            {
                mesege = p.mesege,
                Sender = p.Sender,
                Time = p.Time


            }).OrderBy(p=>p.Time).ToList();
            return Task.FromResult(res);

        }

        public Task SaveChatMasseges(Guid RommId, MesegeDro Req)
        {
            var room = context.ChatRoms.SingleOrDefault(p => p.Id == RommId);

            ChatMassege x = new ChatMassege()
            {

                ChatRoms = room,
                mesege = Req.mesege,
                Sender = Req.Sender,
                Time = Req.Time,



            };
            context.ChatMassege.Add(x);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }


    public class MesegeDro
    {
        public string Sender { get; set; }
        public string mesege { get; set; }
        public DateTime Time { get; set; }
    }

    public class GetDto
    {


    }
}
