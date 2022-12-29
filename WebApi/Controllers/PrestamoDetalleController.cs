using Application.Dtos.Editoriales;
using Application.Dtos.PrestamoDetalles;
using Application.Services.Abstractions;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Utils.Paginations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PrestamoDetalleController : Controller
    {
        private readonly IPrestamoDetalleService _prestamoDetalleService;

        public PrestamoDetalleController(IPrestamoDetalleService prestamoDetalleService)
        {
            _prestamoDetalleService = prestamoDetalleService;
        }

        [HttpGet]
        public async Task<IEnumerable<PrestamoDetalleDto>> Get()
        => await _prestamoDetalleService.FindAll();

        [HttpGet("Find")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrestamoDetalleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PrestamoDetalleDto>>> Find([FromQuery] PrestamoDetalleIdDto id)
        {
            var response = await _prestamoDetalleService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrestamoDetalleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<PrestamoDetalleDto>>> Post([FromBody] PrestamoDetalleFormDto request)
        {
            var response = await _prestamoDetalleService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrestamoDetalleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<PrestamoDetalleDto>>> Edit([FromQuery] PrestamoDetalleIdDto id, [FromBody] PrestamoDetalleFormDto request)
        {
            var response = await _prestamoDetalleService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PrestamoDetalleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PrestamoDetalleDto>>> Delete([FromQuery] PrestamoDetalleIdDto id)
        {
            var response = await _prestamoDetalleService.EnableOrDisable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<PrestamoDetalleDto>> PaginatedSearch([FromQuery] RequestPagination<PrestamoDetalleDto> request)
        => await _prestamoDetalleService.PaginatedSearch(request);
    }
}
