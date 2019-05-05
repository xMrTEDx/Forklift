using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class GraphicSettings : MonoBehaviour {

	public GameObject button;
	public GameObject buttonPowrot;
	public Transform targetParent;
	// Use this for initialization
	void Start () {
		
		GameObject buttonLow = Instantiate(button,targetParent);
		buttonLow.GetComponentInChildren<Text>().text = "Low";
		buttonLow.GetComponent<Button>().onClick.AddListener(() => {
				QualitySettings.SetQualityLevel(0);
			});
		GameObject buttonMedium = Instantiate(button,targetParent);
		buttonMedium.GetComponentInChildren<Text>().text = "Medium";
		buttonMedium.GetComponent<Button>().onClick.AddListener(() => {
				QualitySettings.SetQualityLevel(1);
			});
		GameObject buttonHigh = Instantiate(button,targetParent);
		buttonHigh.GetComponentInChildren<Text>().text = "High";
		buttonHigh.GetComponent<Button>().onClick.AddListener(() => {
				QualitySettings.SetQualityLevel(2);
			});

		buttonPowrot.transform.SetAsLastSibling();
		
		// Instantiate(buttonPowrot,targetParent);
		Destroy(button);
	}
}
