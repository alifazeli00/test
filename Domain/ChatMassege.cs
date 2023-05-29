using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChatMassege
    {
        public Guid  Id { get; set; }
        public string mesege { get; set; }
        public string Sender { get; set; }

        public DateTime Time { get; set; }

        public ChatRoms ChatRoms { get; set; }
        public Guid ChatRomsId { get; set; }  

    }
}
