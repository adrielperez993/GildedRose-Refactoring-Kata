namespace GildedRoseKata.Strategies
{
    public class SulfurasItemStrategy : ItemStrategy
    {
        protected override int MaxQuality => 80;

        protected override void UpdateItem(Item item)
        {
            item.Quality = MaxQuality;
        }
    }
}
