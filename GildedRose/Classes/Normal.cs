namespace GildedRose{
    public class Normal : Item, IItem
    {
        public string GetName() => Name;

        public int GetQuality() => Quality;

        public int GetSellIn() => SellIn;
        public void UpdateItem()
        {
            if (Quality > 0){Quality = Quality - 1;}
            SellIn--;
            if (SellIn < 0){
                if (Quality > 0){
                    Quality = Quality - 1;
                }
            }
        }
    }
}