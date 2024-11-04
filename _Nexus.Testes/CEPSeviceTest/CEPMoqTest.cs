using _Nexus.Services.CepService;
using Moq;

namespace _Nexus.Testes.CEPServiceTest
{
    public class CEPMoqTest
    {
        private readonly ICEP _cepService;
        private readonly string validCEP;

        public CEPMoqTest()
        {
            // A - Arrange 
            var mockCepService = new Mock<ICEP>();
            _cepService = mockCepService.Object;

            mockCepService
                .Setup(s => s.FindCEP("08737-190"))
                .ReturnsAsync(new AddressResponse
                {
                    Cep = "08737-190",
                    Logradouro = "Rua teste"
                });

            validCEP = "08737-190";
        }

        [Fact]
        public async Task FindCEP_ReturnsAddressResponse_WhenCEPIsValid()
        {
            // A - Act 
            AddressResponse addressResponse = await _cepService.FindCEP(validCEP);

            // A - Assert 
            Assert.NotNull(addressResponse);
            Assert.Equal(validCEP, addressResponse.Cep); 
            Assert.Equal("Rua Exemplo", addressResponse.Logradouro); 
        }
    }
}
