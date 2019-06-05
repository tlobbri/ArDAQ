using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace ComInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Required,
    CallbackContract = typeof(ICallbackService))]
    public interface IComService
    {
        [OperationContract(IsOneWay = true)]
        void Connect();

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);

        [OperationContract(IsOneWay = true)]
        void SendMessage(ref Dictionary<string, double> myDict);
    }
}
