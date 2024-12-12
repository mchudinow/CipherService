using CipherService.Impl;
using CipherService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace CipherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CipherController : ControllerBase
    {
        private readonly ICipherService _cipherService;
        public CipherController(ICipherService cipherService)
        {
            _cipherService = cipherService;
        }
        /// <summary>
        /// Закодировать
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Cipher/Encrypt
        ///     {
        ///        "InputData": "АБОБУС",
        ///        "Shift": 7
        ///     }
        /// </remarks>
        [HttpPost("Encrypt")]
        [ProducesResponseType(typeof(CipherResponse), 200)] // Явное указание типа ответа
        public IActionResult Encrypt([FromBody] CipherRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.InputData))
            {
                return BadRequest("Входные данные не могут быть пустыми.");
            }

            if (request.InputData.Length > 255)
                return BadRequest("Строка должна быть меньше 256 символов!");
            string encryptedData = _cipherService.EncryptData(request.InputData, request.Shift);
            if (string.IsNullOrEmpty(encryptedData))
                return BadRequest("Ошибка! Проверьте входные данные!");

            return Ok(new CipherResponse(encryptedData, request.Shift));
        }

        /// <summary>
        /// Декодировать
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /Cipher/Encrypt
        ///     {
        ///        "InputData": "UVIVNL",
        ///        "Shift": 7
        ///     }
        /// </remarks>
        [HttpPost("Decrypt")]
        [ProducesResponseType(typeof(CipherResponse), 200)] // Явное указание типа ответа
        public IActionResult Decrypt([FromBody] CipherRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.InputData))
            {
                return BadRequest("Входные данные не могут быть пустыми.");
            }
            if (request.InputData.Length > 255)
                return BadRequest("Строка должна быть меньше 256 символов!");
            string decryptedData = _cipherService.DecryptData(request.InputData, request.Shift);
            if (string.IsNullOrEmpty(decryptedData))
                return BadRequest("Ошибка! Проверьте входные данные!");
            return Ok(new CipherResponse(decryptedData, request.Shift));
        }
    }
}
