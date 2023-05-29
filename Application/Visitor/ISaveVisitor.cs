using Application.Context;
using Domain.Visitors;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Visitor
{
    public interface ISaveVisitor
    {

        void Execute(VisitorDto Req);

    }
    public class SaveVisitor : ISaveVisitor
    {
        private readonly IMongoDbContext<Visitorr> _mongoDbContext;
        private readonly IMongoCollection<Visitorr> _visitorMongoCollection;
        public SaveVisitor(IMongoDbContext<Visitorr> _mongoDbContex)
        {
           this._mongoDbContext= _mongoDbContex;
            _visitorMongoCollection = _mongoDbContext.GetCollection();

        }

        public void Execute(VisitorDto Req)
        {


            _visitorMongoCollection.InsertOne(new Visitorr
            {

                CurrentLink = Req.CurrentLink,
                Ip = Req.Ip,
                Time = Req.Time,
                VisitorId = Req.VisitorId, // bara in ke befahmim vaghti to chanta ssafaae reaft kare yek nafar bode masna
                ReferrerLink = Req.ReferrerLink
            });




        }
    }
    public class VisitorDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }  // link jari onike dakheleshe
        public string ReferrerLink { get; set; }                                    // ;az koja moaade on linqesh mikhim


        public string PhysicalPath { get; set; }   // contoroler acction

        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }

}
