using System;
using Xunit;

namespace MyxUnitTDD
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() {
        


        }

        public void EstruturaAAA() {

            // Arrange - Preparar 
            var cpf = "111.111.111-00";

            // Act - Agir em cima do método a ser testado com a informação preparada no Arrange
            var result = validaCPF(cpf);

            // Assert - Validar
            Assert.False(result);
        
        }

        public void EstruturaSEVT() {
    
            // Setup - Preparar 
            var cpf = "111.111.111-00";

            // Exercise - Agir em cima do método a ser testado com a informação preparada no Arrange
            var result = validaCPF(cpf);

            // Verify - Validar
            Assert.False(result);

            // Teardown

            cpf = null; // Limpar informação preparada 

        }
    }
}
