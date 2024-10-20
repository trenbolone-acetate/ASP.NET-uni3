using ASPNET3.Models;

namespace ASPNET3.Services;

public class LibraryService(Repository repository)
{
    public IEnumerable<Book> GetBooks()
    {
        return repository.GetBooks();
    }

    public Profile? GetProfile(int id)
    {
        return repository.GetProfile(id);
    }
}