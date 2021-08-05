using MenuRestAPI_Marcoratti.Context;
using MenuRestAPI_Marcoratti.Repository.implementations;
using MenuRestAPI_Marcoratti.Repository.implementations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ProdutoRepository _produtoRepo;

        private CategoriaRepository _categoriaRepo;

        public AppDbContext _dbContext;

        public UnitOfWork(AppDbContext context) {

            this._dbContext = context;
        }

        public IProdutosRepository ProdutosRepository { 
            get {
                // Operador condicional Ternário 
                // _produtoRepo = _produtoRepo OU ( se nao existir ) -> gerar nova instância 
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_dbContext); 
                
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get {
            
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_dbContext);
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose() {
            _dbContext.Dispose();
        }
    }
}
