namespace REalEstateManagement.ViewModel;

public class Session
{
    public string Email { get; set; }

    public Session() { }

    public Session(string email)
    {
        Email = email;
    }
}