namespace RestApiCleanArch.Domain.Entities
{
    public class TokenDescargaArchivo : BaseEntity
    {
        public string Token { get; set; }
        public string HashArchivo { get; set; }
    }
}
