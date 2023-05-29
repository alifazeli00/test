using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Peyment
    {
        public Guid Id { get; set; }
        public int Amount { get;  set; }
        public bool IsPay { get;  set; } = false;
        public DateTime? DatePay { get;  set; } = null;
        public string Authority { get;  set; }
        public long RefId { get;  set; } = 0;
        public Order Order { get;  set; }
        public int OrderId { get;  set; }
    }
}
