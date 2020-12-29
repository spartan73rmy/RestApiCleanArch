namespace RestApiCleanArch.Application.Tests.Usuarios.Commands
{
    public class CreateUsuarioCommandTest : TestBase
    {
        //[Fact]
        //public void Handle_GivenValidRequest_ShouldRaiseUsuarioNotification()
        //{
        //    // Arrange
        //    var mediatorMock = new Mock<IMediator>();
        //    var sut = new CreateUsuarioHandler(context, mediatorMock.Object, new MachineDateTime(), new RandomGenerator());

        //    // Act
        //    var result = sut.Handle(new CreateUsuarioCommand
        //    {
        //        ApellidoMaterno = "AMaterno",
        //        ApellidoPaterno = "APaterno",
        //        Email = "Emaiasdj2345l@asdad.coasd",
        //        Nombre = "Nombre",
        //        NombreUsuario = "Aasasdfkj3",
        //        Password = "123",
        //        TipoUsuario = Domain.Enums.TiposUsuario.Alumno
        //    }, CancellationToken.None);

        //    // Assert
        //    mediatorMock.Verify(m => m.Publish(It.Is<CreateUsuarioNotificate>(cc => cc.IdUsuario != 0), It.IsAny<CancellationToken>()), Times.Once);
        //}
        //[Fact]
        //public void Handle_GivenMaestroRequest_ShouldNotRaiseUsuarioNotification()
        //{
        //    // Arrange
        //    var mediatorMock = new Mock<IMediator>();
        //    var sut = new CreateUsuarioHandler(context, mediatorMock.Object, new MachineDateTime(), new RandomGenerator());

        //    // Act
        //    var result = sut.Handle(new CreateUsuarioCommand
        //    {
        //        ApellidoMaterno = "AMaterno",
        //        ApellidoPaterno = "APaterno",
        //        Email = "Emaiasdj2345l@asdad.coadsd",
        //        Nombre = "Nombre",
        //        NombreUsuario = "Aa2sasdfkj3",
        //        Password = "123",
        //        TipoUsuario = Domain.Enums.TiposUsuario.Maestro
        //    }, CancellationToken.None);

        //    // Assert
        //    mediatorMock.Verify(m => m.Publish(It.Is<CreateUsuarioNotificate>(cc => cc.IdUsuario != 0), It.IsAny<CancellationToken>()), Times.Never);
        //}
    }
}
