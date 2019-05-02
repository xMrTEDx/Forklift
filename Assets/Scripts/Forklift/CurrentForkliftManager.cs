using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentForkliftManager : MonoBehaviour {

	public void OdblokujMozliwoscJazdy()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscJazdy = true;
	}
	public void ZablokujMozliwoscJazdy()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscJazdy = false;
	}
	public void OdblokujMozliwoscKierowania()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscKierowania = true;
	}
	public void ZablokujMozliwoscKierowania()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscKierowania = false;
	}
	public void OdblokujMozliwoscPoruszaniaDzwigniami()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscPoruszaniaDziwgniami = true;
	}
	public void ZablokujMozliwoscPoruszaniaDzwigniami()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscPoruszaniaDziwgniami = false;
	}
	public void OdblokujMozliwoscUruchomieniaSilnika()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscUruchomieniaSilnika = true;
	}
	public void ZablokujMozliwoscUruchomieniaSilnika()
	{
		GameManager.Instance.QuestsSystem.currentQuest.quest.forkliftController.forkliftSteering.mozliwoscUruchomieniaSilnika = false;
	}
}
