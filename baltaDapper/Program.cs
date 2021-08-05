using System;
using Dapper;
using Microsoft.Data.SqlClient;
using baltaDapper.Models;
using baltaDapper.Sql;

namespace baltaDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString)) {


                // CreateManyCategory(connection);
                // DeleteCategory(connection);
                // UpdateCategory(connection);
                // ListCategories(connection);
                // CreateCategory(connection);

                CreateStudent(connection);
                ExecuteProcedure(connection);
            }

        }

        static void ListCategories(SqlConnection connection) {
            var sqlCommands = new SqlTextCommand();

            var categories = connection.Query<Category>(sqlCommands.SelectCategoyIdTitle);

            foreach (var category in categories) {
            
                Console.WriteLine($"{category.Id}, {category.Title}");
            }

        }

        static void CreateCategory(SqlConnection connection) {

            var sqlCommands = new SqlTextCommand();

            var category2 = new Category();

            category2.Id = Guid.NewGuid();
            category2.Title = "Amazon AWS";
            category2.url = "amazon";
            category2.description = "Categoria destinada a serviços da AWS";
            category2.Order = 8;
            category2.Summary = "AWS Cloud";
            category2.Featured = false;

            // Execute = Passando o SQL de primeiro parâmetro e depois um object com os atributos para inserir 
            var rows = connection.Execute(sqlCommands.InsertCategory, new
            {
                category2.Id,
                category2.Title,
                category2.url,
                category2.Summary,
                category2.Order,
                category2.description,
                category2.Featured
            });
            Console.WriteLine($"{rows} linhas inseridas.");

        }

        static void UpdateCategory(SqlConnection connection) {

            var sqlCommnds = new SqlTextCommand();

            var rows = connection.Execute(sqlCommnds.Update, new {
            
                ID = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                TITLE = "Front-End 2021"

            });

            if (rows == 0) {
                Console.WriteLine($"{rows} registros atualizados, erro ao atualizar registros");
            }
            else {
                Console.WriteLine($"{rows} registros atualizados");
            }
        
        }

        static void DeleteCategory(SqlConnection connection) {

            var sqlCommands = new SqlTextCommand();

            var rows = connection.Execute(sqlCommands.Delete, new {
            
                ID = new Guid("80978322-de26-4020-b1bd-6200f3c88ca8")

            });

            if (rows == 0) {
            
                Console.WriteLine($"{rows} registros atualizados, erro ao deletar registro");
            }
            else {
           
                Console.WriteLine($"{rows} registros atualizados");
            }

        }

        static void CreateManyCategory(SqlConnection connection)
        {

            var sqlCommands = new SqlTextCommand();

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.url = "amazon";
            category.description = "Categoria destinada a serviços da AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "New Category";
            category2.url = "newcategory";
            category2.description = "Categoria destinada a new category";
            category2.Order = 9;
            category2.Summary = "Category";
            category2.Featured = true;

            // Execute = Passando o SQL de primeiro parâmetro e depois um object com os atributos para inserir 
            var rows = connection.Execute(sqlCommands.InsertCategory, new[] { 
            
                new {
                category.Id,
                category.Title,
                category.url,
                category.Summary,
                category.Order,
                category.description,
                category.Featured
                },

                new {
                category2.Id,
                category2.Title,
                category2.url,
                category2.Summary,
                category2.Order,
                category2.description,
                category2.Featured
                }
            
            });

            Console.WriteLine($"{rows} linhas inseridas.");

        }

        static void ExecuteProcedure(SqlConnection connection) {

            var sqlCommands = new SqlTextCommand();

            var param = new {

                StudentID = "775b1163-cea9-4194-a2e0-e4ea61c29192"
            };

            var affectedRows = connection.Execute(sqlCommands.ExecuteProcedureDeleteStudent, param, commandType: System.Data.CommandType.StoredProcedure);

            Console.WriteLine($"{affectedRows} linhas foram alteradas");

        }

        static void CreateStudent(SqlConnection connection) {

            var student = new Student();
            var sqlCommands = new SqlTextCommand();

            student.Id = Guid.NewGuid();
            student.Name = "Pedro Martins";
            student.Email = "pedromartins@frwk.com.br";
            student.Document = "MG-17.445.478";
            student.Phone = "31 97103-7463";
            student.Birthdate = DateTime.Now;
            student.Createdate = DateTime.Today;

            var rows = connection.Execute(sqlCommands.InsertStudent, new { 
            
                student.Id,
                student.Name,
                student.Email,
                student.Document,
                student.Phone,
                student.Birthdate,
                student.Createdate
            
            });

            if (rows == 0) {
                Console.WriteLine($"{rows} registros inseridos, houve um erro ao criar registros");
            } else {

                Console.WriteLine($"{rows} registros inseridos");
            }

        }
    }
}   
