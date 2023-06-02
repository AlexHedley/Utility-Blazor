namespace Utility.Common;

public static class StringExtensions
{
    // https://stackoverflow.com/a/4405876/2895831
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}

// https://stackoverflow.com/a/41748138/2895831
public static class InvertStringExtension
{
    public static string Invert(this string s)
    {
        char[] chars = s.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
            chars[i] = chars[i].Invert();

        return new string(chars);
    }
}

// https://stackoverflow.com/a/41748138/2895831
public static class InvertCharExtension
{
    public static char Invert(this char c)
    {
        if (!char.IsLetter(c))
            return c;

        return char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
    }
}