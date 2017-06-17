using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomeworkProduction {
    public class Program {
        static void Main(string[] args) {
            var testList = new List<string>() { "1", "ffff", "ggg", "ccc", "ccc" };
            testList = testList.WhereForTest(m => m == "ccc").ToList();

            var orderTest = new List<Order>()
               {
                new Order(){ID=1,Cost=1,Revenue=11,SellPrice=21 },
                new Order(){ID=1,Cost=2,Revenue=12,SellPrice=22 },
                new Order(){ID=1,Cost=3,Revenue=13,SellPrice=23 },
                new Order(){ID=5,Cost=4,Revenue=14,SellPrice=24 },
                new Order(){ID=5,Cost=5,Revenue=15,SellPrice=25 },
                };

            orderTest = orderTest.WhereForTest(m => m.ID == 1).ToList();
        }
    }

    public static class EnumerableExtension {
        public static IEnumerable<int> GetOrderSumByPropertyAndCount<T>(this IEnumerable<T> source, int pageSize, Func<T, int> selector) {
            if (pageSize <= 0) {
                throw new ArgumentException();
            }

            int maxPage = source.Count() / pageSize + 1;
            for (int i = 0; i < maxPage; i++) {
                yield return source.Skip(i * pageSize).Take(pageSize).SumForTest(selector);
            }
        }

        public static IEnumerable<T> WhereForTest<T>(this IEnumerable<T> source, Func<T, bool> selector) {
            foreach (var item in source) {
                if (selector.Invoke(item)) {
                    yield return item;
                }
            }
        }

        public static int SumForTest<T>(this IEnumerable<T> source, Func<T, int> selector) {
            int i = 0;
            foreach (var item in source) {
                i+=selector.Invoke(item);
            }
            return i;
        }

    }

    public class Order {
        public long ID { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
        public string Name { get; set; }
    }
}
