using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ria.smc.associates.DataAccessLayer.Constants.Users
{
    public static class StoreProcedures
    {
        public static class USERINFORMATION_GET
        {
            public const string Name = "USERINFORMATION_GET";
            public static class Params
            {
                public const string USERNAME = "@CNIC";
                public const string PASSWORD = "@PASSWORD";
            }
        }
    }
}
