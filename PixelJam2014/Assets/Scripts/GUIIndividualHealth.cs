using UnityEngine;
using System.Collections;

public class GUIIndividualHealth : MonoBehaviour {
	public int playerNumber;
	public Health health; 
	// Use this for initialization
	void Start () {
		if( GameObject.Find ("Player" + playerNumber.ToString ()) != null)
		health = GameObject.Find ("Player" + playerNumber.ToString ()).GetComponent<Health>();
		if (health == null) {
			health = GameObject.Find ("DetachedTop" + playerNumber.ToString ()).GetComponent<Health>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (health == null) {
			
			guiText.text = "";
			return;
				}
		int hp = ((int)(health.GetPercentHealth () * 100));
		if (hp < 0) {
			hp=0;
				}
		guiText.text = "HP: "+hp.ToString () + "%";
	
	}
}
