namespace ria.smc.associates.UI.Utilities;
public static class AppConstants
{
    public static readonly string HEAD_TITLE = "RIA Associates";

    public static readonly string CONTROLLER_HOME = "Home";
    public static readonly string CONTROLLER_LOGIN = "Login";

    public static readonly string ACTION_INDEX_CONTROLLER_HOME = "Index";
    public static readonly string ACTION_INDEX_CONTROLLER_LOGIN = "Index";

    public static readonly string COOKIE_USER_KEY ="UserInfo";
    public static readonly string COOKIE_AccessToken = "RIARequest";

    public static readonly string AUTH_USERNAME = "UserName";
    public static readonly string Auth_UserID = "UserId";
    public static readonly string AUTH_FULLNAME = "FullName";
    public static readonly string AUTH_EMAIL = "Email";
    public static readonly string AUTH_ROLE = "Role";
    public static readonly string AUTH_ROLEID = "RoleId";
    public static readonly string AUTH_PROFILEPICPATH = "ProfilePicPath";

    public static readonly string URL_Loginin_Index = "/Login/Index";

}

public static class ApplicationMessages
{
    public static string UnableToPersist = "Unable to save the record";
    public static string MessageInCaseOfException = "Some unknown error occurred, contact administration";
    public static string ProceesSignUpRequest = "Processed supplier sign up request";
    public static string ProceesSignInRequest = "Processed supplier sign in request";
    public static string ExceptionWhileProcessing = "Exception thrown while processing supplier singup";
    public static string InvalidParameters = "Enter correct user name and password to proceed";
    public static string NotDataFound = "No data found";
    public static string EmailFormate = "Email formate is not correct";
    public static string ValidationFailled = "Fields are required";
}
