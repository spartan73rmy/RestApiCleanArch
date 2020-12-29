using RestApiCleanArch.Application.Interfaces;

namespace RestApiCleanArch.Infraestructure
{
    public class HtmlSanitizer : IHtmlSanitizer
    {
        public string Sanitize(string content)
        {
            var sanitizer = new Ganss.XSS.HtmlSanitizer();
            return sanitizer.Sanitize(content);
        }
    }
}
