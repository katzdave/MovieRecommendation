﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using MovieServer.Setup;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MovieServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //SetupMain.main();

            DataStore ds = LoadDataStore();
            ds.GenerateRandomFeatures(10);

            var wsm = new WebServerMain(ds);
            wsm.Run();
        }

        public static DataStore LoadDataStore()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ImdbDataStore.bin",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            DataStore obj = (DataStore)formatter.Deserialize(stream);
            stream.Close();

            return obj;
        }
    }
}