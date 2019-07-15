using PizzaDal.DAL;
using PizzaDal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBal.Actions
{
    public class OrderBal
    {
        string _connectionString;
        OrderDal orderDal;
        public OrderBal(string connectionString)
        {
            _connectionString = connectionString;
            orderDal = new OrderDal(_connectionString);
        }

        public List<PizzaSize> LoadPizzaSize()
        {
            List<PizzaSize> pizzaSizeList = new List<PizzaSize>();
            foreach (DataRow item in orderDal.LoadPizzaSize().Rows)
            {
                pizzaSizeList.Add(new PizzaSize
                {
                    Id = item["Id"].ToString(),
                    Size = item["Name"].ToString()
                });
            }
            return pizzaSizeList;
        }

        public List<PizzaType> LoadPizzaType()
        {
            List<PizzaType> pizzaTypeList = new List<PizzaType>();
            foreach (DataRow item in orderDal.LoadPizzaType().Rows)
            {
                pizzaTypeList.Add(new PizzaType
                {
                    Id = item["TypeId"].ToString(),
                    Type = item["TypeName"].ToString()
                });
            }
            return pizzaTypeList;
        }
    }
}
