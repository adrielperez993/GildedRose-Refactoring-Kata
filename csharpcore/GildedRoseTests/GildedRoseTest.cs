using System;
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using NUnit;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        #region Standard

        [Test]
        public void StandardItemSellInAndQualityDecreaseByOneWhenSellInGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.StandardItem, 10, 50) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.SellIn, Is.EqualTo(9));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.Quality, Is.EqualTo(49));
        }

        [Test]
        public void StandardItemSellInAndQualityDecreaseByTwoWhenSellInLessThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.StandardItem, 0, 50) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.SellIn, Is.EqualTo(-1));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.StandardItem)?.Quality, Is.EqualTo(48));
        }

        [Test]
        public void StandardItemThrowsExceptionWhenQualityIsGreaterThanFifty()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.StandardItem, 5, 51) };
            GildedRose app = new GildedRose(items);

            //Act
            //Assert
            Assert.That(() => app.UpdateQuality(), Throws.Exception.TypeOf<ArgumentException>().With.Message.EqualTo("Quality is greater than 50"));
        }

        #endregion


        #region AgedBrie

        [Test]
        public void AgedBrieSellInAndQualityIncreaseByOneWhenSellInGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.AgedBrie, 5, 15) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.SellIn, Is.EqualTo(4));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.Quality, Is.EqualTo(16));
        }

        [Test]
        public void AgedBrieSellInIncreaseByOneAndQualityIsTheSameWhenSellInGreaterThanZeroAndQualityIsFifty()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.AgedBrie, 10, 50) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.SellIn, Is.EqualTo(9));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.AgedBrie)?.Quality, Is.EqualTo(50));
        }

        #endregion


        #region Sulfuras

        [Test]
        public void SulfurasSellInAndQualityIsTheSame()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateSulfurasItem(10) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.Sulfuras)?.SellIn, Is.EqualTo(10));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.Sulfuras)?.Quality, Is.EqualTo(80));
        }

        #endregion


        #region Backstage

        [Test]
        public void BackstageQualityDecreaseToZeroWhenSellInLessThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.BackstagePass, 0, 10) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.SellIn, Is.EqualTo(-1));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.Quality, Is.EqualTo(0));
        }

        [Test]
        public void BackstageQualityIncreaseThreeUnitsWhenSellInIsFiveDaysOrLess()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.BackstagePass, 4, 10) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.SellIn, Is.EqualTo(3));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.Quality, Is.EqualTo(13));
        }

        [Test]
        public void BackstageQualityIncreaseTwoUnitsWhenSellInIsTenDaysOrLess()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.BackstagePass, 8, 10) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.SellIn, Is.EqualTo(7));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.Quality, Is.EqualTo(12));
        }

        [Test]
        public void BackstageQualityIncreaseOneUnitWhenSellInIsGreaterThanTenDays()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.BackstagePass, 12, 10) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.SellIn, Is.EqualTo(11));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.BackstagePass)?.Quality, Is.EqualTo(11));
        }

        #endregion


        #region Conjured

        [Test]
        public void ConjuredItemQualityDecreaseByTwoWhenSellInGreaterThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.ConjuredItem, 10, 50) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.ConjuredItem)?.SellIn, Is.EqualTo(9));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.ConjuredItem)?.Quality, Is.EqualTo(48));
        }

        [Test]
        public void ConjuredItemQualityDecreaseByFourWhenSellInLessThanZero()
        {
            //Arrange
            var items = new List<Item>() { TestHelper.CreateStandardItem(TestHelper.ConjuredItem, 0, 50) };
            GildedRose app = new GildedRose(items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.ConjuredItem)?.SellIn, Is.EqualTo(-1));
            Assert.That(items.FirstOrDefault(item => item.Name == TestHelper.ConjuredItem)?.Quality, Is.EqualTo(46));
        }

        #endregion
    }
}
