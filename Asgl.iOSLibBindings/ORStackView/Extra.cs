using System;
using UIKit;
using ObjCRuntime;

namespace Asgl.iOSLibBindings.ORStackView
{
	public partial class ORStackView : UIView
	{
		void InsertSubviewAfterSubview (UIView view, UIView siblingSubview, nfloat precedingMargin, nfloat sideMargin)
		{			
			var index = Array.IndexOf (this.Subviews, siblingSubview);
			if (index < 0)
				index = (int)this.ViewStack.Count;
			
			this._insertSubview(view, index, precedingMargin, true, sideMargin); 


//			BOOL hasSibling = [self.subviews containsObject:siblingSubview];
//			NSInteger index = hasSibling ? [self indexOfView:siblingSubview] : self.viewStack.count;
//			[self _insertSubview:view atIndex:index withPrecedingMargin:margin centered:NO sideMargin:0];

		}

		void InsertSubviewBeforeSubview (UIView view, UIView siblingSubview, nfloat precedingMargin, nfloat sideMargin)
		{
			var index = (int)this.IndexOfView (view);
			this._insertSubview(view, index, precedingMargin, true, sideMargin); 


			//NSAssert([self.subviews containsObject:siblingSubview], @"SiblingSubview not found in ORStackView");
			//NSInteger index = [self indexOfView:siblingSubview] - 1;
			//[self _insertSubview:view atIndex:index withPrecedingMargin:margin centered:NO sideMargin:0];

		}
	}

	[Foundation.Register("ORTagBasedAutoStackScrollView")]
	public class ORTagBasedAutoStackScrollView : ORStackScrollView {
		public ORTagBasedAutoStackScrollView() : base(new Class("ORTagBasedAutoStackView")) /* this base ctor should call: initWithStackViewClass */ {

		}
	}
}

