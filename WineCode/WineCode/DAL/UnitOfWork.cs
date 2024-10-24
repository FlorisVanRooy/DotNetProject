using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Data;
using WineCode.Models;

namespace WineCode.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private WineContext _context;

        private IRepository<Category> categoryRepository;
        private IRepository<Country> countryRepository;
        //private IRepository<Favorite> favoriteRepository;
        private IRepository<Kind> kindRepository;
        private IRepository<Recipe> recipeRepository;
        private IRepository<Wine> wineRepository;

        public UnitOfWork(WineContext context) { 
            _context = context;
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(_context);
                }
                return categoryRepository;
            }
        }


        public IRepository<Country> CountryRepository
        {
            get
            {
                if (countryRepository == null)
                {
                    countryRepository = new GenericRepository<Country>(_context);
                }
                return countryRepository;
            }
        }

        //public IRepository<Favorite> FavoriteRepository
        //{
        //    get
        //    {
        //        if (favoriteRepository == null)
        //        {
        //            favoriteRepository = new GenericRepository<Favorite>(_context);
        //        }
        //        return favoriteRepository;
        //    }
        //}

        public IRepository<Kind> KindRepository
        {
            get
            {
                if (kindRepository == null)
                {
                    kindRepository = new GenericRepository<Kind>(_context);
                }
                return kindRepository;
            }
        }

        public IRepository<Recipe> RecipeRepository
        {
            get
            {
                if (recipeRepository == null)
                {
                    recipeRepository = new GenericRepository<Recipe>(_context);
                }
                return recipeRepository;
            }
        }

        public IRepository<Wine> WineRepository
        {
            get
            {
                if (wineRepository == null)
                {
                    wineRepository = new GenericRepository<Wine>(_context);
                }
                return wineRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
