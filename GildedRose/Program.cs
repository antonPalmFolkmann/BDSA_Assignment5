using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<IItem> Items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            Program app = InitializeItems();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].GetName() + ", " + app.Items[j].GetSellIn() + ", " + app.Items[j].GetQuality());
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

        }

        private static Program InitializeItems()
        {
            var app = new Program()
            {
                Items = new List<IItem>
                                          {
                new Normal { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Normal { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new BackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new BackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new BackStagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				new Conjured { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

            };
            return app;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateItem();
            }
        }
    }
}