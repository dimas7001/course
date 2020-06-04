using System.Collections.Generic;
using System.Linq;

namespace MemberNamespace
{
    class Member
    {
        private List<TaskNamespace.Task> Tasks = new List<TaskNamespace.Task>();
        private string name;
        
        public Member (string _name)
        {
            name = _name;
        }
        public void AddTask(string _task_name, string _descr, string _status, double _time, bool _priority)
        {
            Tasks.Add(new TaskNamespace.Task(_task_name, _descr, _status, _time, _priority));
        }
        public void RemoveTask(int number)
        {
            Tasks.RemoveAt(number);
        }
        public int GetTaskCount()
        {
            return Tasks.Count();
        }
        public string GetTaskText(int j)
        {
            return Tasks[j].GetText();
        }
        public bool GetTaskPriority(int j)
        {
            return Tasks[j].GetPriority();
        }
        public void ChangeTaskStatus(int j, string _status)
        {
            Tasks[j].ChangeStatus(_status);
        }
        public void ChangeTaskStatus(int j)
        {
            Tasks[j].ChangeStatus();
        }
    }
}
