using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIScheduleUI5.BLL.DTOs;

namespace AIScheduleUI5.BLL.Interfaces
{
    public interface ISecureService
    {
        string GenerateJwtToken(UserDto userDTO);
        string EncryptSessionGuid(Guid plainGuid);
        Guid DecryptSessionGuid(string cipherText);
        string DecryptPassword(string cipherTextBase64);
        string EncryptPassword(string plainText);


    }
}
