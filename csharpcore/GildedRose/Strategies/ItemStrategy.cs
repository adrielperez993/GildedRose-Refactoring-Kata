using System;

namespace GildedRoseKata.Strategies
{
    public abstract class ItemStrategy : IItemStrategy
    {
        protected const int MinQuality = 0;
        protected virtual int MaxQuality => 50;

        public void Update(Item item)
        {
            CheckInputConstraints(item.Quality);

            UpdateItem(item);
            
            CheckOutputConstraints(item);
        }

        protected abstract void UpdateItem(Item item);

        #region CheckConstraints

        private void CheckInputConstraints(int quality)
        {
            if (quality > MaxQuality)
                throw new ArgumentException($"Quality is greater than {MaxQuality}");
            if (quality < MinQuality)
                throw new ArgumentException($"Quality is less than {MinQuality}");
        }

        private void CheckOutputConstraints(Item item)
        {
            if (item.Quality < MinQuality)
                item.Quality = MinQuality;

            if (item.Quality > MaxQuality)
                item.Quality = MaxQuality;
        }

        #endregion
    }
}
