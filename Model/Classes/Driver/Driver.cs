using System;
using System.Text.RegularExpressions;

namespace TransDep_AdminApp
{
    public class Driver
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public int Rating { get; private set; }
        
        
        public Driver(string fullName, int rating, int id = 0)
        {
            if (rating < 0 || rating > 10) throw new ArgumentOutOfRangeException(nameof(rating),@"Id cannot be negative.");
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), @"ID cannot be negative.");
            
            var pattern = @",\s?";
            try
            {
                var name = Regex.Split(fullName, pattern);
                FirstName = name[0];
                MiddleName = name[1];
                LastName = name[2];
            }
            catch (Exception)
            {
                throw new FormatException(
                    @"Input name has wrong punctuation. 
                    Make sure to enter name dividing first, middle and last name with comas. 
                    One space after comma is allowed, but is not necessary.");
            }

            Rating = rating;
            Id = id;
        }

        public override string ToString() => $"{Id}: {FirstName}, {MiddleName}, {LastName}, {Rating}/10";
    }
}