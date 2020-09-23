using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPromotionEngine
{
  public class Promotion
  {
    public List<Item> Items { get; set; }
    public int TotalAmount { get; set; }

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
      var found = true;
      do
        foreach (var item in foundItems)
        {
          var promotionItem = Items.First(x => x.SKU_Id == item.SKU_Id);
          item.Quantity -= promotionItem.Quantity;
          order.TotalAmount += TotalAmount;
          if (found)
            found = promotionItem.Quantity <= item.Quantity;
        }
      while (found);
    }
  }
}
