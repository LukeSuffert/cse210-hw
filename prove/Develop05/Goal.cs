using System;

namespace classes_demo
{
    public class Goal
    {
        protected string _goalname = "";

        protected string _description = "";

        protected int _points;

        public Goal(string goalname, string description)
        {
            _goalname = goalname;
            _description = description;
        }

        public void RecordEvent()
        {
            
        }
    }
}