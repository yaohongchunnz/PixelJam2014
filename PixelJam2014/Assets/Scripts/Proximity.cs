using UnityEngine;
using System.Collections;

public class Proximity : MonoBehaviour {

	public bool isInRange = false;
	public int lookingFor;
	void Start(){
		if (transform.name == "Player2") {
			lookingFor=1;
		}
		else if (transform.name == "Player4") {
			lookingFor=3;
		}
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
