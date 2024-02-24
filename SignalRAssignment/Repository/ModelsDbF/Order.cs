using System;
using System.Collections.Generic;

namespace Repository.ModelsDbF;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime ShippedDate { get; set; }

    public string Freight { get; set; } = null!;

    public string ShipAddress { get; set; } = null!;

    public int CustomersCustomerId { get; set; }

    public virtual Customer CustomersCustomer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
