
//problem:-password validation
//The initial requirement is that password:has to be longer than 8 characters
//can't be the same as the user name
//can't be the same as any of the passwords set by user in the past
public class Password
{
    public string NewPassword { get; set; }
    public List<string> PasswordHistoryItems { get; set; }
    public string Username { get; set; }
}
public class PasswordValidation
{
    private static const int _passLength=8;
    public bool PassValidation(Password password)
    {
        if(password.NewPassword.Length<_passLength || password.NewPassword==password.Username 
        || password.PasswordHistoryItems.Contains(password.NewPassword)){
            return false;
        }
        return true;
    }
}
//problem with this code:-
//1.Think about OCP 
//2.If any changes in password validation you have to change the if block conditions or if your are more
//stupid then you can expose a private function.

//better code
//first define set of rules
public interface IPassValidation
{
 bool IsValid(Password passwordRequest);
}
public class LengthChecker : IPassValidation
{
    private static int _length;
    public LengthChecker(int length)
    {
    _length=length;
    }
    public bool IsValid(Password passwordRequest)
    {
        return passwordRequest.NewPassword.Length>=_length;
    }
}
public class UserNameChecker : IPassValidation
{
    public bool IsValid(Password passwordRequest)
    {
        return passwordRequest.NewPassword!=passwordRequest.Username;
    }
}
public class LengthChecker : IPassValidation
{
    private static int _length;
    public LengthChecker(int length)
    {
    _length=length;
    }
    public bool IsValid(Password passwordRequest)
    {
        return passwordRequest.NewPassword.Length>=_length;
    }
}