using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour {
	//Duration of the disable time
	public float sec = 1.5f;

	void OnEnable()
	{
		
		StartCoroutine(LateCall());
	}

	IEnumerator LateCall()
	{
		//Wait the specified amount of time till disabled
		yield return new WaitForSeconds(sec);
		gameObject.SetActive(false);

	}
}
