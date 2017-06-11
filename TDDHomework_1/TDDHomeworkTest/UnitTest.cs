using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHomeworkProduction;
using NSubstitute;
using FluentAssertions;

namespace TDDHomeworkTest
{
    [TestClass]
    public class UnitTest
    {
        #region Validate Return
        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_3_property_is_Cost_return_6_15_24_21()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            var actual = target.GetOrderSumByPropertyAndCount(3, "Cost");

            //assert
            var expected = new List<int>() { 6, 15, 24, 21 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_4_property_is_Revenue_return_50_66_60()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);
            //act
            var actual = target.GetOrderSumByPropertyAndCount(4, "Revenue");

            //assert
            var expected = new List<int>() { 50, 66, 60 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_0_should_return_0()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            var actual = target.GetOrderSumByPropertyAndCount(0, "Revenue");

            //assert
            var expected = new List<int>() { 0 };
            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region validate property is not exist exception
        [TestMethod]
        public void GetOrderSumByPropertyAndCount_property_is_not_exist_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(3, "NotExistProperty");

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_property_is_exist_not_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(5, "SellPrice");

            //assert
            act.ShouldNotThrow<ArgumentException>();
        }
        #endregion

        #region validate property is not int exception
        [TestMethod]
        public void GetOrderSumByPropertyAndCount_property_is_not_int_should_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(5, "Name");

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_property_is_int_should_not_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(2, "SellPrice");

            //assert
            act.ShouldNotThrow<ArgumentException>();

        }
        #endregion

        #region validate count is minus exception
        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_small_than_0_should_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(-3, "Revenue");

            //assert
            act.ShouldThrow<ArgumentException>();

        }

        [TestMethod]
        public void GetOrderSumByPropertyAndCount_count_is_big_than_0_should_not_throw_ArgumentException()
        {
            //arrange
            var orderDataAccessStub = Substitute.For<IOrderDataAccess>();
            var orderData = CreateTestData();
            orderDataAccessStub.GetOrderData().Returns(orderData);
            var target = new Program(orderDataAccessStub);

            //act
            Action act = () => target.GetOrderSumByPropertyAndCount(3, "Revenue");

            //assert
            act.ShouldNotThrow<ArgumentException>();
        }
        #endregion

        private List<Order> CreateTestData()
        {
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


