namespace MedicalCenters.Identity.Exceptions
{
    public class LoginFailedException : Exception
    {
        public bool IsUserFound { get; private set; }
        public LoginFailedException(bool isUserFound = false)
            : base(isUserFound ? "نام کاربری یا رمز عبور صحیح نمی باشد" : "نام کاربری یافت نشد")
        {
            IsUserFound = isUserFound;
        }
    }
}
