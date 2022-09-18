using GildedRoseKata;

namespace GildedRoseTests
{
    internal class TestHelper
    {
        public const string StandardItem = "StandardItem";
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredItem = "Conjured Mana Cake";

        public static Item CreateStandardItem(string name, int sellIn, int quality)
        {
            return new()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public static Item CreateSulfurasItem(int sellIn)
        {
            return CreateStandardItem(Sulfuras, sellIn, 80);
        }
    }
}
