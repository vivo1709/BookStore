using System;
using System.Windows;

namespace BookStoreLIB
{
    public class UserData
    {
        public int UserID { set; get; }
        public string LoginName { set; get; }
        public string Password { set; get; }

        public Boolean Login(string loginName, string password)
        {
            bool isValid = checkPasswordRequirements(password);

            if (loginName == "" || password == "")
            {

                MessageBox.Show("Please fill all slots");
                return false;

            }
            else if (!isValid)
            {

                MessageBox.Show("A Valid Password needs to have at least 6 characters with both numbers and letters ");
                return false;

            }
            else
            {
                var dbUser = new DALUserInfo();
                UserID = dbUser.Login(loginName, password);
                if (UserID > 0)
                {
                    LoginName = loginName;
                    Password = password;
                    MessageBox.Show("You are logged in as User #" + UserID);
                    return true;
                }
                else return false;
            }
        }
        private bool checkPasswordRequirements(string password)
        {
            if (password.Length < 6) return false;
            if (!char.IsLetter(password[0])) return false;

            bool containsNumber = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsNumber(password[i])) containsNumber = true;
                if (!char.IsNumber(password[i]) && !char.IsLetter(password[i])) return false;
            }
            if (containsNumber == false) return false;


            return true;
        }
    }

}

/**
    *    private void okButton_Click(object sender, RoutedEventArgs e)
       {
           string username = this.nameTextBox.Text;
           string password = this.passwordTextBox.Text;

           bool isValid = checkPasswordRequirements(password);

           if (username == "" || password == "")
           {

               MessageBox.Show("Please fill all slots");

           }
           else if (!isValid)
           {

               MessageBox.Show("A Valid Password needs to have at least 6 characters with both numbers and letters ");

           }
           else
           {
               var userData = new UserData();
               if (userData.Login(username, password) == true)
               {
                   MessageBox.Show("You are logged in as User #" + userData.UserID);
               }
           }
       }

       private bool checkPasswordRequirements(string password)
       {
           if (password.Length < 6) return false;
           if (!char.IsLetter(password[0])) return false;

           bool containsNumber = false;
           for (int i = 0; i < password.Length; i++)
           {
               if (char.IsNumber(password[i])) containsNumber = true;
               if (!char.IsNumber(password[i]) && !char.IsLetter(password[i])) return false;
           }
           if (containsNumber == false) return false;


           return true;
       }

       private void cancelButton_Click(object sender, RoutedEventArgs e)
       {
           this.Close();
       }
   }
}

    * 
    * **/