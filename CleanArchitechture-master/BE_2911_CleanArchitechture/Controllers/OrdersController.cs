using AutoMapper;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.IRepository;
using CleanArchitecture.Application.Query;
using CleanArchitecture.Application.Query.Utilities;
using CleanArchitecture.Entites.Dtos;
using CleanArchitecture.Entites.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace BE_2911_CleanArchitechture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private IProductServices _productServices;
        //public ProductController(IProductServices productServices)
        //{
        //    _productServices = productServices;
        //}
        private readonly IWebHostEnvironment _environment;

        private readonly IMediator _mediator;
        private readonly ILogger<OrdersController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OrdersController(IMediator mediator, IWebHostEnvironment environment, ILogger<OrdersController> logger, IConfiguration configuration, IMapper mapper)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        string description = "Field  <br />" +
            " skip:Số lượng bỏ qua  <br />" +
                    " take: Số lượng lấy <br />";
        //Lấy dannh sách đơn hàng
        [HttpPost("GetListOrders")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Lấy danh sách đơn hàng",
              Description = "Field  <br />" +
            " skip:Số lượng bỏ qua  <br />" +
                    " take: Số lượng lấy <br />" +
                    " data: Tên khách hàng( Có thể rỗng)")]

        public async Task<IActionResult> GetListOrders([FromBody] ApiRequest<string> request)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||GetListOrders");
                var list = await _mediator.Send(new GetAllOrdersQuery(request.Skip, request.Take, request.Data));
                return Ok(new ApiResponse<List<OrdersDto>>(list));
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                this._logger.LogError(ex.Message, "An error occurred while getting the orders list."); 

                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." + ex.Message };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));

            }
        }
        //Lấy chi tiết của 1 đơn hàng theo id 
        [HttpGet("{id}")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Lấy chi tiết 1 đơn hàng theo id ",
               Description = "" )]

        public async Task<IActionResult> Get1OrdersByID(int id)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||Get1OrdersByID");
                var list = await _mediator.Send(new Get1OrdersQuery(id));
                return Ok(new ApiResponse<OrdersDto>(list));
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                this._logger.LogError(ex.Message, "An error occurred while getting the orders list.");

                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." + ex.Message };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));

            }
        }

        //Tạo đơn hàng mới
        [HttpPost("CreateOrders")]
        [SwaggerOperation(Summary = "Tạo đơn hàng",
              Description = "")]
        public async Task<IActionResult> Create(CreateOrdersCommand command)
        {
            try
            {
            this._logger.LogInformation("-------------Log   ||CreateOrders");
            var order=await _mediator.Send(command);
                OrdersDto orderDto = _mapper.Map<OrdersDto>(order);
                return Ok(new ApiResponse<OrdersDto>(orderDto));

            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                this._logger.LogError(ex.Message, "An error occurred while getting the orders list.");


                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later."+ ex.Message };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));
            }

        }
        //Lấy danh sách sản phẩm của 1 đơn hàng
        [HttpGet("{id}/order-details")]
        [SwaggerOperation(Summary = "Lấy danh sách sản phầm của 1 đơn hàng ",
              Description = "Field  <br />" +
            " skip:Số lượng bỏ qua  <br />" +
                    " take: Số lượng lấy <br />" +
                    " data: Tên sản phẩm( Có thể rỗng)")]

        public async Task<IActionResult> GetListOrderDetailByOrderID(int id, [FromBody] ApiRequest<string> request)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||GetListOrderDetailByOrderID");
                var list = await _mediator.Send(new GetAllOrdersDetailQuery(id, request.Skip, request.Take, request.Data));
                return Ok(new ApiResponse<List<OrdersDetailDto>>(list));
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                this._logger.LogError(ex.Message, "An error occurred while getting the orders list.");

                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." + ex.Message };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));

            }
        }
    }
}
