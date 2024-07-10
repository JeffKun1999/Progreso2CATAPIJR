using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Progreso2CATAPIJR.Services;
using Progreso2CATAPIJR.Models;


namespace Progreso2CATAPIJR.Services
{
    public class SQLiteServiceJR
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteServiceJR()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cats.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<CatImageJR>().Wait();
        }

        public Task<int> SaveCatImageAsync(CatImageJR catImage)
        {
            return _database.InsertAsync(catImage);
        }

        public Task<List<CatImageJR>> GetCatImagesAsync()
        {
            return _database.Table<CatImageJR>().ToListAsync();
        }
    }
}