using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marcorattiWebApí.Migrations
{
    public partial class PopulaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(name,imageUrl) values('Bebidas','http://google.com/images/1.jpg')");
            migrationBuilder.Sql("Insert into Categorias(name,imageUrl) values('Lanches','http://google.com/images/5.jpg')");
            migrationBuilder.Sql("Insert into Categor   ias(name,imageUrl) values('Sobremesas','http://google.com/images/3.jpg')");

            migrationBuilder.Sql("Insert into Produtos(name,description,price,imageUrl,amount,created_at,category_id)" +
                " values('Suco Dell Vale','Suco natural',5.50,'http://google.com/images2/1.jpg',50,now()," +
                "(Select id from categorias where name='Bebidas'))");

            migrationBuilder.Sql("Insert into Produtos(name,description,price,imageUrl,amount,created_at,category_id)" +
                " values('Sanduiche de frango','Sanduiche natural fit de frango',7.50,'http://google.com/images2/2.jpg',15,now()," +
                "(Select id from categorias where name='Lanches'))");

            migrationBuilder.Sql("Insert into Produtos(name,description,price,imageUrl,amount,created_at,category_id)" +
                " values('Bolo de cenoura com Chocolate','Bolo com cobertura',7.00,'http://google.com/images2/3.jpg',20,now()," +
                "(Select id from categorias where name='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
