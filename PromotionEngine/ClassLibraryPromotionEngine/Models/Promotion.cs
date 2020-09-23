using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPromotionEngine
{
  public class Promotion : Order
  {
    public IEnumerable<Item> Validate(Order order, IEnumerable<Item> validatedItems)
    {
      var foundItems = new List<Item>();
      if (Items == null || Items.Count < 1)
        return foundItems;

      foreach (var promotionItem in Items)
      {
        var foundItem = validatedItems.FirstOrDefault(x => x.SKU_Id == promotionItem.SKU_Id) ??
          order.Items.FirstOrDefault(x => x.SKU_Id == promotionItem.SKU_Id);
        if (foundItem == null || foundItem.Quantity < promotionItem.Quantity)
          return null;

        if (!foundItems.Any(x => x.SKU_Id == foundItem.SKU_Id))
          foundItems.Add(new Item(foundItem));
      }

      ApplyPromotionPriceAndCalculateRestQuantity(order, foundItems);

      return foundItems;
    }

    private void ApplyPromotionPriceAndCalculateRestQuantity(Order order, List<Item> foundItems)
    {
      var found = foundItems.Count() > 0;
      if (found)
      {
        do
        {
          order.TotalAmount += TotalAmount;
          foreach (var promotionItem in Items)
          {
            var item = foundItems.FirstOrDefault(x => x.SKU_Id == promotionItem.SKU_Id);
            if (item != null)
            {
              item.Quantity -= promotionItem.Quantity;
              if (found)
                found = item.Quantity >= promotionItem.Quantity;
            }
          }
        } while (found);
      }
    }
  }
}
