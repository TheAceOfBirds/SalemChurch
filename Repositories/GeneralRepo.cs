using Dapper;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BlankMVC.Repositories
{
    public class GeneralRepo
    {
        private SQLiteConnection GeneralDb;
        public GeneralRepo(string DbPath)
        {
            GeneralDb = new SQLiteConnection(DbPath);
        }
        public void InitializeTypes()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<BlankMVC.Models.Type> types =  GeneralDb.QueryAsync<BlankMVC.Models.Type>("Select Id, Name From Type").Result.ToList();
            foreach(BlankMVC.Models.Type type in types)
            {
                selectListItems.Add(new SelectListItem
                {
                    Text = type.Name,
                    Value = type.Id.ToString()
                });
            }
            GlobalVariables.Types = selectListItems;
        }
    }
}
