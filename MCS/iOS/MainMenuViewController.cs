using System;
using Foundation;
using UIKit;
using Newtonsoft.Json;

namespace MobileClinicServices.iOS
{
	public partial class MainMenuViewController : UIViewController
	{
		//IMPLEMENTATION: Stores the account information being accessed
		//TESTING: Keeps track of account being used
		public userAccount currentUser;

		public MainMenuViewController(IntPtr handle) : base(handle){
		}

		public override void ViewDidLoad(){
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			logoutButton.TouchUpInside += (sender, e) =>{
				NavigationController.PopToRootViewController(animated: true);
			};
			profileButton.TouchUpInside += (sender, e) =>{
				PerformSegue("toEdit", this);
			};

		}

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier.Equals("toProfile"))
			{
				return true;
			}
			return base.ShouldPerformSegue(segueIdentifier, sender);
		}

	
		public void prepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier.Equals("toEdit"))
			{
				var editVC = segue.DestinationViewController as SignUpViewController;
				editVC.editUser = currentUser;
				editVC.edit = true;
			}
		}

		[Action("UnwindToMainMenu:")]
		public void UnwindToMainMenu(UIStoryboardSegue segue)
		{
			var signup = (SignUpViewController)segue.SourceViewController;
			//deserialize
			signup.saveInfo();		
		}

	}
}

