using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void CategoryAdd(Category category);
        void CategoryUpdate(Category category);
        void CategoryDelete(Category category);
        Category GetById(int id);
        List<Category>GetList();
    }
}
