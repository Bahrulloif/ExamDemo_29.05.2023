using Dapper;
using Npgsql;

public class CategoryService
{
     private DapperContext _context;
    public CategoryService()
    {
        _context = new DapperContext();
    }
    public List<Category> GetCategories()
    {
        var connection = _context.CreateConnection();
        var sql = "SELECT * FROM categories";
        return connection.Query<Category>(sql).ToList();
    }

    public Category CreateCategory(Category category)
    {
        var connection = _context.CreateConnection();
        var sql="insert into categories (id, name) "+
        "values (@id, @Name) returning id";
        var createdId = connection.ExecuteScalar<int>(sql,category);
         category.Id = createdId;
        return category;
    }

    public int UpdateCategory(Category category){
        var connection=_context.CreateConnection();
        var sql="update categories set name=@Name where id=@id";
        var response=connection.Execute(sql,category);
        return response;
    }

    public int DeleteCategory(int id){
        var connection=_context.CreateConnection();
        var sql="delete from categories where id=@id";
        var response=connection.Execute(sql,new {id});
        return response;
    }

}