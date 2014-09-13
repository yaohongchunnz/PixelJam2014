using UnityEngine;
using System.Collections;

public class Proximity : MonoBehaviour {

	public bool isInRange = false;
	public int lookingFor;
	void Start(){
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.name == "Player" + lookingFor.ToString ()) {
			isInRange = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.name == "Player" + lookingFor.ToString ()) {
			isInRange = false;
		}
	}

}
