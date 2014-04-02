using UnityEngine;
using System.Collections;

public class PipeMovement : MonoBehaviour {
	
	public float scrollSpeed = 1f;
	public float leftBound = -4f;
	public float wrapDistance = 7.5f;

	const float yMax = 1.7f;
	const float yMin = 0.7f;
	const float zPos = 10f;

	void Start(){
		transform.position = new Vector3 (transform.position.x, Random.Range(yMin, yMax), zPos);
	}

	void FixedUpdate () {
		if (BirdMovement.isDead()) {
			return;
		}
		if (transform.position.x <= leftBound) {
			transform.position = new Vector3 (transform.position.x + wrapDistance, Random.Range(yMin, yMax), zPos);
		} else {
			transform.Translate (new Vector3 (scrollSpeed * Time.deltaTime * -1, 0, 0));
		}
	}
}
