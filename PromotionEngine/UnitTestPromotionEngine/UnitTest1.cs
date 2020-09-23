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
        new SKU_Price { SKU_Id = 'A', Price = 50 },
        new SKU_Price { SKU_Id = 'B', Price = 30 },
        new SKU_Price { SKU_Id = 'C', Price = 20 },
        new SKU_Price { SKU_Id = 'D', Price = 15 } };

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
    public void Test_Senario_A()
    {
    }
    [TestMethod]
    public void Test_Senario_B()
    {
    }
  }
}
