using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marcorattiWebApí.Models;

namespace marcorattiWebApí.Context
{
    public class AppDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string mySqlConnectionStr= "Server=localhost;DataBase=CatalogoDB;Uid=root;Pwd=''";

            optionsBuilder.UseMySql(mySqlConnectionStr,ServerVersion.AutoDetect(mySqlConnectionStr));
        }
        public DbSet<Category> categories {get; set;} // Setando a classe Category como entity no DB.
        //A Entidade Category vai ser a table categories no DB

        public DbSet<Product> products { get; set; }

    }
}