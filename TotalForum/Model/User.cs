using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TotalForum.Model;

namespace TotalForum.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }
        public DateTime Dob { get; set; }
        public int PostCount => Posts.Count;

        //public User(int id, string userName, string email, string password, List<Post> posts, DateTime dob)
        //{
        //    Id = id;
        //    UserName = userName;
        //    Email = email;
        //    Password = password;
        //    Posts = posts;
        //    Dob = dob;
        //}

        public int PostCountMethod()
        {
            int postCount = Posts.Count;
            return postCount;
        }

        public static bool CheckMail(string mail)
        {
            //try
            //{
            //    var addr = new System.Net.Mail.MailAddress(mail);
            //    return addr.Address == mail;
            //}
            //catch
            //{
            //    return false;
            //}


            //return new EmailAddressAttribute().IsValid(mail);


            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var validationRegex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

            return validationRegex.IsMatch(mail);
        }

        public int DayToBirthdate()
        {
            var nextBirthday = Dob.AddYears(DateTime.Today.Year - Dob.Year);
            if (nextBirthday < DateTime.Today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }
            return (nextBirthday - DateTime.Today).Days;
        }
    }
}