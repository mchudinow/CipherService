namespace CipherService.Models
{
    /// <summary>
    /// Представляет модель запроса для операций с шифром Цезаря.
    /// </summary>
    public class CipherRequest
    {
        /// <summary>
        /// Получает или задает входные данные для шифрования или дешифрования.
        /// </summary>
        public string InputData { get; set; }

        /// <summary>
        /// Получает или задает значение сдвига для шифра Цезаря.
        /// </summary>
        /// <remarks>
        /// Сдвиг определяет, на сколько позиций символы будут смещены.
        /// Положительные значения означают сдвиг вправо, отрицательные — влево.
        /// </remarks>
        public int Shift { get; set; }

    }
}
