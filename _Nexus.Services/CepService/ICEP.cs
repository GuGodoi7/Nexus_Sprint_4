using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Nexus.Services.CepService
{
    public interface ICEP
    {
        Task<AddressResponse> FindCEP(string cep);
    }
}
