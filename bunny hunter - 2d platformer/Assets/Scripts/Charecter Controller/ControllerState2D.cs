using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControllerState2D{

	public bool isCollidingRight{ get; set; }
	public bool isCollidingLeft{ get; set; }
	public bool isCollidingAvove{ get; set; }
	public bool isCollidingBellow{ get; set; }
	public bool isMovingDownSlope{ get; set; }
	public bool isMovingUpSlope{ get; set; }
	public bool isGrounded{ get; set; }
	public float SlopeAngle{ get; set; }
	
	public bool MasCollisions{get{ return isCollidingRight || isCollidingLeft || isCollidingAvove || isCollidingBellow; }}

	public void Reset(){
		isMovingUpSlope = isMovingDownSlope
			= isCollidingAvove = isCollidingBellow = isCollidingLeft = isCollidingRight = false;

		SlopeAngle = 0;

	}

	public override string ToString(){
		return string.Format("(controller: r:{0} l:{1} a:{2} b:{3} down-slop:{4} up-slope: {5} angle: {6})",
			isCollidingRight,
			isCollidingLeft,
			isCollidingAvove,
			isCollidingBellow,
			isMovingDownSlope,
			isMovingUpSlope,
			SlopeAngle);
	}
	
}
