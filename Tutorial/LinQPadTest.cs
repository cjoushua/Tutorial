using LINQPad.Extensibility.DataContext.DbSchema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Tutorial
{
    public static class LINQPadExtensions
    {
        static readonly string DBString = ConfigurationManager.ConnectionStrings["TutorialDB"].ConnectionString;

        [Test]
        public static void HandleLINQPadTest()
        {

        }



        private static readonly Dictionary<Type, string> TypeAliases = new Dictionary<Type, string>()
        {
            { typeof(int), "int" },
            { typeof(short), "short" },
            { typeof(byte), "byte" },
            { typeof(byte[]), "byte[]" },
            { typeof(long), "long" },
            { typeof(double), "double" },
            { typeof(decimal), "decimal" },
            { typeof(float), "float" },
            { typeof(bool), "bool" },
            { typeof(string), "string" }
        };

        private static readonly HashSet<Type> NullableTypes = new HashSet<Type>()
        {
            typeof(int),
            typeof(short),
            typeof(long),
            typeof(double),
            typeof(decimal),
            typeof(float),
            typeof(bool),
            typeof(DateTime)
        };

        public static string DumpClass(this IDbConnection connection, string sql = "select * from ", string className = "Info")
        {

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            var reader = cmd.ExecuteReader();
            var builder = new StringBuilder();

            do
            {
                if (reader.FieldCount <= 1) { continue; }
                builder.AppendFormat("public class {0}{1}", className, Environment.NewLine);
                builder.AppendLine("{");
                var schema = reader.GetSchemaTable();
                foreach (DataRow row in schema.Rows)
                {
                    var type = (Type)row["DataType"];
                    var name = TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
                    var isNullable = (bool)row["AllowDBNull"] && NullableTypes.Contains(type);
                    var collumnName = (string)row["ColumnName"];
                    builder.AppendLine(string.Format("\tpublic {0}{1} {2} {{ get; set; }}", name, isNullable ? "?" : string.Empty, collumnName));

                    builder.AppendLine();
                }

                builder.AppendLine("}");
                builder.AppendLine();
            } while (reader.NextResult());

            return builder.ToString();
        }
    }
}

