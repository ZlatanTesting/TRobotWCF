using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataProvider
{
    class EncoderDataProvider:IDataProvider
    {
        private Data driversData;

        public EncoderDataProvider(Data driversData) 
        {
            this.driversData = driversData;
        }

        public bool ProvideData()
        {
            throw new NotImplementedException();
        }
    }
}
