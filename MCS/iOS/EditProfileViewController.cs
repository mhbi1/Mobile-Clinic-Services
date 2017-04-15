using Foundation;
using System;
using UIKit;

namespace MobileClinicServices.iOS
{
	public partial class EditProfileViewController : UIViewController
	{
		public String json = "";
		public userAccount editUser;

		public EditProfileViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//TESTING: fills textfields with account info, no confirm pass
			firstTxtF.Text = editUser.firstName;
			midTxtF.Text = editUser.middleName;
			lastTxtF.Text = editUser.lastName;
			emailTxtF.Text = editUser.email;
			passwordTxtF.Text = editUser.pass;
			phoneNumTxtF.Text = editUser.num;
			ssnTxtF.Text = editUser.ssn;
			dobTxtF.Text = editUser.dob;

			backButton.TouchUpInside += (sender, e) =>
			{
				NavigationController.PopViewController(animated: true);
			};

			doneButton.TouchUpInside += (sender, e) =>
			{
				if (passwordTxtF.Text.Equals(confirmPassTxtF.Text))
				{
					NavigationController.PopToRootViewController(animated: true);
				}
			};
		}

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			//Checks to see if passwords match
			if (passwordTxtF.Text.Equals(confirmPassTxtF.Text))
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
			//return base.ShouldPerformSegue(segueIdentifier, sender);	}
		}

		public void saveInfo()
		{
			//doneButton saves the accountInfo
			editUser.firstName = firstTxtF.Text;
			editUser.middleName = midTxtF.Text;
			editUser.lastName = lastTxtF.Text;
			editUser.email = emailTxtF.Text;
			editUser.pass = passwordTxtF.Text;
			editUser.num = phoneNumTxtF.Text;
			editUser.ssn = ssnTxtF.Text;
			editUser.dob = dobTxtF.Text;
		}

		/*[Action("UnwindToMainMenu:")]
		public void UnwindToMainMenu(UIStoryboardSegue segue)
		{
			var signup = (SignUpViewController)segue.SourceViewController;
			//deserialize
			signup.saveInfo();
			//IMPLEMENTATION: send json to database
			//TESTING: adds user to userData
			userAccount tempUser = JsonConvert.DeserializeObject<userAccount>(signup.json);
			userData.Add(tempUser);

			//Textfields are initialized blank
			usernameTxtF.Text = "";
			passwordTxtF.Text = "";"
		}*/
	}
}