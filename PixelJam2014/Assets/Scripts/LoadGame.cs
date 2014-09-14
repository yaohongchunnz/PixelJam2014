using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(LoadLevel());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LoadLevel(){
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel("level1");
	
	}
}
