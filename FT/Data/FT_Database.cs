using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using FT.Models;

namespace FT.Data
{
    public class FT_Database
    {
        readonly SQLiteAsyncConnection database;

        public FT_Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<FuelRecord>().Wait();
        }

        public Task<List<FuelRecord>> GetFuelRecordsAsync()
        {
            //Get all fuel records.
            return database.Table<FuelRecord>().ToListAsync();
        }

        public Task<FuelRecord> GetFuelRecordAsync(int id)
        {
            // Get a specific fuel record.
            return database.Table<FuelRecord>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFuelRecordAsync(FuelRecord fr)
        {
            if (fr.ID != 0)
            {
                // Update an existing fuel record.
                return database.UpdateAsync(fr);
            }
            else
            {
                // Save a new fuel record.
                return database.InsertAsync(fr);
            }
        }

        public Task<int> DeleteFuelRecordAsync(FuelRecord fr)
        {
            // Delete a fuel record.
            return database.DeleteAsync(fr);
        }
    }
}