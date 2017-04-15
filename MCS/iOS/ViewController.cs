using System;
using Foundation;
using UIKit;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MobileClinicServices.iOS
{
	public partial class ViewController : UIViewController
	{
		public static List<userAccount> userData = new List<userAccount>();
		int currentUser;
		String username = "";
		String password = "";
		bool correctLogin = false;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Textfields are initialized blank
			usernameTxtF.Text = "";
			passwordTxtF.Text = "";

			//Hides the keyboard after pressing outside of the keyboard
			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			g.CancelsTouchesInView = false; //for iOS5
			View.AddGestureRecognizer(g);

			//Pressing return selects password textfield -> hides keyboard
			this.usernameTxtF.ShouldReturn += delegate {
				passwordTxtF.BecomeFirstResponder();
				return true;
			};
			this.passwordTxtF.ShouldReturn += delegate
			{
				passwordTxtF.ResignFirstResponder();
				return true;
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier.Equals("toMainMenu"))
			{
				//Do I need this?
				if (correctLogin)
				{
					username = this.usernameTxtF.Text;
					password = this.passwordTxtF.Text;
					if (loginCorrect(username, password))
					{

					}
				}
				else    //Checks to see if fields are blank or incorrect
				{
					checkLogin();
					return (correctLogin ? true : false);
				}
			}
			return base.ShouldPerformSegue(segueIdentifier, sender);
		}

		[Action("UnwindToLogIn:")]
		public void UnwindToLogIn (UIStoryboardSegue segue)
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
			passwordTxtF.Text = "";
		}

		public void prepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier.Equals("toMainMenu"))
			{
				var mmVC = segue.DestinationViewController as MainMenuViewController;
				mmVC.currentUser = userData[currentUser];
			}
		}

		public bool loginCorrect(String username, String pass) 
		{
			//IMPLEMENTATION: Sends username and pass to database, decipher code to check if correct
			//TESTING: loops through list of userData and gets index of currentLogged in user
			foreach (var user in userData)
			{
				if (user.email.Equals(username) && user.pass.Equals(pass))
				{
					currentUser = userData.IndexOf(user);
					return true;
				}
				else { return false;}
			}
			return false;
		}

		public void checkLogin()
		{
			if (usernameTxtF.HasText == false)
			{
				UIAlertView alert = new UIAlertView() { Title = "Username is blank", Message = "Please enter a username." };
				alert.AddButton("Ok");
				alert.Show();
			}
			else if (passwordTxtF.HasText == false)
			{
				UIAlertView alert = new UIAlertView() { Title = "Password is blank", Message = "Please enter a password." };
				alert.AddButton("Ok");
				alert.Show();
			}
			else if (loginCorrect(usernameTxtF.Text, passwordTxtF.Text) == false)
			{
				UIAlertView alert = new UIAlertView() { Title = "Username/password is incorrect", Message = "Please try again." };
				alert.AddButton("Ok");
				alert.Show();
			}
			else
			{
				//username and password are correct
				correctLogin = true;
			}
		}

	}
}
