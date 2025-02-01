namespace Palindrome_Number
{
    internal class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            return string.Concat(x.ToString().Reverse()) == x.ToString(); // converter x para string, inverter a string e comparar com a string original, se forem iguais, é palíndromo, caso contrário, não é.
        }
    }
}
