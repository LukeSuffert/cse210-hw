using System;

namespace classes_demo
{
    public class Math : Assignment
    {
        private string _textbookSection = "";

        private string _problems = "";
    
    public Math(string studentname, string topic, string textbook, string problems) : base(studentname, topic)

        {
            _textbookSection = textbook;
            _problems = problems;
        }


    
    public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }

    }
}