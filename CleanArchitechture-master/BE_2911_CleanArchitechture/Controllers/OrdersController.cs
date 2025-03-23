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

        [HttpPost("GetListOrders")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Lấy danh sách hóa đơn",
              Description = "")]

        public async Task<IActionResult> GetListProduct([FromBody] ApiRequest<string> request)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||GetListOrders");
                var list = await _mediator.Send(new GetAllOrdersQuery(request.Skip, request.Take, request.Data));
                return Ok(new ApiResponse<List<OrdersDto>>(list));
            }
            catch (Exception ex)
            {

                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));

            }
        }

        [HttpPost("CreateOrders")]
        [SwaggerOperation(Summary = "Tạo hóa đơn",
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
                this._logger.LogError(ex, "An error occurred while getting the orders list.");


                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));
            }

        }
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Lấy danh sách chi tiết hóa đơn theo ID hóa đơn ",
      Description = "Chi tiết hóa đơn: Data: Tên sản phẩm, có thể rỗng")]

        public async Task<IActionResult> GetListOrderDetailByOrderID(int id, [FromBody] ApiRequest<string> request)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||GetListOrdersDetail");
                var list = await _mediator.Send(new GetAllOrdersDetailQuery(id, request.Skip, request.Take, request.Data));
                return Ok(new ApiResponse<List<OrdersDetailDto>>(list));
            }
            catch (Exception ex)
            {

                // Trả về mã lỗi 500 với thông điệp chi tiết
                var errors = new List<string> { "Internal server error. Please try again later." };
                return StatusCode(500, ApiResponse<List<string>>.CreateErrorResponse(errors, false));

            }
        }

    }
}
