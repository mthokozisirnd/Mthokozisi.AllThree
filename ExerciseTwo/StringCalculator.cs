using System.Text;

public class StringCalculator
{
    public static int AddNumbers(string args)
    {
        if (string.IsNullOrEmpty(args))
        {
            return 0;
        }

        var delimeters = new List<char>()
                                    {
                                        '\n',','
                                    };

        if (args[0] == '/')
        {
            var customDelimeter = args[2];
            delimeters.Add(customDelimeter);
            args = args.Remove(0,
                               3);

        }

        var numbers = args.ToCharArray().Where(x => !delimeters.Contains(x)).ToList();

        if (numbers.Any(x => x == '-'))
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0;
                 i < numbers.Count;
                 i++)
            {
                if (numbers[i] == '-')
                {
                    stringBuilder.Append("-");
                    stringBuilder.Append(numbers[++i]);
                    stringBuilder.Append(", ");
                }
            }

            throw new Exception(string.Format("negatives {0} not allowed", stringBuilder.ToString()));
        }

        var sum = numbers.Sum(x => (int)Char.GetNumericValue(x));

        return sum;
    }
}
