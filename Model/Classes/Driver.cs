using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TransDep_AdminApp.Interfaces;

namespace TransDep_AdminApp.Model
{
    public class Driver : IDriver
    {
        public string Id { get; private set; }
        public string AssignedTruckId { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public int Rating { get; private set; }
        public string Category { get; private set; }
        public Driver() {}
        public Driver(string id, string fullName, int rating, string category)
        {
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

            Id = id;
            Rating = rating;
            Category = category;
        }
        public void SetTruckID(string value) => AssignedTruckId = value;
        
        public string GetString => $"{Id}: {FirstName} {MiddleName} {LastName}";
        public override string ToString() => $"{Id}: {FirstName} {MiddleName} {LastName}, {Rating}/10";
    }
}