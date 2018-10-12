namespace it.core.Examples.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}