using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomeworkProduction
{
    public class OrderGetSum {
        static void Main(string[] args) {

        }

        public IEnumerable<int> GetOrderSumByPropertyAndCount<T>(int pageSize, IEnumerable<T> source, Func<T, int> seletor) {

            if (pageSize <= 0) {
                throw new ArgumentException();
            }

            int maxPage = source.Count() / pageSize + 1;
            for (int i = 0; i < maxPage; i++) {
                yield return source.Skip(i * pageSize).Take(pageSize).Sum(seletor);
            }
        }

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
