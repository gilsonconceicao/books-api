using Books.Application.DTOs;
using Books.Application.Queries;
using Books.Domain.Interfaces;
using Books.Infrastructure.Repositories;
using MediatR;

namespace Books.Application.Handlers
{
    public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<BookReadModel>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBooksListQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }

        public  async Task<List<BookReadModel>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookListAsync(); 
        }
    }
}