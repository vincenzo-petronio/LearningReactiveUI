using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Todo>> GetTodoItems();
    }
}
