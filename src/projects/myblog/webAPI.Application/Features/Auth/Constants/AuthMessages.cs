namespace Application.Features.Auth.Constants;

public static class AuthMessages
{
    public const string EmailAuthenticatorDontExists = "E-posta kimlik doðrulayýcý mevcut deðil.";
    public const string OtpAuthenticatorDontExists = "Tek seferlik þifre kimlik doðrulayýcý mevcut deðil.";
    public const string AlreadyVerifiedOtpAuthenticatorIsExists = "Zaten doðrulanmýþ bir tek seferlik þifre kimlik doðrulayýcý mevcut.";
    public const string EmailActivationKeyDontExists = "E-posta aktivasyon anahtarý mevcut deðil.";
    public const string UserDontExists = "Kullanýcý mevcut deðil.";
    public const string UserHaveAlreadyAAuthenticator = "Kullanýcýnýn zaten bir kimlik doðrulayýcý mevcut.";
    public const string RefreshDontExists = "Yenileme mevcut deðil.";
    public const string InvalidRefreshToken = "Geçersiz yenileme belirteci.";
    public const string UserMailAlreadyExists = "Kullanýcý e-postasý zaten mevcut.";
    public const string PasswordDontMatch = "Mevcut þifreniz hatalý.";
}
