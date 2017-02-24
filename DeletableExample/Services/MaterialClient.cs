using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeletableExample.Contracts;
using DeletableExample.Dtos;

namespace DeletableExample
{
    public class MaterialClient : IMaterialClient
    {
        private const string Suffix = "material/";
        private readonly IHttpClientWrapper _httpClient;

        public MaterialClient(IHttpClientWrapper httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MaterialDto> GetByIdAsync()
        {
            const string url = Suffix + "1";
            return await _httpClient.GetAsync<MaterialDto>(url);
        }

        public async Task<PageableData<MaterialMiniDto>> GetListAsync()
        {
            const string url = Suffix + "list/%7B%22page%22%3A1%2C%22categoryId%22%3Anull%2C%22materialType%22%3A%22News%22%2C%22userName%22%3Anull%7D";
            return await _httpClient.GetAsync<PageableData<MaterialMiniDto>>(url);
        }
    }
}
