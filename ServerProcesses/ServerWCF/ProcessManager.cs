using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWCF
{
    public class ProcessManager : IContractProcess
    {
        private Process[] processes;

        public ProcessManager()
        {
            processes = processes = Process.GetProcesses(".");
        }

        public string ShowAllProcess()
        {
            var strBuilder = new StringBuilder();
            foreach (var item in processes)
            {
                strBuilder.Append($"ID: {item.Id} Name: {item.ProcessName}" + Environment.NewLine);
            }
            return strBuilder.ToString();
        }
        public string ShowSelectedProcess(int id)
        {
            return processes.FirstOrDefault(pro => pro.Id == id).ProcessName;
        }
        public string StartProcess(string fileName)
        {
            if(Process.Start(fileName) != null)
                return "Процесс запущен!";
            else
                return "Процесс не запущен!";
        }
        public string CloseProcess(string nameProcess)
        {
            var processes = Process.GetProcessesByName(nameProcess);
            if (processes.Length > 0)
            {
                processes[0].CloseMainWindow();
                return "Процесс завершен";
            }
            else
                return "Процесс не найден!";
        }
        public string ShowModules(string nameProcess)
        {
            var processes = Process.GetProcessesByName(nameProcess);
            if (processes.Length > 0)
            {
                var strBuilder = new StringBuilder();
                foreach (ProcessModule item in processes[0].Modules)
                {
                    strBuilder.Append($"Name: {item.ModuleName}" + Environment.NewLine);
                }
                return strBuilder.ToString();
            }
            else
                return "Процесс не найден!";
        }
        public string ShowThreads(string nameProcess)
        {
            var processes = Process.GetProcessesByName(nameProcess);
            if (processes.Length > 0)
            {
                var strBuilder = new StringBuilder();
                foreach (ProcessThread item in processes[0].Threads)
                {
                    strBuilder.Append($"ID: {item.Id} State: {item.ThreadState}" + Environment.NewLine);
                }
                return strBuilder.ToString();
            }
            else
                return "Процесс не найден!";
        }
    }
}
