using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProject;

internal class OrderItem
{
    public int OrderItemId { get; set; }
    public int ProdId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
}
