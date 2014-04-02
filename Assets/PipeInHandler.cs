using UnityEngine;
using System.Collections;

public class PipeInHandler : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		PipeOutHandler.activate();
	}
}
