using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
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
		if (collision.relativeVelocity.magnitude > 2) {
			print (collision.relativeVelocity.magnitude);
			currentHealth-=collision.relativeVelocity.magnitude;
		}
		
	}

	public float GetPercentHealth(){
		return currentHealth / maxHealth;
	}
}
