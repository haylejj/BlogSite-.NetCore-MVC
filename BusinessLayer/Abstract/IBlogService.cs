using EntityLayer.Concrete;


namespace BusinessLayer.Abstract
{
    public  interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByAuthor(int id);
    }
}
