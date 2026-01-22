using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main()
    {
        Job Job1 = new Job();
        Job1._company = "Google";
        Job1._jobTitle = "Software Engineer";
        Job1._startYear = 2027;
        Job1._endYear = 2030;

        Job Job2 = new Job();
        Job2._company = "Tesla";
        Job2._jobTitle = "CEO";
        Job2._startYear = 2030;
        Job2._endYear = 2050;

        Job1.DisplayJobDetails();
        Job2.DisplayJobDetails();

        Resume myresume = new Resume();
        myresume._name = "Luke Suffert";

        myresume._jobs.Add(Job1);
        myresume._jobs.Add(Job2);

        myresume.DisplayResume();

    }
}