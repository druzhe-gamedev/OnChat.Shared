using System.Linq.Expressions;

namespace OnChat.Shared.Validation;

public class ValidatorBase<T, TError> : IValidator<T> where T : BasePacket
{
    private readonly List<Func<T, ValidationResult>> _constraintsChain = [];
    
    public ValidationResult Validate(T packet)
    {
        foreach (Func<T, ValidationResult> validation in _constraintsChain)
        {
            if (validation.Invoke(packet) is ValidationResultError<TError> error)
                return error;
        }

        return ValidationResult.Success();
    }

    public void AddConstraint<TV>(Expression<Func<T, TV>> extract, IConstraint<TV> constraint, TError errorCode, string? errorDescription = "")
    {
        string memberName = GetMemberName(extract);
        _constraintsChain.Add(packet =>
            constraint.IsValid(extract.Compile().Invoke(packet))
                ? ValidationResult.Success()
                : string.IsNullOrEmpty(errorDescription)
                    ? ValidationResult.Error(constraint, memberName, errorCode)
                    : ValidationResult.Error(errorDescription, errorCode)
        );
    }
    private string GetMemberName<TV>(Expression<Func<T, TV>> expression)
    {
        return expression.Body switch
        {
            MemberExpression memberExpr => memberExpr.Member.Name,
            UnaryExpression { Operand: MemberExpression memberExpr } => memberExpr.Member.Name,
            _ => throw new ArgumentException("Expression must be a member access")
        };
    }
}