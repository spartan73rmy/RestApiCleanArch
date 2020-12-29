import sys
import os

def printErrAndExit():
    print("Error llamado con los parametros incorrectos")
    print("Ejemplo: cuc.py -c Usuarios/GetUserById")
    print("Ejemplo IEnumerable: cuc.py -c Usuarios/GetUserById -l")
    exit()

if (len(sys.argv) < 3 or len(sys.argv) > 4) or (sys.argv[1] not in ["-q", "-c"]) or ("/" not in sys.argv[2]) or (len(sys.argv) == 4 and sys.argv[3] not in ["-s", "-l"]):
    printErrAndExit()

isCommand = "-c" in sys.argv
nameInp = sys.argv[2].split("/")
name = nameInp[1]
folder = nameInp[0]
returnsEnumerable = len(sys.argv) == 4 and sys.argv[3] == "-l"

if len(name) == 0 or len(folder) == 0:
    printErrAndExit()

authFileName = name + "Auth"
handlerFileName = name + "Handler"
requestFileName = name + ("Command" if isCommand else "Query")
responseFileName = name + "Response"
validatorFileName = name + "Validator"
typeReq = ("Commands" if isCommand else "Queries")

responseType = responseFileName if not returnsEnumerable else f"IEnumerable<{responseFileName}>"

filePrefix = f"RestApiCleanArch.Application\\UseCases\\{folder}\\{typeReq}\\{name}\\"

os.makedirs(filePrefix)

authFile = open(filePrefix + authFileName + ".cs", "x")
authFile.write(f"""using RestApiCleanArch.Application.Interfaces;
using RestApiCleanArch.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.{folder}.{typeReq}.{name}
{{
    public class {authFileName} : IAdminRequest<{requestFileName}, {responseType}>
    {{
        private readonly IRestApiCleanArchDbContext db;
        private readonly IUserAccessor currentUser;

        public {authFileName}(IRestApiCleanArchDbContext db, IUserAccessor currentUser)
        {{
            this.db = db;
            this.currentUser = currentUser;
        }}
        
        public Task Validate({requestFileName} request, ValidationResult validationResult)
        {{
            return Task.CompletedTask;
        }}
    }}
}}
""")

print("Writing " + authFile.name)

authFile.close()

handlerFile = open(filePrefix + handlerFileName + ".cs", "x")
handlerFile.write(f"""using RestApiCleanArch.Application.Exceptions;
using RestApiCleanArch.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestApiCleanArch.Application.UseCases.{folder}.{typeReq}.{name}
{{
    public class {handlerFileName} : IRequestHandler<{requestFileName}, {responseType}>
    {{
        private readonly IRestApiCleanArchDbContext db;

        public {handlerFileName}(IRestApiCleanArchDbContext db)
        {{
            this.db = db;
        }}

        public async Task<{responseType}> Handle({requestFileName} request, CancellationToken cancellationToken)
        {{
            throw new NotImplementedException();
        }}
    }}
}}
""")

print("Writing " + handlerFile.name)
handlerFile.close()

requestFile = open(filePrefix + requestFileName + ".cs", "x")
requestFile.write(f"""using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiCleanArch.Application.UseCases.{folder}.{typeReq}.{name}
{{
    public class {requestFileName} : IRequest<{responseType}>
    {{
        
    }}
}}
""")
print("Writing " + requestFile.name)
requestFile.close()

responseFile = open(filePrefix + responseFileName + ".cs", "x")
responseFile.write(f"""using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiCleanArch.Application.UseCases.{folder}.{typeReq}.{name}
{{
    public class {responseFileName}
    {{
        
    }}
}}
""")
print("Writing " + responseFile.name)
responseFile.close()

validatorFile = open(filePrefix + validatorFileName + ".cs", "x")
validatorFile.write(f"""using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiCleanArch.Application.UseCases.{folder}.{typeReq}.{name}
{{
    public class {validatorFileName} : AbstractValidator<{requestFileName}>
    {{
        public {validatorFileName}()
        {{
            
        }}
    }}
}}
""")
print("Writing " + validatorFile.name)
validatorFile.close()