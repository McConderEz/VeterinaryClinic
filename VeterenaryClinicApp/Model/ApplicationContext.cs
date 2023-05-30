using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VeterenaryClinicApp.Model
{
    public class ApplicationContext: DbContext
    {
        public static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;";

        

    }
}
