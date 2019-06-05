using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Windows.Forms;


using ComInterfaces;

namespace ArDAQ
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public partial class Form1 : Form, IComService
    {
        private Dictionary<string, double> data;
        /*public ComService()
        {
            data = new Dictionary<string, double>();
        }*/
        public void Connect()
        {
            Callback = OperationContext.Current.GetCallbackChannel<ICallbackService>();
        }

        /*public void clearData()
        {
            data.Clear();
        }
        public void updateData(string key, double value)
        {
            data[key] = value;
        }*/
        public static ICallbackService Callback { get; set; }


        public void SendMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void SendMessage(ref Dictionary<string, double> myDict)
        {
           /* myDict.Clear();
            foreach (string key in data.Keys)
            {
                myDict[key] = data[key];
            }*/
        }


    }
}