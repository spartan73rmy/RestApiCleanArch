namespace RestApiCleanArch.Infraestructure.Options
{
    public class EmailServiceOptions
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Enabled { get; set; }
    }
}
