using System.Collections.Generic;

namespace TodoAPI.Models {
    public interface ITodoRepository {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(long key);
        void Update(TodoItem item);
    }
}