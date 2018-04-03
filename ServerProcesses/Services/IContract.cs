using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    public interface IContractProcess
    {
        [OperationContract]
        string ShowAllProcess();

        [OperationContract]
        string ShowSelectedProcess(int id);

        [OperationContract]
        string StartProcess(string fileName);

        [OperationContract]
        string CloseProcess(string nameProcess);

        [OperationContract]
        string ShowThreads(string nameProcess);

        [OperationContract]
        string ShowModules(string nameProcess);
    }
}
