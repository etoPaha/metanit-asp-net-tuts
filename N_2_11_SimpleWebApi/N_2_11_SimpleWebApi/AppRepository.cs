namespace N_2_11_SimpleWebApi;

public static class AppRepository
{
    private static readonly List<Person> Users = MockDb.GetUsers();

    public static async Task GetAllPeople(HttpResponse response)
    {
        await response.WriteAsJsonAsync(Users);
    }
    
    public static async Task GetPerson(string? id, HttpResponse response)
    {
        Person? user = Users.FirstOrDefault((u) => u.Id == id);
        if (user != null)
        {
            
        }
        else
        {
            response.StatusCode = 404;
            await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
        }
    }

    public static async Task CreatPerson(HttpResponse response, HttpRequest request)
    {
        try
        {
            var user = await request.ReadFromJsonAsync<Person>();
            if (user != null)
            {
                user.Id = Guid.NewGuid().ToString();
                
                Users.Add(user);

                await response.WriteAsJsonAsync(user);
            }
            else
            {
                throw new Exception("Некорректные данные");
            }
        }
        catch (Exception)
        {
            response.StatusCode = 400;
            await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
        }
    }

    public static async Task UpdatePerson(HttpResponse response, HttpRequest request)
    {
        try
        {
            Person? userData = await request.ReadFromJsonAsync<Person>();
            if (userData != null)
            {
                var user = Users.FirstOrDefault(u => u.Id == userData.Id);
                if (user != null)
                {
                    user.Name = userData.Name;
                    user.Age = userData.Age;

                    await response.WriteAsJsonAsync(user);
                }
                else
                {
                    response.StatusCode = 404;
                    await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
                }
            }
            else
            {
                throw new Exception("Некорректные данные");
            }
        }
        catch (Exception)
        {
            response.StatusCode = 400;
            await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
        }
    }
    
    public static async Task DeletePerson(string? id, HttpResponse response)
    {
        Person? user = Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            Users.Remove(user);

            await response.WriteAsJsonAsync(user);
        }
        else
        {
            response.StatusCode = 404;
            await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
        }
    }
}