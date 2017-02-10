using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class MoreGames : MonoBehaviour {

	public string address="";
	// Use this for initialization
	void Start () {
	
	}

	public void LoadStore(){
		Application.OpenURL (address);
	}

}
