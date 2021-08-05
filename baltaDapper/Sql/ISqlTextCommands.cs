using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baltaDapper.Sql
{
    public interface ISqlTextCommands {

        public string SelectCategoyIdTitle { get; }

        public string InsertCategory { get; }

        public string Update { get; }

        public string Delete { get; }

        public string ExecuteProcedureDeleteStudent { get; }

        public string InsertStudent { get; }

    }
}
