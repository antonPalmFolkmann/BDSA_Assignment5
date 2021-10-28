namespace GildedRose{
    public class BackStagePass : Item, IItem
    {
        public string GetName() => Name;

        public int GetQuality() => Quality;

        public int GetSellIn() => SellIn;
        public void UpdateItem()
        {
            if (Quality < 50){
                Quality++;
                if (SellIn < 11){
                    if (Quality < 50){
                        Quality++;
                    }
                    if (SellIn < 6){
                        if (Quality < 50){
                            Quality++;
                        }
                    }
                }
            }
            SellIn--;
            if (SellIn < 0){Quality = 0;}
        }
    }
}