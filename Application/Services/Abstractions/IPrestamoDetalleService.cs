using Application.Base;
using Application.Dtos.PrestamoDetalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IPrestamoDetalleService : IServiceBase<PrestamoDetalleDto, PrestamoDetalleFormDto, PrestamoDetalleIdDto>, IServicePaginated<PrestamoDetalleDto>
    {
    }
}
