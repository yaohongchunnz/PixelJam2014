using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("AllText").guiText.text = "Find your teammate!";
		StartCoroutine (clear ());
	}

	IEnumerator clear(){
		yield return new WaitForSeconds (3.0f);
		GameObject.Find ("AllText").guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonDown ("Restart")) {
			Application.LoadLevel("level1");
				}
	}

	public void Spawn(GameObject robot){
		StartCoroutine (trySpawn (robot));
	}
	
	IEnumerator trySpawn(GameObject robot){
		yield return new WaitForSeconds (5f);
		Instantiate (robot, GameObject.Find ("RedTeamSpawn").transform.position,GameObject.Find ("RedTeamSpawn").transform.rotation);
	}
}
