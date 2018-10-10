using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Forklift/Settings/ForkliftCarriageSettings")]
public class ForkliftCarriageSettings : ScriptableObject {
	public CarriageInputSettings inputSettings;
	public CarriageLimitsSettings limitsSettings;
	
}
