using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Services
{
    public class MyService : IMyService
    {
        public string hello(string nome) {

            return $"Welcome, {nome}!";
        }
    }
}
