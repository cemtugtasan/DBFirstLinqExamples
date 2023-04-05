using System;
using System.Collections.Generic;

namespace Dbfirst_northwind.Model;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
