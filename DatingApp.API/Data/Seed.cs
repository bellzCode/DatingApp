using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public static  void Seedusers(DataContext context)
        {
            if (!context.users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var user = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var item in user)
                {
                    byte[] passwordhash, passwordsalt;
                    CreatePassworodHash("password",
                                        out passwordhash,
                                        out passwordsalt);

                    item.PasswordHash = passwordhash;
                    item.PasswordSalt = passwordsalt;
                    item.UserName = item.UserName.ToLower();
                    context.users.Add(item);
                }

                context.SaveChanges();
            }

        }

        private static void CreatePassworodHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // throw new NotImplementedException();
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
    }
}