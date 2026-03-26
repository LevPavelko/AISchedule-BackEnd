using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace AIScheduleUI5.BLL.Services
{
    public class SecureService : ISecureService
    {
        private readonly IConfiguration _config;

        public SecureService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(UserDto userDTO)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.UserData, userDTO.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string EncryptSessionGuid(Guid plainGuid)
        {
            var key = _config["Session:Secret"];

            using (var aesAlg = Aes.Create())
            using (var sha256 = SHA256.Create())
            {
                aesAlg.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                aesAlg.IV = new byte[16];

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainGuid.ToString("D"));   // write the Guid string
                    sw.Flush();
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public Guid DecryptSessionGuid(string cipherText)
        {



            var key = _config["Session:Secret"];

            using (var aesAlg = Aes.Create())
            using (var sha256 = SHA256.Create())
            {
                aesAlg.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                aesAlg.IV = new byte[16];

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                var cipherBytes = Convert.FromBase64String(cipherText);

                using (var ms = new MemoryStream(cipherBytes))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    var plainText = sr.ReadToEnd();
                    return Guid.Parse(plainText);
                }
            }
        }

        public string DecryptPassword(string cipherTextBase64)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_config["Keys:SecretKey"]);
            var ivBytes = Encoding.UTF8.GetBytes(_config["Keys:IvString"]);

            var cipherBytes = Convert.FromBase64String(cipherTextBase64);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);
            return sr.ReadToEnd(); // original plaintext string
        }

        public string EncryptPassword(string plainText)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_config["Keys:SecretKey"]);
            var ivBytes = Encoding.UTF8.GetBytes(_config["Keys:IvString"]);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs, Encoding.UTF8))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }



    }
}
