using System;
using ObjCRuntime;

[assembly: LinkWith ("PureLayout.a", LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
