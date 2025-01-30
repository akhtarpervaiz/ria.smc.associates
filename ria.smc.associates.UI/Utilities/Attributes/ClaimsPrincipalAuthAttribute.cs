using System.Security.Claims;

namespace ria.smc.associates.UI.Utilities.Attributes;
public static class ClaimsPrincipalAuthAttribute
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return 0;

        var userId = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.Auth_UserID)?.Value;
        if (!string.IsNullOrWhiteSpace(userId))
            return Convert.ToInt32(userId);

        return 0;
    }

    public static string GetUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return "";

        var userName = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_USERNAME)?.Value;
        if (!string.IsNullOrWhiteSpace(userName))
            return userName;

        return "";
    }

    public static string GetFullName(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return "";

        var fullName = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_FULLNAME)?.Value;
        if (!string.IsNullOrWhiteSpace(fullName))
            return fullName;

        return "";
    }

    public static string GetEmail(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return "";

        var email = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_EMAIL)?.Value;
        if (!string.IsNullOrWhiteSpace(email))
            return email;

        return "";
    }

    public static int GetRoleId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return 0;

        var roleId = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_ROLEID)?.Value;
        if (!string.IsNullOrWhiteSpace(roleId))
            return Convert.ToInt32(roleId);

        return 0;
    }

    public static string GetRoleName(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return "";

        var roleName = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_ROLE)?.Value;
        if (!string.IsNullOrWhiteSpace(roleName))
            return roleName;

        return "";
    }
    public static string GetProfilePicturePath(this ClaimsPrincipal principal)
    {
        if (principal == null)
            return "";

        var picturePath = principal.Claims.FirstOrDefault(c => c.Type == AppConstants.AUTH_PROFILEPICPATH)?.Value;
        if (!string.IsNullOrWhiteSpace(picturePath))
            return picturePath;

        return "";
    }
}