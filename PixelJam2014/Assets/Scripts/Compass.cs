﻿using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {
	//179
	public Transform playerTop;
	public float angle;
	public GameObject triangleTop;
	public GameObject triangleBottom;
	// Use this for initialization
	void Start () {
		if (tag == "LeftTeam") {
			playerTop = GameObject.Find ("Player1").transform;
			triangleTop = GameObject.Find("dynamicTopBlue");
			triangleBottom = GameObject.Find("dynamicBottomBlue");
		} else {
			playerTop = GameObject.Find ("Player3").transform;
			triangleTop = GameObject.Find("dynamicTopRed");
			triangleBottom = GameObject.Find("dynamicBottomRed");
				}
	}
	
	// Update is called once per frame
	public float normalized;
	void Update () {
		angle = playerTop.eulerAngles.y;
		if (angle < 180) {
						normalized = ((angle / 179)/2f)+0.5f;
				} else if (angle < 360) {
			normalized = ((angle / 359))-0.5f;

		}
		triangleTop.transform.position = new Vector3(normalized,0.5f,0);
		triangleBottom.transform.position = new Vector3(Mathf.Abs(normalized-1),0.5f,0);

	}
}