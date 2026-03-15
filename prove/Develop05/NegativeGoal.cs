using System;

namespace classes_demo
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string goalname, string description, int points)
            : base(goalname, description, points)
        {
        }

        public override int RecordEvent()
        {
            return -_points;
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"[!] {_goalname} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"NegativeGoal|{_goalname}|{_description}|{_points}";
        }
    }
}