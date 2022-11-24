namespace N_2_11_SimpleWebApi;

public class MockDb
{
    public static List<Person> GetUsers()
    {
        return new List<Person>
        {
            new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
            new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
            new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
        };
    }
}