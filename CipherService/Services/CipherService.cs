using CipherService.Impl;

namespace CipherService.Services
{
    public class CipherService : ICipherService
    {
        public string EncryptData(string inputData, int shift)
        {
            char[] buffer = inputData.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)((letter + shift - offset) % 26 + offset);
                }

                buffer[i] = letter;
            }

            return new string(buffer);
        }

        public string DecryptData(string inputData, int shift)
        {
            return EncryptData(inputData, 26 - (shift % 26)); // Сдвиг в обратную сторону
        }
    }
}
