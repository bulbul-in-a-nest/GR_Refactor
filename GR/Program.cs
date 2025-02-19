﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GR
{
    public class Program
    {
        public IList<Item> Items;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            var app = new Program()
            {
                Items = new List<Item>
        {
          new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
          new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
          new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
          new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
          new Item
          {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = 15,
            Quality = 20
          },
          new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        }
            };

            app.UpdateInventory();

            var filename = $"inventory_{DateTime.Now:yyyyddMM-HHmmss}.txt";
            var inventoryOutput = JsonConvert.SerializeObject(app.Items, Formatting.Indented);
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename), inventoryOutput);

            Console.ReadKey();
        }

        public void UpdateInventory()
        {
            Console.WriteLine("Updating inventory");
            foreach (var item in Items)
            {
                ProcessInventory.GetInstance(item).UpdateItemInventory(item);
            }
            Console.WriteLine("Inventory update complete");
        }


    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}