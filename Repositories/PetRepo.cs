using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SQLite;
using Dapper;
namespace BlankMVC.Repositories
{
    public class PetRepo
    {
        private SQLiteConnection GeneralDb;
        public PetRepo(string DbPath)
        {
            GeneralDb = new SQLiteConnection(DbPath);
        }
        public List<Pet> getPetList()
        {
            string query = @"SELECT 
                                    Id,
                                    Name,
                                    Type,
                                    Birthday,
                                    OwnerEmail,
                                    Fixed
                               FROM Pet";

            return GeneralDb.QueryAsync<Pet>(query).Result.ToList();
        }
        public Pet getPetById(int id)
        {
            string query = @"SELECT 
                                    Id,
                                    Name,
                                    Type,
                                    Birthday,
                                    OwnerEmail,
                                    Fixed
                               FROM Pet
                            where Id = " + id;

            return GeneralDb.QueryAsync<Pet>(query).Result.First();
        }
        public bool insertNewPet(Pet pet)
        {
            try
            {
                string query = @"Insert into Pet( 
                                    Name,
                                    Type,
                                    Birthday,
                                    OwnerEmail,
                                    Fixed)
                                VALUES(@Name, @Type, @Birthday,@OwnerEmail,@Fixed)";
                GeneralDb.Execute(query,pet);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool deletePet(int id)
        {
            try
            {
                string query = @"Delete From Pet
                                WHERE Id = " + id;
                GeneralDb.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool updatePet(Pet pet)
        {
            try
            {
                string query = @"update Pet( 
                                    Name,
                                    Type,
                                    Birthday,
                                    OwnerEmail,
                                    Fixed)
                                VALUES(@Name, @Type, @Birthday,@OwnerEmail,@Fixed)";
                GeneralDb.Execute(query,pet);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
