namespace GildedRose{
    public class AgedBrie : Item, IItem
    {
        public string GetName() => Name;

        public int GetQuality() => Quality;

        public int GetSellIn() => SellIn;

        public void UpdateItem()
        {
            if (Quality < 50){
                Quality++;
            }
            SellIn--;
            if (SellIn < 0){
                if (Quality < 50){
                    Quality++;
                }
            }
        }
    }
}