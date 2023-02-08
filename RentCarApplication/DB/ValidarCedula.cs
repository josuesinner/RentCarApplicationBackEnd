using System.Text.RegularExpressions;

namespace RentCarApplication.DB
{
    public class ValidarCedula
    {
        public bool IsValidIdNumber(string str)
        {
            var regex = new Regex("^[0-9]{3}-?[0-9]{7}-?[0-9]{1}$");
            if (!regex.IsMatch(str))
                return false;

            str = str.Replace("-", "");
            if (str.Split().All(x => x == "0"))
                return false;

            return CheckDigits(str);
        }

        private bool CheckDigits(string str)
        {
            var sum = 0;

            for (int i = 0; i < 10; i++)
            {
                var n = ((i + 1) % 2 != 0 ? 1 : 2) * int.Parse(str[i].ToString());
                sum += (n <= 9 ? n : n % 10 + 1);
            }
            var digit = ((10 - sum % 10) % 10);
            return digit == int.Parse(str[10].ToString());
        }
    }
}
