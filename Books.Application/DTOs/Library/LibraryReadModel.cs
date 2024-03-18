using Books.Application.DTOs.Book;
using Books.Application.Enums;

namespace Books.Application.DTOs.Library;
#nullable disable
public class LibraryReadModel
{
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<string> Catalogs { get; set; }
        public AddressReadModel Address { get; set; }
        public ICollection<BookReadModel> Books { get; set; }
}