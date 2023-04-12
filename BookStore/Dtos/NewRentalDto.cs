using System.Collections.Generic;

namespace BookStore.Controllers.Api
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BookIds { get; set; }
    }
}