using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaDapper.Sql
{
    public class SqlTextCommand : ISqlTextCommands
    {
        public string SelectCategoyIdTitle => "SELECT [ID], [TITLE] FROM [Category]";

        public string InsertCategory => "INSERT INTO [CATEGORY] VALUES(@ID,@TITLE,@URL,@SUMMARY,@ORDER,@DESCRIPTION,@FEATURED)"; // @ = Parâmetros a serem recebidos

        public string Update => "UPDATE [CATEGORY] SET [TITLE]=@TITLE WHERE [ID] = @ID";

        public string Delete => "DELETE FROM [CATEGORY] WHERE [ID]=@ID";

        public string ExecuteProcedureDeleteStudent => "[spDeleteStudent]";

        public string InsertStudent => "INSERT INTO [balta].[dbo].[Student] VALUES(@ID,@NAME,@EMAIL,@DOCUMENT,@PHONE,@BIRTHDATE,@CREATEDATE)";
    }
}