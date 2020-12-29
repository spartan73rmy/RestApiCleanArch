namespace RestApiCleanArch.Domain.Entities
{
    public class UsuarioToken : BaseEntity
    {
        public int IdUsuario { get; set; }
        public string RefreshToken { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
