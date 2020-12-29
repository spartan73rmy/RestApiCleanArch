namespace RestApiCleanArch.Domain.Enums
{
    public enum TiposUsuario
    {
        Admin = 1,//Aprueba usuarios, Acceso total
        User = 2, //Puede crear, editar, ver y compartir reportes. Puede ver portafolio?
        Productor = 3, //Puede consultar sus estadisticas, portafolio, reportes.
        Visor = 4, //Puede consultar un reporte
    }
}
