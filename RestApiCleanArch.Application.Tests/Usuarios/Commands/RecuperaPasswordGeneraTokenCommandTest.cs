using RestApiCleanArch.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken;
using RestApiCleanArch.Infraestructure;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace RestApiCleanArch.Application.Tests.Usuarios.Commands
{
    public class RecuperaPasswordGeneraTokenCommandTest : TestBase
    {
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseUsuarioNotification()
        {
            string email = "asd@asd.com";
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new RecuperaPasswordGeneraTokenHandler(context, new RandomGenerator(), mediatorMock.Object);

            // Act
            var result = sut.Handle(new RecuperaPasswordGeneraTokenCommand
            {
                Email = email
            }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<RecuperaPasswordGeneraTokenNotificate>(cc => cc.Email == email && cc.Token != null), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void Handle_InValidRequest_ShouldNotRaiseUsuarioNotification()
        {
            string email = "alumnoo@asd.com";
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new RecuperaPasswordGeneraTokenHandler(context, new RandomGenerator(), mediatorMock.Object);

            // Act
            var result = sut.Handle(new RecuperaPasswordGeneraTokenCommand
            {
                Email = email
            }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<RecuperaPasswordGeneraTokenNotificate>(cc => cc.Email == email && cc.Token != null), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
