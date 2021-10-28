namespace GildedRose{
    public class Sulfuras : Item, IItem
    {
        public string GetName() => Name;

        public int GetQuality() => Quality;

        public int GetSellIn() => SellIn;
        public void UpdateItem()
        {
            Quality = Quality;
            SellIn = SellIn;
        }
    }
}