using UnityEngine;
using System.Collections;

public class BgMovement : MonoBehaviour {

	public float scrollSpeed = 2f;
	public float leftBound = -10f;
	public float wrapDistance = 16f;

	void FixedUpdate () {
		if (BirdMovement.isDead()) {
			return;
		}
		if (transform.position.x <= leftBound) {
			transform.Translate (new Vector3 (wrapDistance, 0, 0));
		} else {
			transform.Translate (new Vector3 (scrollSpeed * Time.deltaTime * -1, 0, 0));
		}
	}
}
