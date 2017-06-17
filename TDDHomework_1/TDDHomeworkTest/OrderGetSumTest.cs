using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHomeworkProduction;

namespace TDDHomeworkTest {
    [TestClass]
    public class OrderGetSumTest {
        #region Validate Return
        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_3_property_is_Cost_return_6_15_24_21() {
            //arrange
            var order = CreateTestData();

            //act
            var actual = order.GetOrderSumByPropertyAndCount(3, m => m.Cost).ToList();

            //assert
            var expected = new List<int>() { 6, 15, 24, 21 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_4_property_is_Revenue_return_50_66_60() {
            //arrange
            var order = CreateTestData();

            //act
            var actual = order.GetOrderSumByPropertyAndCount(4, m => m.Revenue).ToList();

            //assert 
            var expected = new List<int>() { 50, 66, 60 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_0_should_throw_ArgumentException() {
            //arrange
            var order = CreateTestData();

            ///Act
            Action act = () => order.GetOrderSumByPropertyAndCount(0, m => m.Cost).ToList();

            ///Assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_inus_should_throw_ArgumentException() {
            //arrange
            var order = CreateTestData();

            ///Act
            Action act = () => order.GetOrderSumByPropertyAndCount(-3, m => m.Cost).ToList();
            ///Assert
            act.ShouldThrow<ArgumentException>();
        }
        #endregion

        private List<Order> CreateTestData() {
            return new List<Order>()
            {
                new Order(){ID=1,Cost=1,Revenue=11,SellPrice=21 },
                new Order(){ID=2,Cost=2,Revenue=12,SellPrice=22 },
                new Order(){ID=3,Cost=3,Revenue=13,SellPrice=23 },
                new Order(){ID=4,Cost=4,Revenue=14,SellPrice=24 },
                new Order(){ID=5,Cost=5,Revenue=15,SellPrice=25 },
                new Order(){ID=6,Cost=6,Revenue=16,SellPrice=26 },
                new Order(){ID=7,Cost=7,Revenue=17,SellPrice=27 },
                new Order(){ID=8,Cost=8,Revenue=18,SellPrice=28 },
                new Order(){ID=9,Cost=9,Revenue=19,SellPrice=29 },
                new Order(){ID=10,Cost=10,Revenue=20,SellPrice=30 },
                new Order(){ID=11,Cost=11,Revenue=21,SellPrice=31 },
            };
        }
    }
}


