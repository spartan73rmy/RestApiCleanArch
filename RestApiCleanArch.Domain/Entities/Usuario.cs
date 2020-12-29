using RestApiCleanArch.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RestApiCleanArch.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            ArchivoUsuario = new HashSet<Archivo>();
            UsuarioTokens = new HashSet<UsuarioToken>();
        }

        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public bool Confirmado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TokenConfirmacion { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime LockoutEnd { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ImagenPerfil { get; set; }

        public virtual ICollection<Archivo> ArchivoUsuario { get; set; }
        public virtual ICollection<UsuarioToken> UsuarioTokens { get; set; }

    }
}
