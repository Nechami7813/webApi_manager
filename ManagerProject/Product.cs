using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProject;

internal class Product
{
    public int ProdId { get; set; } = 0;
    public string ProdName { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
}
