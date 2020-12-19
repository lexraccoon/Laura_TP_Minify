using System;
using Minify.Interfaces;

namespace Minify
{
    public class TokenGenerator: ITokenGenerator
    {
        public string Generate()
        {
            string token = Guid.NewGuid().ToString();

            return token;
        }
    }
}