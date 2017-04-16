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
		int u;
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

			loginButton.TouchUpInside += (sender, e) =>{
				passwordTxtF.Text = "";
				if (correctLogin)
				{
					PerformSegue("toMainMenu", this);
				}
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
				checkLogin();
				return (correctLogin ? true : false);
			}
			return base.ShouldPerformSegue(segueIdentifier, sender);
		}

		[Action("UnwindToLogIn:")]
		public void UnwindToLogIn (UIStoryboardSegue segue)
		{
			//Textfields are initialized blank
			usernameTxtF.Text = "";
			passwordTxtF.Text = "";

			if (segue.Identifier.Equals("signupToLogin"))
			{
				var signup = (SignUpViewController)segue.SourceViewController;
				//deserialize
				signup.saveInfo();
				//IMPLEMENTATION: send json to database
				//TESTING: adds user to userData
				userAccount tempUser = JsonConvert.DeserializeObject<userAccount>(signup.json);
				userData.Add(tempUser);
			}

		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier.Equals("toMainMenu"))
			{
				var mmVC = segue.DestinationViewController as MainMenuViewController;
				mmVC.currentUser = userData[u];
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
					u = userData.IndexOf(user);
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
				correctLogin = false;
			}
			else if (passwordTxtF.HasText == false)
			{
				UIAlertView alert = new UIAlertView() { Title = "Password is blank", Message = "Please enter a password." };
				alert.AddButton("Ok");
				alert.Show();
				correctLogin = false;
			}
			else if (loginCorrect(usernameTxtF.Text, passwordTxtF.Text) == false)
			{
				UIAlertView alert = new UIAlertView() { Title = "Username/password is incorrect", Message = "Please try again." };
				alert.AddButton("Ok");
				alert.Show();
				correctLogin = false;
			}
			else
			{
				//username and password are correct
				correctLogin = true;
			}
		}

	}
}
