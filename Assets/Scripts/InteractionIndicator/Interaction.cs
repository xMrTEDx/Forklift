using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

	public InteractionIndicatorControl interactionIndicatorControl;
	
	void OnTriggerEnter(Collider other)
	{
		if(!interactionIndicatorControl.onTriggerStayNotRequired)
		if(other.CompareTag("Player")) interactionIndicatorControl.OnInteractionAreaEnter();
	}
	void OnTriggerExit(Collider other)
	{
		if(!interactionIndicatorControl.onTriggerStayNotRequired)
		if(other.CompareTag("Player")) interactionIndicatorControl.OnInteractionAreaExit();
	}
	void OnTriggerStay(Collider other)
	{
		if(!interactionIndicatorControl.onTriggerStayNotRequired)
		if(other.CompareTag("Player"))
		{
			interactionIndicatorControl.CheckIfPlayerLookAt();
		}
	}
}
