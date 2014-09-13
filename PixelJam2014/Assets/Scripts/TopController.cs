using UnityEngine;
using System.Collections;

public class TopController : MonoBehaviour {
	public int playerNumber;
	// Use this for initialization
	void Start () {
		if (playerNumber != 1 || playerNumber != 3) {
			print ("Set top player!");
				}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
