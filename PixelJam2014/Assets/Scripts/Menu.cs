using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	GameObject[] menuButtons;
	// Use this for initialization
	void Start () {
		menuButtons = GameObject.FindGameObjectsWithTag ("MenuButton");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
