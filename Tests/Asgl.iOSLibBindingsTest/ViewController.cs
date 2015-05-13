using System;

using UIKit;
using Asgl.iOSLibBindings.PureLayout;
using Asgl.iOSLibBindings.FLKAutoLayout;
using Asgl.iOSLibBindings.ORStackView;
using Asgl.iOSLibBindings;

namespace iOSLibBindingsTest
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			var v1 = new UIView ();
			v1.BackgroundColor = UIColor.Red;
			this.View.AddSubview (v1);
			v1.AlignTopAndLeading ("20", "20", v1.Superview);
			v1.ConstrainWidthAndHeight("40", "40");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

