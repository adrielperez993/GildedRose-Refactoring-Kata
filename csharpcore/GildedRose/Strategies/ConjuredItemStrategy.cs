namespace GildedRoseKata.Strategies
{
    public class ConjuredItemStrategy : ItemStrategy
    {
        protected override void UpdateItem(Item item)
        {
            _ = item.SellIn <= 0
                ? item.Quality -= 4
                : item.Quality -= 2;

            item.SellIn--;
        }
    }
}
