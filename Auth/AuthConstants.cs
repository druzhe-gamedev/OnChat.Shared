using System.Text.RegularExpressions;
using OnChat.Shared.Constants;

namespace OnChat.Shared.Auth;

public static partial class AuthConstants
{
    public static LengthConstraint PasswordConstraint = new (new MinMaxValue<int>(5, 255));
    public static LengthRegexConstraint<byte> LoginConstraint = new (new MinMaxValue<byte>(3, 50), LoginRegex());
    public static LengthRegexConstraint<byte> MailConstraint = new (new MinMaxValue<byte>(3, 255), MailRegex());

    [GeneratedRegex("^[a-zA-Z0-9][a-zA-Z0-9._-]{2,47}[a-zA-Z0-9]$")]
    private static partial Regex LoginRegex();
    

    [GeneratedRegex("^(?=.{1,254}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex MailRegex();
}