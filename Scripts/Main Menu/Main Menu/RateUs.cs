using UnityEngine;
using System.Collections;

public class RateUs : MonoBehaviour {

	public string gameaddress;
	// Use this for initialization
	void Start () {
	
	}
	
	public void LoadRateAddress(){
		Application.OpenURL (gameaddress);
	}
}
