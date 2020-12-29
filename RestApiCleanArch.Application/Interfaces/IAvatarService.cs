using RestApiCleanArch.Domain.Enums;
using System.IO;

namespace RestApiCleanArch.Application.Interfaces
{
    public interface IAvatarService
    {
        bool Exists(string nombre, MySize size);
        void Genera(Stream image, string nombre, MySize size);
        Stream Get(string nombre, MySize size);
        Stream DefaultAvatar(MySize size);
    }
}
