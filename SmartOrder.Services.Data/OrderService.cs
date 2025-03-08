using Microsoft.EntityFrameworkCore;
using SmartOrder.Common.Enums;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Order;
using SmartOrder.Web.ViewModels.OrderItem;

namespace SmartOrder.Services.Data
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IRepository<Order, Guid> orderRepository;
        private readonly IRepository<OrderItem, Guid> orderItemRepository;

        public OrderService(IRepository<Order, Guid> orderRepository, IRepository<OrderItem, Guid> orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public async Task<bool> CreateOrderAsync(OrderCreateViewModel viewModel)
        {
            Guid tableGuid = Guid.Empty;
            if (!IsGuidValid(viewModel.TableId, ref tableGuid))
            {
                return false;
            }

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                TableId = tableGuid,
                AssignedWaiterId = null,
                Status = OrderStatus.Pending,
            };

            order.Items = viewModel.Items.Select(i => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                MenuItemId = Guid.Parse(i.MenuItemId),
                Quantity = i.Quantity
            }).ToList();

            await orderRepository.AddAsync(order);
            return true;
        }

        public async Task<IEnumerable<OrderDetailsViewModel>> GetOrdersByVenueAsync(Guid? venueId)
        {
            IEnumerable<Order> orders = await orderRepository
                .GetAllAttached()
                .Include(o => o.Table)
                .Include(o => o.AssignedWaiter)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.Table.VenueId == venueId)
                .ToListAsync();

            return orders.Select(o => new OrderDetailsViewModel
            {
                Id = o.Id.ToString(),
                TableNumber = o.Table.TableNumber,
                Status = o.Status.ToString(),
                AssignedWaiterId = o.AssignedWaiterId.ToString(),
                AssignedWaiter = o.AssignedWaiter != null ? o.AssignedWaiter.FullName : "Unassigned",
                TotalPrice = o.TotalPrice,
                Items = o.Items.Select(oi => new OrderItemDetailsViewModel
                {
                    ItemName = oi.MenuItem.Title,
                    Quantity = oi.Quantity,
                    Price = oi.TotalPrice
                }).ToList()
            });
        }
        
        public async Task<bool> AssignOrderToWaiterAsync(Guid orderId, Guid waiterId)
        {
            Order? order = await orderRepository.FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null || order.AssignedWaiterId != null)
            {
                return false;
            }

            order.AssignedWaiterId = waiterId;
            await this.orderRepository.UpdateAsync(order);

            return true;
        }
        
        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            Order order = await orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return false;
            }

            if (Enum.TryParse(status, out OrderStatus newStatus))
            {
                order.Status = newStatus;
                await orderRepository.UpdateAsync(order);
                return true;
            }
            return false;
        }
    }
}
