using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //
        public static void CreatePasswordHash //input: password, output: passwordHash and passwordSalt
            (string password, out byte[] passwordHash, out byte[] passwordSalt) //HashingHelper's methods are static for the class doesn't have any relativeness, we don't need to new() it.
        {
            //we don't need to return anything because we've declared two OUT values. They're our return values.
            //disposable pattern using(...)
            // we are new()'ing the HMACSHA512 because it creates a class ..
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //salting: hmac.Key creates a new password for each different individual, this is why we hold it in our db(we have  a passwordSalt value in our User)
                passwordSalt = hmac.Key; //Encoding.UTF8.GetBytes(string) = get the byte equivalent of a string
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash //password: user's password, passwordHash:value we're going to create, 
            (string password, byte[] passwordHash, byte[] passwordSalt) 
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //by giving the passwordSalt value to the hmac, we tell the program to compute hash based on byte array of our password.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i]!=passwordHash[i]) //because both computedHash & passwordHash are byte arrays. 
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool VerifyPasswordHash(string password, object passwordHash, object passwordSalt)
        {
            throw new NotImplementedException();
        }
    }
}
