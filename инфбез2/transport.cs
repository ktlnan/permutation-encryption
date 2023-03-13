using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace инфбез2
{
    internal class transport
    {
        private int[] key = null; //объявление ссылочной переменной под одномерный массив

        public void SetKey(int[] _key) //массив целых чисел, создаём копию массива _key.
        {
            key = new int[_key.Length];

            for (int i = 0; i < _key.Length; i++)
                key[i] = _key[i];
        }

        public void SetKey(string[] _key) //перегруженная версия метода SetKey принимает на вход массив ключа, элементы которого представлены строками.
        {
            key = new int[_key.Length];

            for (int i = 0; i < _key.Length; i++)
                key[i] = Convert.ToInt32(_key[i]);
        }

        public void SetKey(string _key) // принимает на вход строку, в которой содержится ключ.
        {
            SetKey(_key.Split(' ')); //С помощью метода Split разделяем строку на массив строк по разделителю — пробелу
        }

        public string Encrypt(string input) //шифрование
        {
            for (int i = 0; i < input.Length % key.Length; i++) //доводим длину входной строки до числа без остатка делящегося на длину ключа
                input += input[i]; // прибавления в конец строки нужного количества символов из ее начала

            string result = ""; //Объявляем строковую переменную, в которой будем хранить результат

            for (int i = 0; i < input.Length; i += key.Length) //проходимся по всем блокам исходного сообщения длиной в ключ
            {
                char[] transposition = new char[key.Length]; //transposition зашифрованный текст 

                for (int j = 0; j < key.Length; j++)// перебираем все символы блока и шифруем
                    transposition[key[j] - 1] = input[i + j];

                for (int j = 0; j < key.Length; j++) //посимвольно прибавляем зашифрованный блок к концу строковой переменной с результатом
                    result += transposition[j];
            }

            return result;// Возвращаем из метода результат
        }

        public string Decrypt(string input) //расшифровка, отсутствует код, доводящий входную строку до нужно длины, тк ашифрованный текст уже имеет необходимую длину
        {
            string result = "";

            for (int i = 0; i < input.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[j] = input[i + key[j] - 1];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            return result;
        }
    }
}
