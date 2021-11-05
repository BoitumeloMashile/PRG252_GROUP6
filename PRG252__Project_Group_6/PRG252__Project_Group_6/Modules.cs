using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace PRG252__Project_Group_6
{
    class Modules
    {
        string moduleCode;
        string moduleName;
        string moduleDescription;
        string links;


        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public string ModuleDescription { get => moduleDescription; set => moduleDescription = value; }
        public string Links { get => links; set => links = value; }


        public Modules(string moduleCode, string moduleName, string moduleDescription, string links)
        {
            this.moduleCode = moduleCode;
            this.moduleName = moduleName;
            this.moduleDescription = moduleDescription;
            this.links = links;

        }
        public Modules()
        {

        }
        public void InsertModules(string moduleCode, string moduleName, string moduleDescription, string links)
        {
            DataHandler db = new DataHandler();
            db.CreateModule(moduleCode, moduleName, moduleDescription, links);
        }
        public void UpdateModules(ArrayList list)
        {
            DataHandler db = new DataHandler();
            db.UpdateModuleTable(list);
        }
        public List<Modules> PopulateModules()
        {
            List<Modules> Modulelist = new List<Modules>();
            DataHandler db = new DataHandler();
            DataSet rawData = db.ReadData("tbl_Modules");
            foreach (DataRow item in rawData.Tables["tbl_Modules"].Rows)
            {
                Modulelist.Add(new Modules(item["ModuleCode"].ToString(), item["ModuleName"].ToString(), item["ModuleDescription"].ToString(), item["Links"].ToString()));
            }
            return Modulelist;
        }

        public void DeleteModulesFromDB(string codeToDelete)
        {
            DataHandler db = new DataHandler();
            db.DeleteModules(codeToDelete);
        }
        public List<Modules> GetSpecificModules(string idParam)
        {
            List<Modules> Modulelist = new List<Modules>();
            DataHandler db = new DataHandler();
            DataSet rawData = db.ReadData("tbl_Modules");
            foreach (DataRow item in rawData.Tables["tbl_Modules"].Rows)
            {
                Modulelist.Add(new Modules(item["ModuleCode"].ToString(), item["ModuleName"].ToString(), item["ModuleDescription"].ToString(), item["Links"].ToString()));
            }
            return Modulelist;
        }
    }
}

