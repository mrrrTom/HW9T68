// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

namespace HW9
{
    public class ConsoleApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Akkerman function calculator! Insert two natural numbers (example: 1, 2):");
            var input = Console.ReadLine();
            if (!TryParse(input, out var numbers))
            {
                Console.WriteLine("Program could not handle inserted values! ... Bye!");
            }

            Console.WriteLine(A(numbers[0], numbers[1]));
        }

        static int A(int m, int n)
        {
            if (m ==0)
            {
                return n + 1;
            }

            if (m > 0 && n == 0)
            {
                return A(m - 1, 1);
            }

            return A(m - 1, A(m, n - 1));
        }

        static bool TryParse(string input, out int[] result)
        {
            result = new int[2];
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var arr = input.Split(',');
            if (arr.Length != 2)
            {
                return false;
            }

            var hasError = false;
            result = arr.Select(v => { if ( int.TryParse(v, out var number)) { return number; } else { hasError = true; return 0; }; }).ToArray();
            if (hasError)
            {
                return false;
            }

            return true;
        }
    }
}