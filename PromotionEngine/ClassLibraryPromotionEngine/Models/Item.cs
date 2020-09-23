using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPromotionEngine
{
  public class Item
  {
    public Item() { }
    public Item(Item item)
    {
      SKU_Id = item.SKU_Id;
      Quantity = item.Quantity;
    }

    public char SKU_Id { get; set; }
    public int Quantity { get; set; }
  }
}
