using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //we are declaring this structure static for we don't want to waste our time by creating Messages instances all the time.
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Product Name is Invalid!"; // create Pascal key structure for public declarations. Private declarations goes with camelCase
        public static string MaintenanceTime = "No time!";
        public static string ProductsListed = "Products are listed";

        public static string ProductUpdated { get; internal set; }
    }
}
