using Student.Core.Contracts;
using Student.Core.Models;
using Student.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        IRepository<Device> deviceContext;
        IRepository<FaultLog> faultlogContext;


        public OrderService(IRepository<Order> OrderContext, IRepository<Device> DeviceContext)
        {
            this.orderContext = OrderContext;
            this.deviceContext = DeviceContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    DeviceId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    DeviceName = item.DeviceName,
                    Quantity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }

        public List<Order> GetOrderList() //Returns list of orders
        {
            return orderContext.Collection().ToList();
        }

        public Order GetOrder(string Id) //Returns an individual order
        {
            return orderContext.Find(Id);
        }

        public void UpdateOrder(Order updatedOrder) //Updates order (Order Status)
        {
            orderContext.Update(updatedOrder);
            orderContext.Commit();
        }

        public void CreateFault(FaultLog objfaultLog)
        {
            faultlogContext.Insert(objfaultLog);
            faultlogContext.Commit();
        }
        public List<FaultLog> GetFaultList() //Returns list of orders
        {
            return faultlogContext.Collection().ToList();
        }


        public FaultLog GetFault(string Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateFault(FaultLog updatedFaultLog)
        {
            throw new NotImplementedException();
        }
    }
}
