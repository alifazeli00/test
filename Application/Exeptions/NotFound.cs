using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exeptions
{
    public class NotFound:Exception
    {
        public NotFound(String Name, object key) :
        base($"entity{Name} ba  in {key}  peyda nshod." ) 
        {


        }
        public NotFound(String Name) :
        base($"entity{Name} ba    peyda nshod.")
        {

        }
    }
}
