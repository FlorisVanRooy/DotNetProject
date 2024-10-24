using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineCode.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Category> CategoryRepository { get; }
        IRepository<Country> CountryRepository { get; }
        //IRepository<Favorite> FavoriteRepository { get; }
        IRepository<Kind> KindRepository { get; }
        IRepository<Recipe> RecipeRepository { get; }
        IRepository<Wine> WineRepository { get; }

        void Save();
    }
}
