using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Authoize
{
    internal static class CustomSecurityKey
    {
        private const string Key = "fguyw47wy376tymnqt@ysdrutge4!7878jsecryg66faw3h#fgj6sxd345453456e46hzqj45645745f76546mgfi";
        internal static SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
