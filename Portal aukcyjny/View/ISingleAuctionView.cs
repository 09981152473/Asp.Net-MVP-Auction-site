using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_aukcyjny.View
{
    public interface ISingleAuctionView
    {
        string txtname { get; set; }
        string txtemail { get; set; }
        string txtcomment { get; set; }
    }
}
