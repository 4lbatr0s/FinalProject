using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public static string ProductUpdated = "Product Updated";
        public static string UnitPriceInvalid = "Unit price is invalid";
        public static string CategoryNumberIsRestricted = "Category number is restricted";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User is not found.";
        public static string PasswordError = "Password error.";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "This user already exists";
        public static string AccessTokenCreated = "Access token is created";

        public static string AuthorizationDenied = "Authorization is denied";

        public static string CategoryLimitExceeded = "Category limit exceeded";

        public static string ProductNameExistsError = "Product name already exists";

        public static string ProductCountOfCategoryError = "Category cannot contain more than 10 products!";

    }
}
