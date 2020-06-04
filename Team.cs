using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using MemberNamespace;

namespace TeamNamespace
{
    class Team
    {
        private List<int> member_left = new List<int>();
        private List<JObject> member_data = new List<JObject>();
        private List<Member> member = new List<Member>();

        public Team(int left1, int left2, int left3)
        {
            member_left.Add(left1);
            member_left.Add(left2);
            member_left.Add(left3);
            member_data.Add(JObject.Parse((string)File.ReadAllText("../../data/members/member1.json")));
            member_data.Add(JObject.Parse((string)File.ReadAllText("../../data/members/member2.json")));
            member_data.Add(JObject.Parse((string)File.ReadAllText("../../data/members/member3.json")));
        }
        public void FillInMemberData ()
        {
            for (int i = 0; i < member_data.Count(); i++)
            {
                member.Add(new Member((string)member_data[i]["name"]));
                for (int j = 0; j < member_data[i]["tasks"].Count(); j++)
                    member[i].AddTask((string)member_data[i]["tasks"][j]["taskname"], 
                                      (string)member_data[i]["tasks"][j]["descr"],
                                      (string)member_data[i]["tasks"][j]["status"],
                                      (double)member_data[i]["tasks"][j]["time"],
                                      (bool)member_data[i]["tasks"][j]["priority"]);
            } 
        }
        public int GetMemberTaskCount(int i)
        {
            return member[i].GetTaskCount();
        }
        public int GetMemberCount()
        {
            return member.Count();
        }
        public string GetMemberTaskText(int i, int j)
        {
            return member[i].GetTaskText(j);
        }
        public bool GetMemberTaskPriority(int i, int j)
        {
            return member[i].GetTaskPriority(j);
        }
        public void ChangeMemberTaskStatus(int i, int j, string _status)
        {
            member[i].ChangeTaskStatus(j, _status);
        }
    }
}
