namespace OrderService.Domain.Primitives;


public static class RegexPatterns
{
    
    public const string IsLetters = @"^[^0-9*&%#$@^!?<>/\-'"";:,.]+$";

    
    public const string IsCorrectPhoneNumber = @"^\+37377[5-9]\d{5}$";
}