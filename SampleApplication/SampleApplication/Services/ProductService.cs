using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Services
{
    public class ProductService : IProductService
    {
        public async Task<int[]> GetProductReverse(int[] productIds)
        {
            int length = productIds.Length - 1;
            int[] reverse = new int[productIds.Length];
            int index=0;
            while (length >= 0)
            {
                reverse[index] = productIds[length];
                length--;
                index++;
            }

            return reverse;
        }

        public async Task<int[]> DeletePartOfProduct(int[] productIds, int position)
        {           
            int[] result = new int[productIds.Length - 1];
            int index = 0;
            for (int i = 0; i <= productIds.Length - 1; i++)
            {
                if (i != position - 1)
                {
                    result[index] = productIds[i];
                    index++;
                }
            }

            return result;
        }
    }
}
