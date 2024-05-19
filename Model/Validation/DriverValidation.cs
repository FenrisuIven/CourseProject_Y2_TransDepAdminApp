using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TransDep_AdminApp.Model.View
{
    public class DriverValidation : IDataErrorInfo
    {
        public DriverDTO? DriverDto { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Rating { get; set; }
        public string Category { get; set; }
        
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "DriverDto":
                        if (DriverDto == null) return "Cannot be empty";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName)) return "Прізвище обов'язкове";
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) return "Ім'я обов'язкове";
                        break;
                    case "MiddleName":
                        if (string.IsNullOrEmpty(MiddleName)) return "По-Батькові обов'язкове";
                        break;
                    case "Id":
                        if (string.IsNullOrEmpty(Id)) return "Номер водія обов'язковий";
                        if (new Regex("[^0-9.-]+").IsMatch(Id)) return "Номер водія повинен містити лише цифри";
                        break;
                    case "Rating":
                        if (string.IsNullOrEmpty(Rating)) return "Рейтинг обов'язковий";
                        if (!new Regex("[^0-9.-]+").IsMatch(Rating)) return "Рейтинг водія повинен містити лише цифри";
                        break;
                    case "Category":
                        if (string.IsNullOrEmpty(Category)) return "Категорія обов'язкова";
                        if (new Regex(@"^(C(?!E)|CE|B(?!E)|BE)$").IsMatch(Category)) return "Рейтинг водія повинен бути однією з наяних категорій";
                        break;
                }

                return default;
            }
        }

        public string Error => null;
    }
}