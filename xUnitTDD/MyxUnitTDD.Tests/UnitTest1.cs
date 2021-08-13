using MyxUnitTDD.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyxUnitTDD.Tests
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Deve retornar true para usuário maior de idade")]
        public void UsuarioMaiorDeIdade() {

            // Arrange
            var user = new User("José",40);

            // Act
            var result = user.MaiordeIdade(user.Idade);
            var expected = true;

            // Assert

            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Deve Retornar True para usuario menor de idade")]
        public void UsuarioMenordeIdade()
        {

            // Arrange
            var user = new User("José", 17);

            // Act
            var result = user.MaiordeIdade(user.Idade);
            var expected = false;

            // Assert

            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Deve Retornar Lista de usuarios maior idade")]
        public void UsuariosMaiordeIdade()
        {
            // Arrange
            var user = new User("José", 16);
            var user2 = new User("José", 18);
            var user3 = new User("José", 20);
            List<User> users = new List<User>() { user, user2, user3 };

            // Act
            var result = user.UsersMaiorIdade(users);
            var expected = 2;

            // Assert
            Assert.Equal(expected, result);

        }

        [Fact(DisplayName = "Deve Retornar Lista de usuarios menor idade")]
        public void UsuariosMenordeIdade()
        {
            // Arrange
            var user = new User("José", 16);
            var user2 = new User("José", 18);
            var user3 = new User("José", 20);
            List<User> users = new List<User>() { user, user2, user3 };

            // Act
            var result = user.UsersMenorIdade(users);
            var expected = 1;

            // Assert
            Assert.Equal(expected, result);

        }
    }
}
