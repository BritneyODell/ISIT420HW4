//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISIT420HW4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int ordersID { get; set; }
        public int storeID { get; set; }
        public int salesPersonID { get; set; }
        public int cdID { get; set; }
        public int pricePaid { get; set; }
        public int dayPurch { get; set; }
        public int hourPurch { get; set; }
    
        public virtual CDTable CDTable { get; set; }
        public virtual SalesPersonTable SalesPersonTable { get; set; }
        public virtual StoreTable StoreTable { get; set; }
    }
}
