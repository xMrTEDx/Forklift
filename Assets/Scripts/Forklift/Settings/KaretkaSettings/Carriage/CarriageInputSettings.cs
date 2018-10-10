using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarriageInputSettings {
	[Header("Maszt")]
	[SerializeField]
	private string goDownAxis;
	[SerializeField]
	private string leftRightAxis;
	[SerializeField]
	private string rotationAxis;
	[Header("Steering")]
	[SerializeField]
	private KeyCode lights;

	[Space]
	[Header("Speeds")]
	[SerializeField]
	private float goDownSpeed = 1;
	[SerializeField]
	private float leftRightSpeed = 1;
	[SerializeField]
	private float rotationSpeed = 1;

	public float UpDownValue
	{
		get
		{
			return Input.GetAxis(goDownAxis) * goDownSpeed * Time.deltaTime;
		}
	}
	public float LeftRightValue
	{
		get
		{
			return Input.GetAxis(leftRightAxis) * leftRightSpeed * Time.deltaTime;
		}
	}
	public float rotationValue
	{
		get
		{
			return Input.GetAxis(rotationAxis) * rotationSpeed * Time.deltaTime;
		}
	}
}
