using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomeworkProduction
{
    public class Program
    {
        IOrderDataAccess orderDataAccess;

        public Program(IOrderDataAccess orderDataAccess)
        {
            this.orderDataAccess = orderDataAccess;
        }
        public Program()
        {
            orderDataAccess = new OrderDataAccess();
        }
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 依照傳入的屬性名稱與數目取訂單總和
        /// </summary>
        /// <param name="count">幾筆資料取一次總和</param>
        /// <param name="property">屬性名稱</param>
        /// <returns></returns> 
        public List<int> GetOrderSumByPropertyAndCount(int count, string property)
        {
            var result = new List<int>();

            try
            {
                Validate(count, property);
            }
            catch (ArgumentException ex)
            {
                throw;
            }

            var orderData = orderDataAccess.GetOrderData();
            var pages = Enumerable.Range(0, orderData.Count / count + 1);

            result = (from p in pages
                      select orderData.Skip(p * count).Take(count).
                      Sum(m => (int)typeof(Order).GetProperty(property).GetValue(m))).ToList();

            return result;
        }

        private void Validate(int count, string property)
        {
            if (count <= 0)
            {
                throw new ArgumentException();
            }
             
            var propertyInfo = typeof(Order).GetProperty(property);
            if (propertyInfo == null)
            {
                throw new ArgumentException();
            }

            if (propertyInfo.PropertyType != typeof(int))
            {
                throw new ArgumentException();
            }
        }
    }

    public class OrderDataAccess : IOrderDataAccess
    {
        public List<Order> GetOrderData()
        {
            return new List<Order>();
        }
    }

    public interface IOrderDataAccess
    {
        List<Order> GetOrderData();
    }

    public class Order
    {
        public long ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
        public string Name { get; set; }
    }
}
