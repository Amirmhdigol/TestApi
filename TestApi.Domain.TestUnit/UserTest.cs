using FluentAssertions;
using System;
using Xunit;

namespace TestApi.Domain.TestUnit;
public class UserTest
{
    private readonly UserBuilder builder;
    public UserTest()
    {
        builder = new UserBuilder();
    }

    [Fact]
    public void Should_Create_User()
    {
        //arrange
        builder.SetName("TestUser");

        //act
        var user = builder.Build();

        //assert
        user.Name.Should().Be("TestUser");
    }
}
