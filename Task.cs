namespace TaskNamespace
{
    class Task
    {
        private string name;
        private string descr;
        private string status;
        private double time;
        private bool priority;

        public Task(string _name, string _descr, string _status, double _time, bool _priority)
        {
            name = _name;
            descr = _descr;
            status = _status;
            time = _time;
            priority = _priority;
        }
        public void ChangeStatus(string _status)
        {
            status = _status;
        }
        public void ChangeStatus()
        {
            status = "done";
        }
        public string GetText()
        {
            return name + "\n\n " + descr + "\n status: " + status + "\n time: " + time + "h";
        }
        public bool GetPriority()
        {
            return priority;
        }
    }
}