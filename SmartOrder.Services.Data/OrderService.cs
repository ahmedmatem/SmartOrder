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

        public async Task<IEnumerable<OrderListViewModel>> GetAllOrdersAsync()
        {
            IEnumerable<Order> orders = await orderRepository
                .GetAllAttached()
                .Include(o => o.AssignedWaiter)
                .ToListAsync();

            return orders.Select(o => new OrderListViewModel
            {
                Id = o.Id.ToString(),
                TableNumber = o.Table.TableNumber,
                Status = o.Status.ToString(),
                AssignedWaiter = o.AssignedWaiter != null ? o.AssignedWaiter.FullName : "Unassigned",
                TotalPrice = o.TotalPrice
            });
        }

        public async Task<IEnumerable<OrderListViewModel>> GetOrdersByVenueAsync(Guid? venueId)
        {
            IEnumerable<Order> orders = await orderRepository
                .GetAllAttached()
                .Include(o => o.Table)
                .Include(o => o.AssignedWaiter)
                .Where(o => o.Table.VenueId == venueId)
                .ToListAsync();

            return orders.Select(o => new OrderListViewModel
            {
                Id = o.Id.ToString(),
                TableNumber = o.Table.TableNumber,
                Status = o.Status.ToString(),
                AssignedWaiter = o.AssignedWaiter != null ? o.AssignedWaiter.FullName : "Unassigned",
                TotalPrice = o.TotalPrice
            });
        }

        public async Task<OrderDetailsViewModel> GetOrderByIdAsync(Guid id)
        {
            Order order = await orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }

            return new OrderDetailsViewModel
            {
                Id = order.Id.ToString(),
                TableNumber = order.Table.TableNumber,
                Status = order.Status.ToString(),
                AssignedWaiter = order.AssignedWaiter != null ? order.AssignedWaiter.FullName : "Unassigned",
                TotalPrice = order.TotalPrice,
                Items = order.Items.Select(i => new OrderItemDetailsViewModel
                {
                    ItemName = i.MenuItem.Title,
                    Quantity = i.Quantity,
                    Price = i.MenuItem.Price
                }).ToList()
            };
        }

        public async Task<IEnumerable<OrderListViewModel>> GetPendingOrdersByVenueAsync(string venueId)
        {
            IEnumerable<Order> orders = await orderRepository
                .GetAllAttached()
                .Include(o => o.Table)
                .Include(o => o.AssignedWaiter)
                .Include(o => o.Items)
                .ThenInclude(o => o.MenuItem)
                .Where(o => o.Table.VenueId.ToString() == venueId && o.Status == OrderStatus.Pending)
                .ToListAsync();

            return orders.Select(o => new OrderListViewModel
            {
                Id = o.Id.ToString(),
                TableNumber = o.Table.TableNumber,
                Status = o.Status.ToString(),
                AssignedWaiter = o.AssignedWaiter != null ? o.AssignedWaiter.FullName : "Unassigned",
                TotalPrice = o.TotalPrice
            });
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
