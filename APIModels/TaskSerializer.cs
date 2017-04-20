using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModels
{    
    public class ResourceSerializer
    {
        public int id { get; set; }
        public string User { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public float Rate { get; set; }
        public decimal Agreed_hours_per_month { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }        
    }

    public class TaskProjectSerializer
    {
        public int PrimaryKey { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public bool Is_Billable { get; set; }
        public bool Is_active { get; set; }
    }

    public class TaskSerializer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Due_date { get; set; }
        public decimal Estimated_Hours { get; set; }
        public TaskProjectSerializer Project_data { get; set; }
    }
}