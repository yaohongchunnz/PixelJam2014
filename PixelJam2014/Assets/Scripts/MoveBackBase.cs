﻿using UnityEngine;
using System.Collections;

public class MoveBackBase : MonoBehaviour {

	Vector3 target;
	bool start = false;
	// Update is called once per frame
	void Update () {
		if (start) {
			transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime*2);
				}
	}

	public void LaunchOff(){
		animation.Stop ();
		transform.parent=null;
		target = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);
		start = true;
		StartCoroutine (Land ());
	}

	public IEnumerator Land(){
		yield return new WaitForSeconds(1f);
		animation.CrossFade("Place");
		transform.position = target;
	}
}