namespace Application.Features.Auth.Constants;

public static class AuthMessages
{
    public const string EmailAuthenticatorDontExists = "E-posta kimlik do�rulay�c� mevcut de�il.";
    public const string OtpAuthenticatorDontExists = "Tek seferlik �ifre kimlik do�rulay�c� mevcut de�il.";
    public const string AlreadyVerifiedOtpAuthenticatorIsExists = "Zaten do�rulanm�� bir tek seferlik �ifre kimlik do�rulay�c� mevcut.";
    public const string EmailActivationKeyDontExists = "E-posta aktivasyon anahtar� mevcut de�il.";
    public const string UserDontExists = "Kullan�c� mevcut de�il.";
    public const string UserHaveAlreadyAAuthenticator = "Kullan�c�n�n zaten bir kimlik do�rulay�c� mevcut.";
    public const string RefreshDontExists = "Yenileme mevcut de�il.";
    public const string InvalidRefreshToken = "Ge�ersiz yenileme belirteci.";
    public const string UserMailAlreadyExists = "Kullan�c� e-postas� zaten mevcut.";
    public const string PasswordDontMatch = "Mevcut �ifreniz hatal�.";
}
