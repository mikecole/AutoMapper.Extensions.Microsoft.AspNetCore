using AutoMapper.Extensions.Microsoft.AspNetCore.Mvc;
using Shouldly;
using Xunit;

namespace AutoMapper.Extensions.Microsoft.AspNetCore.Tests
{
    public class MapperExtensionsTests
    {
        [Fact]
        public void Ok_ShouldMapSource_ToDestination()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
            });

            var source = new Source
            {
                Id = 1,
                Value = "Foo"
            };

            var result = Mapper.Instance.Ok<Destination>(source);

            result.Value.ShouldBeOfType<Destination>();
            ((Destination)result.Value).Value.ShouldBe("Foo");
        }

        [Fact]
        public void Ok_GracefullHandlesNulls()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Source, Destination>();
            });

            var result = Mapper.Instance.Ok<Destination>(null);

            result.Value.ShouldBeNull();
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
}