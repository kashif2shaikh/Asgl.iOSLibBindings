using System;
using System.Runtime.InteropServices;
using UIKit;

namespace Asgl.iOSLibBindings.FLKAutoLayout
{
	public struct FLKAutoLayoutPredicate
	{
		NSLayoutRelation relation;

		nfloat multiplier;

		nfloat constant;

		float priority;
	}

	static class CFunctions
	{
		// extern FLKAutoLayoutPredicate FLKAutoLayoutPredicateMake (NSLayoutRelation relation, CGFloat multiplier, CGFloat constant, UILayoutPriority priority);
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern FLKAutoLayoutPredicate FLKAutoLayoutPredicateMake (NSLayoutRelation relation, nfloat multiplier, nfloat constant, float priority);
	}
}
