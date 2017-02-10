using UnityEngine;
using System.Collections;

public class ScreenScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		fitCameraWidth ();
	}

	public void fitCameraWidth() {
		SpriteRenderer sr = (SpriteRenderer)GetComponent ("Renderer");
		if (sr == null)
			return;

		// Set filterMode
		sr.sprite.texture.filterMode = FilterMode.Bilinear;

		// Get stuff
		double width = sr.sprite.bounds.size.x;
		Debug.Log ("width: " + width);
		double worldScreenHeight = Camera.main.orthographicSize * 2.0;
		double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		// Resize
		transform.localScale = new Vector2 (1, 1) * (float)(worldScreenWidth / width);
	}
}
