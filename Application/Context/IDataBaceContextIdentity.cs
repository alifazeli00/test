using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Context
{
    public interface IDataBaceContextIdentity
    {
        /// in ja user mizani chon to peymnet behesh niaz diry
        
        DbSet<User>Users { get; set; }
        //nemikhad to  impelimnetesh piadesazish koni chon khodsh piade sazi shode  
        //chon az IDENTITYDbcontext<User> inja khodesh piade shode
    }
}
