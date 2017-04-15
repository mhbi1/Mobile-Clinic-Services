// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MobileClinicServices.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton forgetPassButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton loginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView logo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordTxtF { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton signupButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField usernameTxtF { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (forgetPassButton != null) {
                forgetPassButton.Dispose ();
                forgetPassButton = null;
            }

            if (loginButton != null) {
                loginButton.Dispose ();
                loginButton = null;
            }

            if (logo != null) {
                logo.Dispose ();
                logo = null;
            }

            if (passwordTxtF != null) {
                passwordTxtF.Dispose ();
                passwordTxtF = null;
            }

            if (signupButton != null) {
                signupButton.Dispose ();
                signupButton = null;
            }

            if (usernameTxtF != null) {
                usernameTxtF.Dispose ();
                usernameTxtF = null;
            }
        }
    }
}