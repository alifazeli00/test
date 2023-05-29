using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChatRoms
    {
        public Guid  Id { get; set; }
        public string ConectionId { get; set; }    
        public ICollection<ChatMassege> ChatMassege { get; set; }

    }
}
