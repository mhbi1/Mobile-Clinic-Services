using System;
using Foundation;
using UIKit;
using Newtonsoft.Json;

namespace MobileClinicServices.iOS
{
	public class userAccount
	{
		public String firstName { get; set;}
		public String middleName { get; set; }
		public String lastName { get; set; }
		public String email { get; set; }
		public String pass { get; set; }
		public String cpass { get; set; }
		public String num { get; set; }
		public String ssn { get; set; }
		public String dob { get; set; }

	}
	public partial class SignUpViewController : UIViewController
	{
		public String json = "";
		public userAccount editUser;
		public bool edit;

		public SignUpViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			backButton.TouchUpInside += (sender, e) =>
			{
				NavigationController.PopViewController(animated: true);
			};

			doneButton.TouchUpInside += (sender, e) =>
			{
				/*if (passwordTxtF.Text.Equals(confirmPassTxtF.Text))
				{
					NavigationController.PopToRootViewController(animated: true);
				}*/

			};
		}

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			//Checks to see if formats are correct
			//String ssn = String.Format("{0:###-##-####}", int.Parse(ssnTxtF.Text));
			//Console.WriteLine(ssn);

			//Checks to see if phone number has valid format
			if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumTxtF.Text, "[0-9]{3}-[0-9]{3}-[0-9]{4}"))
			{
				UIAlertView alert = new UIAlertView() { Title = "Phone number is not in right format", Message = "Please enter a valid format." };
				alert.AddButton("Ok");
				alert.Show();
				return false;
			}
			//Checks to see if ssn has valid format
			else if (!System.Text.RegularExpressions.Regex.IsMatch(ssnTxtF.Text, "[0-9]{3}-[0-9]{2}-[0-9]{4}"))
			{
				UIAlertView alert = new UIAlertView() { Title = "SSN is not in right format", Message = "Please enter a valid format." };
				alert.AddButton("Ok");
				alert.Show();
				return false;
			}
			/*else if (!System.Text.RegularExpressions.Regex.IsMatch(emailTxtF.Text, "[a-z]{50}@[0-9]{2}-[0-9]{4}"))
			{
				UIAlertView alert = new UIAlertView() { Title = "SSN is not in right format", Message = "Please enter a valid format." };
				alert.AddButton("Ok");
				alert.Show();
				return false;
			}*/
			//Checks to see if passwords match
			else if (passwordTxtF.Text.Equals(confirmPassTxtF.Text))
			{
				return true;
			}
			else
			{
				UIAlertView alert = new UIAlertView() { Title = "Passwords do not match", Message = "Please try again." };
				alert.AddButton("Ok");
				alert.Show();
				return false;
			}
			//return base.ShouldPerformSegue(segueIdentifier, sender);
		}

		public void saveInfo()
		{
			//doneButton creates a new account
			var newUser = new userAccount
			{
				firstName = firstTxtF.Text,
				middleName = midTxtF.Text,
				lastName = lastTxtF.Text,
				email = emailTxtF.Text,
				pass = passwordTxtF.Text,
				cpass = confirmPassTxtF.Text,
				num = phoneNumTxtF.Text,
				ssn = ssnTxtF.Text,
				dob = dobTxtF.Text
			};
			json = JsonConvert.SerializeObject(newUser);
		}
	}
}

