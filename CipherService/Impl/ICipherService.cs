namespace CipherService.Impl
{
    public interface ICipherService
    {
        /// <summary>
        /// Шифрует строку с использованием шифра Цезаря.
        /// </summary>
        /// <param name="inputData">Входная строка для шифрования.</param>
        /// <param name="shift">Значение сдвига.</param>
        /// <returns>Зашифрованная строка.</returns>
        string EncryptData(string inputData, int shift);

        /// <summary>
        /// Дешифрует строку с использованием шифра Цезаря.
        /// </summary>
        /// <param name="inputData">Входная строка для дешифрования.</param>
        /// <param name="shift">Значение сдвига.</param>
        /// <returns>Дешифрованная строка.</returns>
        string DecryptData(string inputData, int shift);
    }
}
