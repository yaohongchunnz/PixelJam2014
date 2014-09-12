using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		//All players
		if (Input.GetAxis ("Horizontal") < 0) {
			print("Left");
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			print("Right");
		}
		if (Input.GetAxis ("Vertical") > 0) {
			print("Down");
		}
		if (Input.GetAxis ("Vertical") < 0) {
			print("Up");
		}
		if (Input.GetButtonDown ("Select")) {
			print("Select");
		}
		if (Input.GetButtonDown ("Cancel")) {
			print("Cancel");
		}

		//Player 1
		if (Input.GetButtonDown ("A1")) {
			print("A1");
		}
		if (Input.GetButtonDown ("B1")) {
			print("B1");
		}
		if (Input.GetButtonDown ("X1")) {
			print("X1");
		}
		if (Input.GetButtonDown ("Y1")) {
			print("Y1");
		}
		if (Input.GetButtonDown ("L1")) {
			print("L1");
		}
		if (Input.GetButtonDown ("R1")) {
			print("R1");
		}


		//Player 2
		if (Input.GetButtonDown ("A2")) {
			print("A2");
		}
		if (Input.GetButtonDown ("B2")) {
			print("B2");
		}
		if (Input.GetButtonDown ("X2")) {
			print("X2");
		}
		if (Input.GetButtonDown ("Y2")) {
			print("Y2");
		}
		if (Input.GetButtonDown ("L2")) {
			print("L2");
		}
		if (Input.GetButtonDown ("R2")) {
			print("R2");
		}

	}
}
