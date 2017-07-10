using System;
using System.Collections.Generic;
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
		public List<Message> messages;

		public MainMenuViewController(IntPtr handle) : base(handle){
		}

		public override void ViewDidLoad(){
			base.ViewDidLoad();
			messages = new List<Message> {
				new Message { Type = MessageType.Incoming, Text = "Hello! My Name is Nurse Joy. How may I be of assistance today?" },
				new Message { Type = MessageType.Outgoing, Text = "Hi Nurse Joy! I just woke up and found blood in my poop. Is there something wrong with me??" },
				new Message { Type = MessageType.Incoming, Text = "Hi John! I'm sorry to hear about that. There could be several reasons for why there is blood in your stool. Did you experience any pain while pooping?" },
				new Message { Type = MessageType.Outgoing, Text = "Yes! I was crying and pooping." }
			};
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
			else if (segue.Identifier.Equals("toChat"))
			{
				var vc = segue.DestinationViewController as ChatScreenViewController;

				vc.messages = messages;
			}

		}

		[Action("UnwindToMainMenu:")]
		public void UnwindToMainMenu(UIStoryboardSegue segue)
		{
			if (segue.Identifier.Equals("editToMM"))
			{
				var signup = (EditProfileViewController)segue.SourceViewController;
				//deserialize
				signup.saveInfo();
			}
			else if (segue.Identifier.Equals("chatToMM"))
			{
				var cs = (ChatScreenViewController)segue.SourceViewController;
				//deserialize
				this.messages = cs.messages;
			}
		}

	}
}

