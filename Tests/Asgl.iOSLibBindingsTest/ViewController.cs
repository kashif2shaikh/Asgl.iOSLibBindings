using System;

using UIKit;
using Asgl.iOSLibBindings.PureLayout;
using Asgl.iOSLibBindings.FLKAutoLayout;
using Asgl.iOSLibBindings.ORStackView;
using Asgl.iOSLibBindings;
using System.Collections;
using System.Collections.Generic;

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
			test2();
		
		}

		void test2() {
			var scrollView = new ORTagBasedAutoStackScrollView ();
			scrollView.Frame = View.Bounds;

//			var l1 = new UILabel ();
//			l1.Text = "Shaikh";
//			l1.Tag = 3;
//
//			var l2 = new UILabel ();
//			l2.Text = "Kashif";
//			l2.Tag = 2;
//
//			var l3 = new UILabel ();
//			l3.Text = "There";
//			l3.Tag = 1;
//
//			var l4 = new UILabel ();
//			l4.Text = "Hello";
//			l4.Tag = 0;

			var tagStack = scrollView.StackView as ORTagBasedAutoStackView;
			var list = generateLabels (100);
			// This will create labels from 0 to 99, but tag in reverse order, such that
			// 99 should be at the top and 0 at the bottom due to tag based stacking.
			foreach (var label in list) {
				tagStack.AddSubview (label, 10, 40);
			}

//			tagStack.AddSubview (l1, 10, 40);
//			tagStack.AddSubview (l2, 10, 40);
//			tagStack.AddSubview (l3, 10, 40);
//			tagStack.AddSubview (l4, 10, 40);

			View.AddSubview (scrollView);
		}

		List<UILabel> generateLabels(int numLabels) {
			var list = new List<UILabel> ();


			for (int i = 0, j=numLabels-1; i < numLabels; i++,j--) {
				var label = new UILabel ();
				label.Text = "Label: " + i;
				label.Tag = j;
				list.Add (label);
			}
			return list;
		}


		void test1() {
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

