using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SMW.Models;

namespace SMW.Utilities
{
    public static class GetErrors
    {
        public static string IdentityErrors(IEnumerable<IdentityError> errors)
        {
            var errorBag = new StringBuilder();

            foreach(var error in errors){
                errorBag.Append(error.Description);
            }

            return errorBag.ToString();
        }
    }
}