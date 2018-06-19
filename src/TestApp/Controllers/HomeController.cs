using AutoMapper;
using AutoMapper.Extensions.Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var source = new Source
            {
                Id = 1,
                Value = "Foo"
            };

            return _mapper.Ok<Destination>(source);
        }
    }

    public class Source
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class Destination
    {
        public string Value { get; set; }
    }
}