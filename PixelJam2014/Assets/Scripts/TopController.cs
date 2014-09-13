using UnityEngine;
using System.Collections;

public class TopController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddTorque (0, 2, 0);
	}
}
