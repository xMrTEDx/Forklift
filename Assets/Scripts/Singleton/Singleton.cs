using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour {

	private static T _instance = null;
 
	public static T Instance
	{
		 get
         { 
			if (_instance == null) 
			{
				Debug.Log("Singletons/"+typeof(T).Name);
				GameObject tmp = (GameObject) Resources.Load("Singletons/"+typeof(T).Name);
				Instantiate(tmp);
				_instance = tmp.GetComponent<T>();
			}
			return _instance;
         }
	}
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_instance=gameObject.GetComponent<T>();
	}
}
