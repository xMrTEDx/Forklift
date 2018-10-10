using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarriageLimitsSettings {

	[Header("Karetka")]
	public float leftRightLimit;
	public float downLimit;
	public float upLimit;
	[Header("Maszt")]
	public float forwardDegreeLimit;
	public float backwardDegreeLimit;
}
