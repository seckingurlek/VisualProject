using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduConnect
{
    public class UserSession
    {
            private static UserSession _instance;

            public int UserId { get; private set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
            public string Role { get; private set; }
            public string PhoneNumber { get; private set; }

            //Student
            public string StudentClass { get; private set; }
            public string DateOfBirth { get; private set; }
            public string Address { get; private set; }
            public string ParentName { get; private set; }
            public decimal Balance { get;  set; }

            //Parent

            public string Occupation { get; private set; }

            //Teacher
            public string Subject { get; private set; }


            private UserSession() { }

            public static UserSession Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new UserSession();
                    }
                    return _instance;
                }
            }

            public void SetUser(int userId, string email, string role, string firstName, string lastName)
            {
                UserId = userId;
                Email = email;
                Role = role;
                FirstName = firstName;
                LastName = lastName;

                PhoneNumber = string.Empty;
                DateOfBirth = string.Empty;
                Address = string.Empty;
                ParentName = string.Empty;
                Balance = 0;
                Occupation = string.Empty;
                Subject = string.Empty;

            }

            public void ClearUser()
            {
                UserId = 0;
                Email = string.Empty;
                Role = string.Empty;
                FirstName = string.Empty;
                LastName = string.Empty;
                PhoneNumber = string.Empty;
                DateOfBirth = string.Empty;
                Address = string.Empty;
                ParentName = string.Empty;
                Balance = 0;
                Occupation = string.Empty;
                Subject = string.Empty;
                StudentClass = string.Empty;
            }

            public void SetStudentInfo(string studentClass, string parentName, string address, string dateOfBirth, decimal balance)
            {
                StudentClass = studentClass;
                ParentName = parentName;
                Address = address;
                DateOfBirth = dateOfBirth;
                Balance = balance;
            }
            public void SetParentInfo(string phoneNumber, string occupation)
            {
                PhoneNumber = phoneNumber;
                Occupation = occupation;
            }
            public void SetTeacherInfo(string subject, string phoneNumber)
            {
                Subject = subject;
                PhoneNumber = phoneNumber;
            }

        }

    
}
