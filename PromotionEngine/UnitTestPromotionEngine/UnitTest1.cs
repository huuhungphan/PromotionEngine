using System;
using System.Collections.Generic;
using ClassLibraryPromotionEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPromotionEngine
{
  [TestClass]
  public class UnitTest1
  {
    static readonly IEnumerable<SKU_Price> PriceList =
      new List<SKU_Price> {
        new SKU_Price { SKU_Id = 'A', UnitPrice = 50 },
        new SKU_Price { SKU_Id = 'B', UnitPrice = 30 },
        new SKU_Price { SKU_Id = 'C', UnitPrice = 20 },
        new SKU_Price { SKU_Id = 'D', UnitPrice = 15 } };

    static readonly IEnumerable<Promotion> Promotions =
      new List<Promotion> {
        new Promotion {
          Items = new List<Item> {
            new Item { SKU_Id = 'A', Quantity = 3 }},
          TotalAmount = 130 }, // 3 of A for 130
        new Promotion {
          Items = new List<Item> {
            new Item { SKU_Id = 'B', Quantity = 2 }},
          TotalAmount = 45 }, // 2 of B for 45
        new Promotion {
          Items = new List<Item> {
            new Item { SKU_Id = 'C', Quantity = 1 },
            new Item { SKU_Id = 'D', Quantity = 1 }},
          TotalAmount = 30 } }; // C + D for 30
    static readonly Engine actualEngine = new Engine(PriceList, Promotions);

    [TestMethod]
    public void Test_Scenario_A()
    {
      var order =
        new Order
        {
          Items = new List<Item>
          {
            new Item { SKU_Id = 'A', Quantity = 1 },
            new Item { SKU_Id = 'B', Quantity = 1 },
            new Item { SKU_Id = 'C', Quantity = 1 }}
        };

      actualEngine.CheckOut(order);
      Assert.IsTrue(order.TotalAmount == 100);
    }

    [TestMethod]
    public void Test_Scenario_B()
    {
      var order =
        new Order
        {
          Items = new List<Item>
          {
            new Item { SKU_Id = 'A', Quantity = 5 },
            new Item { SKU_Id = 'B', Quantity = 5 },
            new Item { SKU_Id = 'C', Quantity = 1 }}
        };

      actualEngine.CheckOut(order);
      Assert.IsTrue(order.TotalAmount == 370);
    }

    [TestMethod]
    public void Test_Scenario_C()
    {
      var order =
        new Order
        {
          Items = new List<Item>
          {
            new Item { SKU_Id = 'A', Quantity = 3 },
            new Item { SKU_Id = 'B', Quantity = 5 },
            new Item { SKU_Id = 'C', Quantity = 1 },
            new Item { SKU_Id = 'D', Quantity = 1 }}
        };

      actualEngine.CheckOut(order);
      Assert.IsTrue(order.TotalAmount == 280);
    }
  }
}
