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
        /// ������������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        /// 
        ///     POST /Cipher/Encrypt
        ///     {
        ///        "InputData": "������",
        ///        "Shift": 7
        ///     }
        /// </remarks>
        [HttpPost("Encrypt")]
        [ProducesResponseType(typeof(CipherResponse), 200)] // ����� �������� ���� ������
        public IActionResult Encrypt([FromBody] CipherRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.InputData))
            {
                return BadRequest("������� ������ �� ����� ���� �������.");
            }

            if (request.InputData.Length > 255)
                return BadRequest("������ ������ ���� ������ 256 ��������!");
            string encryptedData = _cipherService.EncryptData(request.InputData, request.Shift);
            if (string.IsNullOrEmpty(encryptedData))
                return BadRequest("������! ��������� ������� ������!");

            return Ok(new CipherResponse(encryptedData, request.Shift));
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        /// 
        ///     POST /Cipher/Encrypt
        ///     {
        ///        "InputData": "UVIVNL",
        ///        "Shift": 7
        ///     }
        /// </remarks>
        [HttpPost("Decrypt")]
        [ProducesResponseType(typeof(CipherResponse), 200)] // ����� �������� ���� ������
        public IActionResult Decrypt([FromBody] CipherRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.InputData))
            {
                return BadRequest("������� ������ �� ����� ���� �������.");
            }
            if (request.InputData.Length > 255)
                return BadRequest("������ ������ ���� ������ 256 ��������!");
            string decryptedData = _cipherService.DecryptData(request.InputData, request.Shift);
            if (string.IsNullOrEmpty(decryptedData))
                return BadRequest("������! ��������� ������� ������!");
            return Ok(new CipherResponse(decryptedData, request.Shift));
        }
    }
}
