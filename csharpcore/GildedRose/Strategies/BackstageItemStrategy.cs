namespace GildedRoseKata.Strategies
{
    public class BackstageItemStrategy : ItemStrategy
    {
        protected override void UpdateItem(Item item)
        {
            _ = item.SellIn switch
            {
                >= 10 => item.Quality++,
                < 10 and >= 5 => item.Quality += 2,
                < 5 and > 0 => item.Quality += 3,
                <= 0 => item.Quality = MinQuality
            };

            item.SellIn--;
        }
    }
}
