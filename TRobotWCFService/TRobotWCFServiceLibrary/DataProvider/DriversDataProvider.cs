using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataProvider
{
    class DriversDataProvider:IDataProvider
    {
        private Data driversData;

        public DriversDataProvider(Data driversData) 
        {
            this.driversData = driversData;
        }

        public bool ProvideData()
        {
            throw new NotImplementedException();
        }
    }
}
