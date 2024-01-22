using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somnio.DTO
{
    public class PurchaseHistory
    {
        public virtual int Id { get; set; }
        public virtual int NumberOfItems { get; set; }
        public virtual decimal TotalCost { get; set; }
        public virtual DateTime Date { get; set; }
    }
}