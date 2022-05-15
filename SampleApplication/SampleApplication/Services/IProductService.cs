using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Services
{
    public interface IProductService
    {
        Task<int[]> GetProductReverse(int[] productIds);
        Task<int[]> DeletePartOfProduct(int[] productIds, int position);
    }
}
