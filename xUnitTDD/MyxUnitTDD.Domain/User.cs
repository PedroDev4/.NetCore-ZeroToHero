using System;
using System.Collections.Generic;

namespace MyxUnitTDD.Domain
{
    public class User {
        public User(string nome, int idade) {

            Nome = nome;
            Idade = idade;

        }
        public string Nome { get; set; }
        public int Idade { get; set; }


        public bool MaiordeIdade(int idade) {
            if (idade < 18)
                return false;

            return true;
            
        }

        public int UsersMaiorIdade(List<User> users) {

            int count = 0;

            foreach (var user in users) {
           
                if (user.Idade >= 18)
                    count++;

            }

            return count;
      
        }

        public int UsersMenorIdade(List<User> users)
        {

            int count = 0;

            foreach (var user in users)
            {

                if (user.Idade < 18)
                    count++;

            }

            return count;

        }

    }
}
