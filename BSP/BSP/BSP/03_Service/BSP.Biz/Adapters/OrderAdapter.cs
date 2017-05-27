using BSP.Model;
using BSP.Mvc;
using BSP.ViewModel;
using System;
using System.Collections.Generic;

namespace BSP.Biz.Adapters
{
    /// <summary>
    /// 订单业务逻辑适配器
    /// </summary>
    public class OrderAdapter : _BaseAdapter
    {
        public IMessage SaveOrder(ShoppingCart shoppingCart)
        {
            IMessage message = Message.ErrorMessage;

            try
            {
                Order order = new Order
                {
                    TotalPrice = shoppingCart.TotalPrice,
                    UserId = UserTicketManager.CurrentUserTicket.ID
                };

                IList<OrderBook> orderBooks = new List<OrderBook>();
                foreach (var item in shoppingCart.Items.Values)
                {
                    orderBooks.Add(new OrderBook
                    {
                        BookID = item.Book.Id,
                        Quantity = item.Count,
                        UnitPrice = item.Subtotal
                    });
                }

                message = base.OrderRepository.SaveOrder(order, orderBooks);
            }
            catch (Exception ex)
            {
                base.Logger.ErrorException("保存订单时出现异常", ex);
            }

            return message;
        }
        public IList<Order> GetALlOrder()
        {
            return base.OrderRepository.GetAllOrder();
        }
    }
}
