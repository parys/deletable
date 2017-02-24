using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeletableExample.Dtos;

namespace DeletableExample.Contracts
{
    public interface IMaterialClient
    {
        Task<MaterialDto> GetByIdAsync();

        Task<PageableData<MaterialMiniDto>> GetListAsync();
    }
}