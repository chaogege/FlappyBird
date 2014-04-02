using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	static bool dead = false;
	public float flapSpeed = 150f;
	public float xPos = -1.4f;
	public bool testMode = false;
	bool didFlap;
	Animator animator;

	void Start(){
		didFlap = false;
		animator = GetComponent<Animator> ();
	}
	
	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			didFlap = true;
		}
	}

	void FixedUpdate () {
		if (dead && !testMode) {
			return;
		}
		if (didFlap) {
			didFlap = false;
			dead = false;
			animator.SetTrigger("doFlap");
			if(rigidbody2D.velocity.y < flapSpeed)
				rigidbody2D.AddForce(Vector2.up * flapSpeed);
		}
		if(rigidbody2D.velocity.y > 0){
			transform.rotation = Quaternion.Euler (0,0,0);
		}else{
			float angle = Mathf.Lerp (0, -90, -rigidbody2D.velocity.y / 4f);
			transform.rotation = Quaternion.Euler (0,0,angle);
		}
		transform.position = new Vector2 (xPos, transform.position.y);
	}

	void OnCollisionEnter2D(Collision2D collision){
		dead = true;
		if (!testMode) {
			animator.SetTrigger ("die");
		}
		return;
	}

	void OnGUI(){
		if (dead && !testMode) {
			if (GUI.Button (new Rect (135, 50, 70, 20), "Retry")) {
				dead = false;
				Application.LoadLevel (0);
			}
		}
	}
	
	public static bool isDead(){
		return dead;
	}
}
