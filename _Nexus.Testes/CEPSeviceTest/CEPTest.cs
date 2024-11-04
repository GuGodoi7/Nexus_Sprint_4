using _Nexus.Services.CepService;

namespace _Nexus.Testes.CEPServiceTest
{
    public class CEPTest
    {
        private readonly CEP _cepService;
        private readonly string validCEP;
        private readonly string invalidCEP;
        private readonly string logradouroEsperado;

        public CEPTest()
        {
            // A - Arrange 
            _cepService = new CEP();

            validCEP = "08737-190";
            invalidCEP = "00000-000";
            logradouroEsperado = "Rua José Pedro Naure";
        }

        [Fact]
        public async Task FindCEP_ReturnsAddressResponse_WhenCEPIsValid()
        {
            // A - Act 
            AddressResponse addressResponse = await _cepService.FindCEP(validCEP);

            // A - Assert 
            Assert.NotNull(addressResponse);
            Assert.Equal(logradouroEsperado, addressResponse.Logradouro);
            Assert.Equal(validCEP, addressResponse.Cep); 
        }
        [Fact]
        public async Task FindCEP_ReturnsNull_WhenCEPIsInvalid()
        {
            //A - Act 
            AddressResponse addressResponse = await _cepService.FindCEP(invalidCEP);

            //A - Assert 
            Assert.Null(addressResponse.Logradouro);
        }
    }
}
