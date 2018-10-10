using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftIIsystem : MonoBehaviour {

	[System.Serializable]
	public class ForkliftState
	{
		public ForkliftStates forkliftState;
		public List<InteractionIndicatorControl> listOfII;
	}

	public ForkliftState[] defineForkliftStates;

	// public void SetForkliftState(string forkliftState)
	// {
	// 	foreach (ForkliftStates st in (ForkliftStates[]) System.Enum.GetValues(typeof(ForkliftStates)))
    //     {
    //         if(st.ToString() == forkliftState)
    //         {
    //             SetState(st);
    //         }
    //     }
	// }
		
	// public void SetState(ForkliftStates forkliftState)
	// {	
    //     foreach(var states in defineForkliftStates)
	// 	{
	// 		if(forkliftState == states.forkliftState)
	// 		{
	// 			foreach(var item in states.listOfII)
	// 			{
	// 				item.gameObject.SetActive(true);
	// 			}
	// 		}
	// 		else
	// 		{
	// 			foreach(var item in states.listOfII)
	// 			{
	// 				item.gameObject.SetActive(false);
	// 			}
	// 		}
	// 	}
	// }

	// public void DisableAllII()
	// {
	// 	SetForkliftState("none");
	// }

	public enum ForkliftStates
	{
		none,
		main,
		alternative
	}
}
