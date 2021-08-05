using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.Repository.implementations.interfaces;

namespace MenuRestAPI_Marcoratti.Repository
{
    public interface IUnitOfWork
    {

       IProdutosRepository ProdutosRepository { get;  }
       ICategoriaRepository CategoriaRepository { get; }

       void Commit();

    }
}
