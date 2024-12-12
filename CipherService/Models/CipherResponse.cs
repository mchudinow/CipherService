namespace CipherService.Models
{
    /// <summary>
    /// Представляет модель ответа для операций с шифром Цезаря.
    /// </summary>
    public class CipherResponse
    {
        /// <summary>
        /// Получает или задает выходные данные после шифрования или дешифрования.
        /// </summary>
        public string OutputData { get; set; }

        /// <summary>
        /// Возращает значение сдвига для шифра Цезаря.
        /// </summary>
        /// <remarks>
        /// Сдвиг определяет, на сколько позиций символы будут смещены.
        /// Положительные значения означают сдвиг вправо, отрицательные — влево.
        /// </remarks>
        public int Shift { get; set; }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="outputData"></param>
        public CipherResponse(string outputData, int shift)
        {
            OutputData = outputData;
            Shift = shift;
        }
    }
}