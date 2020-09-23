using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPromotionEngine
{
  public class Engine
  {
    private IEnumerable<SKU_Price> priceList;
    private IEnumerable<Promotion> promotions;

    public Engine(IEnumerable<SKU_Price> priceList, IEnumerable<Promotion> promotions)
    {
      this.priceList = priceList;
      this.promotions = promotions;
    }

    public void CheckOut(Order order)
    {
      throw new NotImplementedException();
    }
  }
}
