using System;
using System.Collections.Generic;

namespace Repository.ModelsDbF;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public int OrdersOrderId { get; set; }

    public int ProductsProductId { get; set; }

    public virtual Order OrdersOrder { get; set; } = null!;

    public virtual Product ProductsProduct { get; set; } = null!;
}
