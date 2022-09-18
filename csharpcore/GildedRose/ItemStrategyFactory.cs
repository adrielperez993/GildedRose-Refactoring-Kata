using GildedRoseKata.Strategies;

namespace GildedRoseKata
{
    public class ItemStrategyFactory
    {
        public IItemStrategy Create(string name) =>
            name switch
            {
                "StandardItem" => new StandardItemStrategy(),
                "Aged Brie" => new AgedBrieItemStrategy(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasItemStrategy(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstageItemStrategy(),
                "Conjured Mana Cake" => new ConjuredItemStrategy(),
                _ => new StandardItemStrategy(),
            };
    }
}
