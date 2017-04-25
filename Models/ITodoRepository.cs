using System.Collections.Generic;

//interface that enables multiple implementations of
//persistence schemes and testing using repos with
//mock data.
//As long as the a repository class implements this 
//interface aka. this set of methods, the system works.
namespace TodoAPI.Models {
    public interface ITodoRepository {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(long key);
        void Update(TodoItem item);
        void Remove(TodoItem item);
    }
}