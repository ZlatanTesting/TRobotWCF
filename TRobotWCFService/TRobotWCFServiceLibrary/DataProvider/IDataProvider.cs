using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRobotWCFServiceLibrary.Messages;

namespace TRobotWCFServiceLibrary.DataProvider
{
    interface IDataProvider
    {
        bool ProvideData();
    }
}
