using System;
using ObjCRuntime;

[assembly: LinkWith ("ORStackView.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
[assembly: LinkWith("FLKAutoLayout.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = false, ForceLoad = true)]