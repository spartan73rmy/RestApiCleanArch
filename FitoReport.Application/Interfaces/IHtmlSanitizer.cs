﻿namespace FitoReport.Application.Interfaces
{
    public interface IHtmlSanitizer
    {
        public string Sanitize(string content);
    }
}
