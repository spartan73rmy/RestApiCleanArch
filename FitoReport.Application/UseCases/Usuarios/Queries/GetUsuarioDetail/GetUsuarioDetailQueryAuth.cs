﻿using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailQueryAuth : IAuthenticatedRequest<GetUsuarioDetailQuery, GetUsuarioDetailResponse>
    {
        public Task Validate(GetUsuarioDetailQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}