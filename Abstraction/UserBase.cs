using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TransactionTracker.Model;

namespace TransactionTracker.Abstraction
{
    public abstract class UserBase
    {
        protected static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");
        protected List<Users> LoadUsers()
        {
            if (File.Exists(FilePath)) return new List<Users>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();

        }
        protected void SaveUsers(List<Users> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, json);
        }
    }
}
