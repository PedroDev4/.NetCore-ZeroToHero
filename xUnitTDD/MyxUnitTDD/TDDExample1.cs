using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyxUnitTDD
{
    public class TDDExample1 {

        private int MaiorIdade = 18;

        [Fact(DisplayName = "Deve retornar verdadeiro para usuario maior de idade")]
        public void UserMaiorDeIdade() {

            // Arrange
            var user = new User("José", 40);

            // Act 
            var result = user.MaiordeIdade();

            // Assert   

            var expected = true;

            Assert.Equal(expected, result);
        
        }
    
    }
}
