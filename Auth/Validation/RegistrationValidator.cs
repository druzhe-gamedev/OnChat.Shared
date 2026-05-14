using System.Text.RegularExpressions;
using OnChat.Shared.Validation;

namespace OnChat.Shared.Auth.Validation;

public partial class RegistrationValidator : ValidatorBase<RegistrationPacket>
{
    public static readonly LengthConstraint PasswordConstraint = new (new MinMaxValue<int>(5, 255));
    public static readonly LengthRegexConstraint<byte> LoginConstraint = new (new MinMaxValue<byte>(3, 50), LoginRegex());
    public static readonly LengthRegexConstraint<byte> MailConstraint = new (new MinMaxValue<byte>(3, 255), MailRegex());

    [GeneratedRegex("^[a-zA-Z0-9][a-zA-Z0-9._-]{2,47}[a-zA-Z0-9]$")]
    private static partial Regex LoginRegex();
    

    [GeneratedRegex("^(?=.{1,254}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
    private static partial Regex MailRegex();

    public RegistrationValidator()
    {
        AddConstraint(packet => packet.Password, PasswordConstraint);
        AddConstraint(packet => packet.Email, MailConstraint);
        AddConstraint(packet => packet.Username, LoginConstraint);
        AddConstraint(packet => packet.Age, new MinMaxConstraint<short>(new MinMaxValue<short>(14, 99)));
    }
}