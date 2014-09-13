using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {

	public Transform toIgnore;
	// Use this for initialization
	void Start () {
		Physics.IgnoreCollision (collider, toIgnore.collider);
	}
}
