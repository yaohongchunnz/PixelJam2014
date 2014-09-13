using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public float damageReductionPercent; // goes from 0-1. 1 being 100% damage reduction
	public bool dead = false;
	public bool vulnerable=true;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if(!dead)
		if (collision.relativeVelocity.magnitude > 2) {
			print (collision.relativeVelocity.magnitude);

			currentHealth-=(collision.relativeVelocity.magnitude*(1-damageReductionPercent));
			dead = currentHealth <=0;
			if(dead)Die ();
		}
		
	}

	public float GetPercentHealth(){
		return currentHealth / maxHealth;
	}

	public void Die(){	
		string top = "";
		string bottom = name;
		if (name == "Player2") {
						top = "Player1";
				} else if (name == "Player4") {
			top = "Player3";
				}
		if (top != "") {
			GameObject.Find (top).GetComponent<TopController>().DisableRobot();
			GetComponent<BottomControls>().DisableRobot();
		}
	}
}
