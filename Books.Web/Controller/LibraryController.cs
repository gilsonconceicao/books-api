using AutoMapper;
using AutoMapper.QueryableExtensions;
using Books.Application.Library.Commands;
using Books.Application.Library.DTOs;
using Books.Application.Queries.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LibraryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LibraryCreateModel model)
        {
            await _mediator.Send(new CreateLibraryCommand(model));

            return Created(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibrary()
        {
            var query = await _mediator.Send(new GetLibraryListQuery());
            var resultProjected = new[] {query}
                .AsQueryable()
                .ProjectTo<GetLibraryListQueryDto>(_mapper.ConfigurationProvider)
                .First(); 

            return Ok(resultProjected);
        }
    }
}