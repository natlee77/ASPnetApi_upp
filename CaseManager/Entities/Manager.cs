﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace CaseManager.Entities
{
    public partial class Manager
    {
        public Manager()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual SessionsToken SessionsToken { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }


        public void CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool ValidatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)//jämfora
                {
                    if (computedHash[i] != PasswordHash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
