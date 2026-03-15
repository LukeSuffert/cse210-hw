using System;

namespace classes_demo
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonus;

        public ChecklistGoal(string goalname, string description, int points, int targetCount, int bonus)
            : base(goalname, description, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _currentCount = 0;
        }

        // Constructor used when loading
        public ChecklistGoal(string goalname, string description, int points, int targetCount, int bonus, int currentCount)
            : base(goalname, description, points)
        {
            _targetCount = targetCount;
            _bonus = bonus;
            _currentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (_currentCount < _targetCount)
            {
                _currentCount++;

                if (_currentCount == _targetCount)
                {
                    return _points + _bonus;
                }

                return _points;
            }

            return 0;
        }

        public override bool IsComplete()
        {
            return _currentCount >= _targetCount;
        }

        public override string GetDetailsString()
        {
            string box = IsComplete() ? "[X]" : "[ ]";
            return $"{box} {_goalname} ({_description}) -- Completed {_currentCount}/{_targetCount}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_goalname}|{_description}|{_points}|{_bonus}|{_currentCount}|{_targetCount}";
        }
    }
}