using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MenuRestAPI_Marcoratti.Models;

namespace MenuRestAPI_Marcoratti.Context
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { // Metodo de configuração do Context
            string mySqlConncetionStr = "Server=localhost;DataBase=MenuCatalogoDB;Uid=root;Pwd=''";

            optionsBuilder.UseMySql(mySqlConncetionStr, ServerVersion.AutoDetect(mySqlConncetionStr));
            
        }

        public DbSet<Category> categories { get; set; } // Setando a classe Category como entity no DB.
        // A Entidade Category vai ser a table categories no DB

        public DbSet<Product> products { get; set; }

    }
}
