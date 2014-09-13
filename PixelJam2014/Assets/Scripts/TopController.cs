using UnityEngine;
using System.Collections;

public class TopController : MonoBehaviour {
	public int playerNumber;
	public bool disabled = false;

	public float turnSpeed = 50f;
	// Use this for initialization
	void Start () {
		if (playerNumber != 1 && playerNumber != 3) {
			print ("Set top player!");
				}
	}
	
	// Update is called once per frame
	void Update () {
		if (disabled)
						return;


	}
	public float h;
	void FixedUpdate(){
		if (disabled)
						return;
		h = Input.GetAxis ("LA" + playerNumber.ToString ());
		// Rotation
		Vector3 turnVelocity = new Vector3 (0, turnSpeed * h* Time.deltaTime, 0);
		Quaternion deltaRotation = Quaternion.Euler (turnVelocity );
		//rigidbody.rot(transform.up*turnSpeed*h, ForceMode.Acceleration);
		rigidbody.MoveRotation (rigidbody.rotation * deltaRotation);
	}
	
	public void DisableRobot(){
		disabled = true;
	}

}
