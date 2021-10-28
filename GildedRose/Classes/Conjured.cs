namespace GildedRose{
    public class Conjured : Item, IItem
    {
        public string GetName() => Name;

        public int GetQuality() => Quality;

        public int GetSellIn() => SellIn;
        public void UpdateItem()
        {
            if (Quality > 0){ Quality = Quality - 2;}
            SellIn--;
            if (SellIn < 0){
                if (Quality > 0){
                    Quality = Quality - 2;
                }
            }
        }
    }
}