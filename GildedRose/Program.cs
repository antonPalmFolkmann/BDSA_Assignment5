using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

                          };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie"){
                    IncreaseQualityIfUnder50(item);
                    DecreaseSellInByOne(item);
                    if (item.SellIn < 0){IncreaseQualityIfUnder50(item);}
                }

                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert"){
                    if (item.Quality < 50){
                        IncreaseItemQualityByOne(item);
                        if (item.SellIn < 11){
                            IncreaseQualityIfUnder50(item);
                            if (item.SellIn < 6){
                                IncreaseQualityIfUnder50(item);
                            }
                        }
                    }
                    DecreaseSellInByOne(item);
                    if (item.SellIn < 0){item.Quality = 0;}
                }

                else if (item.Name == "Sulfuras, Hand of Ragnaros"){
                    item.Quality = item.Quality;
                    item.SellIn = item.SellIn;
                }

                else if (item.Name.Contains("conjured", StringComparison.OrdinalIgnoreCase)){
                    if (item.Quality > 0){ DecreaseItemQualityByX(item,2);}
                    DecreaseSellInByOne(item);
                    if (item.SellIn < 0){
                        if (item.Quality > 0){
                            DecreaseItemQualityByX(item,2);
                        }
                    }
                }

                else{
                    if (item.Quality > 0){DecreaseItemQualityByX(item,1);}
                   DecreaseSellInByOne(item);
                    if (item.SellIn < 0){
                        if (item.Quality > 0){
                            DecreaseItemQualityByX(item,1);
                        }
                    }
                }
            }
        }

        private static void DecreaseSellInByOne(Item item){item.SellIn = item.SellIn - 1;}
        private static void DecreaseItemQualityByX(Item item, int X){item.Quality = item.Quality - X;}
        private void IncreaseItemQualityByOne(Item item){item.Quality++;}
        private void IncreaseQualityIfUnder50(Item item){
            if (item.Quality < 50){
                IncreaseItemQualityByOne(item);
            }
        }

        
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}