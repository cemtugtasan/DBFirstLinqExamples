using System;
using System.Collections.Generic;

namespace Dbfirst_northwind.Model;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
