using System.Globalization;
using System.Text;

namespace Utility.Components.HCF;

public static class HCFService
{
    public static string ParseWhitespace(string c)
    {
        return c switch
        {
            "\r" => "<span class='symbol S2Tooltip anchor'>CR</span>",
            "\n" => "<span class='symbol S2Tooltip anchor'>LF</span>",
            "\t" => "<span class='symbol S2Tooltip anchor'>&#8594;</span>&#8203;",
            " "  => "<span class='symbol S2Tooltip anchor'>&#183;</span>&#8203;",
            _    => string.Empty
        };
    }

    // Checks that the character is in letter, mark, number, punctuation, or symbol groups.
    public static bool IsRegularUnicodeCharacter(string c)
    {
        var pattern = @"[\p{L}\p{M}\p{N}\p{P}\p{S}]";
        return System.Text.RegularExpressions.Regex.IsMatch(c, pattern);
    }

    public static string HtmlChar(string c)
    {
        // Get the Unicode code point (handles surrogate pairs for characters outside BMP)
        int codePoint;
        if (c.Length == 2 && char.IsHighSurrogate(c[0]) && char.IsLowSurrogate(c[1]))
        {
            codePoint = char.ConvertToUtf32(c[0], c[1]);
        }
        else
        {
            codePoint = (int)c[0];
        }

        var utf8Bytes = Encoding.UTF8.GetBytes(c);

        string desc;
        string hex;

        if (utf8Bytes.Length == 1)
        {
            // Single-byte ASCII: show decimal and 0x hex
            desc = codePoint + "<br>\n0x" + codePoint.ToString("x2");
            hex = codePoint.ToString("X2");
        }
        else
        {
            // Multi-byte Unicode: show HTML entity and Unicode escape
            string unicodeEscape = codePoint <= 0xFFFF
                ? "\\u" + codePoint.ToString("X4")
                : "\\U" + codePoint.ToString("X8");
            desc = "&#" + codePoint + ";<br>\n" + unicodeEscape;
            hex = "U+" + codePoint.ToString("X4");
        }

        var symbol = ParseWhitespace(c);
        if (symbol == string.Empty)
        {
            if (IsRegularUnicodeCharacter(c))
            {
                symbol = "<span class='S2Tooltip anchor'>" + c + "</span>";
            }
            else
            {
                symbol = "<span class='hex S2Tooltip anchor'>" + hex + "</span>";
            }
        }

        return symbol +
            "<span class='S2Tooltip container'>" +
            "<span class='S2Tooltip tiptext rounded shadow'>" + desc + "</span>" +
            "</span>";
    }

    public static (string html, int chars, int bytes) Text2Html(string input)
    {
        var html = new StringBuilder("<div class='output'>\n");
        var totalChars = 0;
        var totalBytes = 0;
        var nlc = 0;

        // \n = LF (Line Feed) — Unix new line
        // \r = CR (Carriage Return) — classic Mac new line
        // \r\n = CR + LF — Windows new line

        var si = new StringInfo(input);
        var elementCount = si.LengthInTextElements;

        for (var i = 0; i < elementCount; i++)
        {
            var c = si.SubstringByTextElements(i, 1);
            totalChars++;
            totalBytes += Encoding.UTF8.GetByteCount(c);

            if (c == "\r")
            {
                if (nlc == 0)
                {
                    nlc = 1;
                    html.Append(HtmlChar(c));
                }
                else if (nlc == 1)
                {
                    html.Append("<br>\n");
                    html.Append(HtmlChar(c));
                    nlc = 1;
                }
                else if (nlc == 2)
                {
                    html.Append(HtmlChar(c));
                    html.Append("<br>\n");
                    nlc = 0;
                }
            }
            else if (c == "\n")
            {
                if (nlc == 0)
                {
                    nlc = 2;
                    html.Append(HtmlChar(c));
                }
                else if (nlc == 2)
                {
                    html.Append("<br>\n");
                    html.Append(HtmlChar(c));
                    nlc = 2;
                }
                else if (nlc == 1)
                {
                    html.Append(HtmlChar(c));
                    html.Append("<br>\n");
                    nlc = 0;
                }
            }
            else
            {
                nlc = 0;
                html.Append(HtmlChar(c));
            }
        }

        html.Append("</div>\n");
        return (html.ToString(), totalChars, totalBytes);
    }
}
