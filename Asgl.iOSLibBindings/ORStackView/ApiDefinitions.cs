using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Asgl.iOSLibBindings.ORStackView
{
	// @interface ORStackView : UIView
	[BaseType (typeof(UIView))]
	partial interface ORStackView // KASHIF: make partial to combine both public + private interface into one class
	{
		// -(void)addSubview:(UIView *)view withPrecedingMargin:(CGFloat)margin;
		[Export ("addSubview:withPrecedingMargin:")]
		void AddSubview (UIView view, nfloat margin);

		// -(void)addSubview:(UIView *)view withPrecedingMargin:(CGFloat)precedingMargin sideMargin:(CGFloat)sideMargin;
		[Export ("addSubview:withPrecedingMargin:sideMargin:")]
		void AddSubview (UIView view, nfloat precedingMargin, nfloat sideMargin);

		// -(void)addViewController:(UIViewController *)viewController toParent:(UIViewController *)parentViewController withPrecedingMargin:(CGFloat)margin;
		[Export ("addViewController:toParent:withPrecedingMargin:")]
		void AddViewController (UIViewController viewController, UIViewController parentViewController, nfloat margin);

		// -(void)addViewController:(UIViewController *)viewController toParent:(UIViewController *)parentViewController withPrecedingMargin:(CGFloat)margin sideMargin:(CGFloat)sideMargin;
		[Export ("addViewController:toParent:withPrecedingMargin:sideMargin:")]
		void AddViewController (UIViewController viewController, UIViewController parentViewController, nfloat margin, nfloat sideMargin);

		// -(void)insertSubview:(UIView *)view atIndex:(NSInteger)index withPrecedingMargin:(CGFloat)margin;
		[Export ("insertSubview:atIndex:withPrecedingMargin:")]
		void InsertSubview (UIView view, nint index, nfloat margin);

		// -(void)insertSubview:(UIView *)view atIndex:(NSInteger)index withPrecedingMargin:(CGFloat)precedingMargin sideMargin:(CGFloat)sideMargin;
		[Export ("insertSubview:atIndex:withPrecedingMargin:sideMargin:")]
		void InsertSubview (UIView view, nint index, nfloat precedingMargin, nfloat sideMargin);

		// -(void)insertSubview:(UIView *)view afterSubview:(UIView *)siblingSubview withPrecedingMargin:(CGFloat)margin;
		[Export ("insertSubview:afterSubview:withPrecedingMargin:")]
		void InsertSubviewAfterSubview (UIView view, UIView siblingSubview, nfloat margin);

		// -(void)insertSubview:(UIView *)view beforeSubview:(UIView *)siblingSubview withPrecedingMargin:(CGFloat)margin;
		[Export ("insertSubview:beforeSubview:withPrecedingMargin:")]
		void InsertSubviewBeforeSubview (UIView view, UIView siblingSubview, nfloat margin);        
        
		// -(void)removeSubview:(UIView *)subview;
		[Export ("removeSubview:")]
		void RemoveSubview (UIView subview);

		// -(void)removeAllSubviews;
		[Export ("removeAllSubviews")]
		void RemoveAllSubviews ();

		// -(void)performBatchUpdates:(void (^)(void))updates;
		[Export ("performBatchUpdates:")]
		void PerformBatchUpdates (Action updates);

		// -(NSLayoutConstraint *)precedingConstraintForView:(UIView *)view;
		[Export ("precedingConstraintForView:")]
		NSLayoutConstraint PrecedingConstraintForView (UIView view);

		// -(UIView *)lastView;
		[Export ("lastView")]
		//[Verify (MethodToProperty)]
		UIView LastView { get; }

		// @property (assign, nonatomic) CGFloat lastMarginHeight;
		[Export ("lastMarginHeight", ArgumentSemantic.Assign)]
		nfloat LastMarginHeight { get; set; }

		// @property (nonatomic, strong) id<UILayoutSupport> topLayoutGuide;
		[Export ("topLayoutGuide", ArgumentSemantic.Strong)]
		UILayoutSupport TopLayoutGuide { get; set; }

		// @property (assign, nonatomic) ORStackViewDirection direction;
		[Export ("direction", ArgumentSemantic.Assign)]
		ORStackViewDirection Direction { get; set; }

		// -(void)addSubview:(UIView *)view __attribute__((unavailable("addSubview is not supported on ORStackView.")));
		[Export ("addSubview:")]
		void AddSubview (UIView view);

		// -(void)insertSubview:(UIView *)view atIndex:(NSInteger)index __attribute__((unavailable("insertSubview is not supported on ORStackView.")));
		[Export ("insertSubview:atIndex:")]
		void InsertSubview (UIView view, nint index);

		// -(void)insertSubview:(UIView *)view aboveSubview:(UIView *)siblingSubview __attribute__((unavailable("insertSubview is not supported on ORStackView.")));
		[Export ("insertSubview:aboveSubview:")]
		void InsertSubviewAboveSubview (UIView view, UIView siblingSubview);

		// -(void)insertSubview:(UIView *)view belowSubview:(UIView *)siblingSubview __attribute__((unavailable("insertSubview is not supported on ORStackView.")));
		[Export ("insertSubview:belowSubview:")]
		void InsertSubviewBelowSubview (UIView view, UIView siblingSubview);
	}

	// @interface ORSplitStackView : UIView
	[BaseType (typeof(UIView))]
	interface ORSplitStackView
	{
		// -(instancetype)initWithLeftPredicate:(NSString *)left rightPredicate:(NSString *)right;
		[Export ("initWithLeftPredicate:rightPredicate:")]
		IntPtr Constructor (string left, string right);

		// @property (readonly, nonatomic, weak) ORStackView * leftStack;
		[Export ("leftStack", ArgumentSemantic.Weak)]
		ORStackView LeftStack { get; }

		// @property (readonly, nonatomic, weak) ORStackView * rightStack;
		[Export ("rightStack", ArgumentSemantic.Weak)]
		ORStackView RightStack { get; }
	}

	// @interface ORStackScrollView : UIScrollView
	[BaseType (typeof(UIScrollView))]
	interface ORStackScrollView
	{
		// @property (readonly, nonatomic, strong) ORStackView * stackView;
		[Export ("stackView", ArgumentSemantic.Strong)]
		ORStackView StackView { get; }

		// -(instancetype)initWithStackViewClass:(Class)klass;
		[Export ("initWithStackViewClass:")]
		IntPtr Constructor (Class klass);

		[Export ("stackViewClass")]
//		//[Verify (MethodToProperty)]
		Class StackViewClass();// { get; }
	}


	// @interface ORStackViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface ORStackViewController
	{
		// @property (readonly, nonatomic) ORStackScrollView * scrollView;
		[Export ("scrollView")]
		ORStackScrollView ScrollView { get; }

		// @property (readonly, nonatomic) ORStackView * stackView;
		[Export ("stackView")]
		ORStackView StackView { get; }
	}

	// @interface ORTagBasedAutoStackScrollView : ORStackScrollView
	[BaseType (typeof(ORStackScrollView))]
	interface ORTagBasedAutoStackScrollView
	{
	}

	// @interface ORTagBasedAutoStackView : ORStackView
	[BaseType (typeof(ORStackView))]
	interface ORTagBasedAutoStackView
	{
		// -(void)insertSubview:(UIView *)view atIndex:(NSInteger)index withPrecedingMargin:(CGFloat)margin __attribute__((unavailable("Inserting subviews is not supported on ORTagBasedAutoStackView.")));
		[Export ("insertSubview:atIndex:withPrecedingMargin:")]
		void InsertSubview (UIView view, nint index, nfloat margin);

		// -(void)insertSubview:(UIView *)view atIndex:(NSInteger)index withPrecedingMargin:(CGFloat)precedingMargin sideMargin:(CGFloat)sideMargin __attribute__((unavailable("Inserting subviews is not supported on ORTagBasedAutoStackView.")));
		[Export ("insertSubview:atIndex:withPrecedingMargin:sideMargin:")]
		void InsertSubview (UIView view, nint index, nfloat precedingMargin, nfloat sideMargin);

		// -(void)insertSubview:(UIView *)view afterSubview:(UIView *)siblingSubview withPrecedingMargin:(CGFloat)margin __attribute__((unavailable("Inserting subviews is not supported on ORTagBasedAutoStackView.")));
		[Export ("insertSubview:afterSubview:withPrecedingMargin:")]
		void InsertSubviewAfterSubview (UIView view, UIView siblingSubview, nfloat margin);

		// -(void)insertSubview:(UIView *)view beforeSubview:(UIView *)siblingSubview withPrecedingMargin:(CGFloat)margin __attribute__((unavailable("Inserting subviews is not supported on ORTagBasedAutoStackView.")));
		[Export ("insertSubview:beforeSubview:withPrecedingMargin:")]
		void InsertSubviewBeforeSubview (UIView view, UIView siblingSubview, nfloat margin);
	}

	// PRIVATE INTERFACE

	// @interface StackView : NSObject
	[BaseType (typeof(NSObject))]
	interface StackView
	{
		// @property (nonatomic, strong) UIView * view;
		[Export ("view", ArgumentSemantic.Strong)]
		UIView View { get; set; }

		// @property (nonatomic, strong) NSLayoutConstraint * precedingConstraint;
		[Export ("precedingConstraint", ArgumentSemantic.Strong)]
		NSLayoutConstraint PrecedingConstraint { get; set; }

		// @property (assign, nonatomic) CGFloat constant;
		[Export ("constant", ArgumentSemantic.Assign)]
		nfloat Constant { get; set; }
	}

	// @interface  (ORStackView)
	//[Category]
	//[BaseType (typeof(ORStackView))]
	partial interface ORStackView // KASHIF: make partial to combine both public + private interface into one class
	{
		// @property (nonatomic, strong) NSMutableArray * viewStack;
		[Export ("viewStack")]
		NSMutableArray ViewStack { get; set; }

		// -(void)_addSubview:(UIView *)view withPrecedingMargin:(CGFloat)precedingMargin centered:(BOOL)centered sideMargin:(CGFloat)sideMargin;
		[Export ("_addSubview:withPrecedingMargin:centered:sideMargin:")]
		void _addSubview (UIView view, nfloat precedingMargin, bool centered, nfloat sideMargin);

		// -(void)_insertSubview:(UIView *)view atIndex:(NSInteger)index withPrecedingMargin:(CGFloat)precedingMargin centered:(BOOL)centered sideMargin:(CGFloat)sideMargin;
		[Export ("_insertSubview:atIndex:withPrecedingMargin:centered:sideMargin:")]
		void _insertSubview (UIView view, nint index, nfloat precedingMargin, bool centered, nfloat sideMargin);

		//- (NSInteger)indexOfView:(UIView *)view
		[Export ("indexOfView:")]
		nint IndexOfView(UIView view);
	}
}
	