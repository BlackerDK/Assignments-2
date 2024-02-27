using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ModelsDbF
{
    public partial class Cart
    {
        public int Quality { get; set; }



        public virtual Product Product { get; set; } = null!;
    }
}
