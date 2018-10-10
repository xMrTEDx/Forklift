using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

	public InteractionIndicatorControl interactionIndicatorControl;
	
	void OnTriggerEnter(Collider other)
	{
		if(interactionIndicatorControl.alwaysVisible||other.CompareTag("Player")) interactionIndicatorControl.OnAreaEnter();
	}
	void OnTriggerExit(Collider other)
	{
		if(interactionIndicatorControl.alwaysVisible||other.CompareTag("Player")) interactionIndicatorControl.OnAreaExit();
	}
	void OnTriggerStay(Collider other)
	{
		if(interactionIndicatorControl.alwaysVisible||other.CompareTag("Player")) interactionIndicatorControl.LookAtPlayer();
	}
}
