using ASPNET3.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace ASPNET3
{
    public class Repository(IOptions<List<Book>> books, IOptions<List<Profile>> profiles)
    {
        private readonly List<Book> _booksTable = books.Value;
        private readonly List<Profile> _profilesTable = profiles.Value;

        public IEnumerable<Book> GetBooks()
        {
            return _booksTable;
        }

        public Profile? GetProfile(int id)
        {
            return _profilesTable.FirstOrDefault(p => p.Id == id);
        }
    }
}