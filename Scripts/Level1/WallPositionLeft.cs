using UnityEngine;
using System.Collections;

public class WallPositionLeft : MonoBehaviour {

	public GameObject objectTarget;
	public Vector3 screenPosition = new Vector3(0,0,0);
	public Vector3 newposition;
	public Camera camera;
	// Use this for initialization
	void Start () {
		screenPosition = camera.transform.position;


		if(objectTarget != null)
		{ Vector3 newposition=camera.ViewportToWorldPoint(new Vector3(-0.1f, 1, camera.nearClipPlane));

			objectTarget.transform.position=newposition;
		}

	}
}