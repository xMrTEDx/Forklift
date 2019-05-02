using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForkliftEnterTrigger : MonoBehaviour {

	public UnityEvent e_OnTriggerEnterAction;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Forklift")
		{
			e_OnTriggerEnterAction.Invoke();
			//gameObject.SetActive(false);
		}
	}
}
