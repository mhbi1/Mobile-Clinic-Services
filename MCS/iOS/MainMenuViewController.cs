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



		}

		/*public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier.Equals("toEdit"))
			{
				return true;
			}
			return base.ShouldPerformSegue(segueIdentifier, sender);
		}*/

	
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if (segue.Identifier.Equals("toEdit"))
			{
				var editVC = segue.DestinationViewController as EditProfileViewController;
				editVC.editUser = currentUser;
			}
		}

		[Action("UnwindToMainMenu:")]
		public void UnwindToMainMenu(UIStoryboardSegue segue)
		{
			
			var signup = (EditProfileViewController)segue.SourceViewController;
			//deserialize
			signup.saveInfo();		
		}

	}
}

