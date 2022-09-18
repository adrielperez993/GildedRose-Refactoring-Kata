namespace GildedRoseKata.Strategies
{
    public class StandardItemStrategy : ItemStrategy
    {
        protected override void UpdateItem(Item item)
        {
            _ = item.SellIn <= 0
                ? item.Quality -= 2
                : item.Quality--;

            item.SellIn--;
        }
    }
}
