using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Validators
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);
            password = password.ToLower();
            if (password.Contains("abcdefg") || password.Contains("123456"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Password cannot contain sequences of characters");
                result = new IdentityResult(errors);
            }
            else if (password == "password")
            {
                var errors = result.Errors.ToList();
                errors.Add("That password is not allowed.");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}