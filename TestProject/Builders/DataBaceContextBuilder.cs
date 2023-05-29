using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Builders
{
    public class DataBaceContextBuilder
    {
        internal DataBaceContext GetdbContext()
        {
            var Optioin = new DbContextOptionsBuilder<DataBaceContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;


            return new DataBaceContext(Optioin);
        }
    }
}
