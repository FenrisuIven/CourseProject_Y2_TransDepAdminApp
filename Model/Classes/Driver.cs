using System.Text.RegularExpressions;

namespace TransDep_AdminApp
{
    public class Driver
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public Driver(string fullName)
        {
            var pattern = @",\s";
            Regex rx = new Regex(pattern);
            var name = Regex.Split(fullName, pattern);
            Name = name[0];
            MiddleName = name[1];
            LastName = name[2];
        }

        public override string ToString() => $"{Name}, {MiddleName}, {LastName}";
    }
}