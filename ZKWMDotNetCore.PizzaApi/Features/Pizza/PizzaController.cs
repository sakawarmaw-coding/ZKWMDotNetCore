using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;
using ZKWMDotNetCore.PizzaApi.Db;
using ZKWMDotNetCore.PizzaApi.Queries;
using ZKWMDotNetCore.Shared;

namespace ZKWMDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _dapperService;
        public PizzaController()
        {
            _appDbContext = new AppDbContext();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtra()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        // Not use DapperService

        //[HttpGet("Order/{invoiceNo}")]
        //public async Task<IActionResult> GetOrder(string invoiceNo)
        //{
        //    var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        //    var lst = await _appDbContext.PizzaOrderDetails.Where(x=> x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

        //    return Ok(new
        //    {
        //        Order = item,
        //        OrderDetail = lst
        //    });
        //}

        [HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                (
                    PizzaQuery.PizzaOrderQuery, new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
                (
                    PizzaQuery.PizzaOrderDetailQuery, new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };

            return Ok(model);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> Order(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if (orderRequest.Extras.Length > 0)
            {
                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrederModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaExtaModels = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel
            {
                PizzaExtraId = extraId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();
            await _appDbContext.PizzaOrders.AddAsync(pizzaOrederModel);
            await _appDbContext.PizzaOrderDetails.AddRangeAsync(pizzaExtaModels);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order! Enjoy your pizza!",
                TotalAmount = total
            };
            return Ok(response);
        }
    }
}
