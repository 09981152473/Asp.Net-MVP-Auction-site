//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal_aukcyjny.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetComments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int AuctionId { get; set; }
    
        public virtual AspNetAuctions AspNetAuctions { get; set; }
    }
}
