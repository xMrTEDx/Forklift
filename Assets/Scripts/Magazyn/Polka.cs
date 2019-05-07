using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polka : MonoBehaviour
{
	public MiejsceNaPalete[] miejscaNaPalety;
    // public Transform MiejsceNaPalete1;
    // public Transform MiejsceNaPalete2;
    // public Transform MiejsceNaPalete3;
    // public Transform MiejsceNaPalete4;
    // public Transform MiejsceNaPalete5;
    // public Transform MiejsceNaPalete6;
    
	[System.Serializable]
	public class MiejsceNaPalete
	{
		public Transform Miejsce;
		public bool CzyWolne = true;
	}
}
