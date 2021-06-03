using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            Console.WriteLine("Hello World!");
            //AddClientModel model = new AddClientModel
            //{
            //    FirstName = "ivanov",
            //    LastName = "Ivan",
            //    MiddleName = "Ivanovich",
            //    Phone = "0965478",
            //    Email = "fg@com.gh",
            //    BulkStatusId = 1,
            //    Male = "m",
            //    СommentAboutСlient = "dfbnjytbj"
            // };

            // controller.AddClientDTO(model);
            List<ClientModel> models = controller.GetClientsModels();
        }
    }
}