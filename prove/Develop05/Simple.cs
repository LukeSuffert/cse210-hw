using System;

namespace classes_demo
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string goalname, string description, int points)
            : base(goalname, description, points)
        {
            _isComplete = false;
        }

        public SimpleGoal(string goalname, string description, int points, bool isComplete)
            : base(goalname, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }

            return 0;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string box = _isComplete ? "[X]" : "[ ]";
            return $"{box} {_goalname} ({_description})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal| {_goalname} | {_description} | {_points} | {_isComplete}";
        }
    }
}