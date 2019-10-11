using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ControllerParameters2D {

	public enum JumpBehavior{
		CanJumpOnGround,
		CanJumpOnAnywhere,
		CantJump
	}
	
	public Vector2 MaxVelocity = new Vector2(float.MaxValue,float.MaxValue);

	[Range(0, 90)] public float SlopeLimit = 30;
	public float Gravity = -25;
	public JumpBehavior JumpRestrictions;
	public float JumpFrequency = .25f;

}
