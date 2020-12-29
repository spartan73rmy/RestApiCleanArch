using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiCleanArch.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadCommand : IRequest<DeleteEnfermedadResponse>
    {
        public int IdEnferemedad;
    }
}
