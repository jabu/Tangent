using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIModels
{
    public class Project
    {
        public int pk { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool is_billable { get; set; }
        public bool is_active { get; set; }
        public TaskSerializer[] task_set { get; set; }
        public ResourceSerializer[] resource_set { get; set; }
    }

    public class Project1
    {
        public Project1()
        {
            //
        }

        // public int pk { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public Boolean is_billable { get; set; }
        public Boolean is_active { get; set; }      
    }
}
