using System;

namespace classes_demo
{
    public class Goal
    {
        protected string _goalname = "";

        protected string _description = "";

        protected int _points;

        public Goal(string goalname, string description, int points)
        {
            _goalname = goalname;
            _description = description;
            _points = points;
        }

        public virtual int RecordEvent()
        {
            return _points;
        }

        public virtual bool IsComplete()
        {
            return false;
        }

        public virtual string GetDetailsString()
        {
            return $"{_goalname} ({_description})";
        }

        public virtual string GetStringRepresentation()
        {
            return $"{_goalname} | {_description} | {_points}";
        }
    }
}