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
    public class OrdersDetailController : ControllerBase
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
        public OrdersDetailController(IMediator mediator, IWebHostEnvironment environment, ILogger<OrdersController> logger, IConfiguration configuration, IMapper mapper)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //Xóa sản phẩm trong đơn hàng
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Xóa sanr phẩm của 1 đơn hàng ",
              Description = "Field  <br />" +
            " id: mã sản phẩm trong đơn hàng")]

        public async Task<IActionResult> DeleteOrderDetailById(int id)
        {
            try
            {
                this._logger.LogInformation("-------------Log   ||DeleteOrderDetailById");
                int order = await _mediator.Send(new DeleteOrderDetailByIdCommand(id));
                if (order == 0)
                {

                    return StatusCode(404, new ApiResponse<string>("Not Found:" + id));
                }
                return Ok(new ApiResponse<int>(id));
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
