using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArrayCalcController : Controller
    {
        private readonly IProductService _productService;

        public ArrayCalcController(IProductService productService)
        {            
            _productService = productService;
        }

        [HttpGet("reverse")]
        ///ArrayCalc/Reverse?productIds=1&productIds=2&productIds=3&productIds=4
        public async Task<IActionResult> GetReverse([FromQuery] int[] productIds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(productIds.Length ==0)
            {
                return BadRequest();
            }

            return Ok(await _productService.GetProductReverse(productIds));
        }

        [HttpGet("deletepart")]
        //ArrayCalc/deletepart?position=2&productIds=1&productIds=2&productIds=3&productIds=4
        public async Task<IActionResult> DeletePart([FromQuery] int position, [FromQuery] int[] productIds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (position <= 0)
            {
                return BadRequest();
            }

            if (productIds.Length == 0)
            {
                return BadRequest();
            }

            if(position > productIds.Length)
            {
                return BadRequest();
            }

            return Ok(await _productService.DeletePartOfProduct(productIds, position));
        }
    }
}
