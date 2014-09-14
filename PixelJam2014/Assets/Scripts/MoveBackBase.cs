using UnityEngine;
using System.Collections;

public class MoveBackBase : MonoBehaviour {

	public Vector3 target;
	bool start = false;

	public GameObject shield;
	public GameObject vulnerable;
	public Health health;

	public GameObject thrusters;

	public GameObject bigbang;
	public AudioManager audioManager;
	void Start(){
		health = GetComponent<Health> ();
		audioManager = GameObject.FindGameObjectWithTag ("Sound").GetComponent<AudioManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (start) {
			transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime*4);
		}
	}

	public void LaunchOff(){
		animation.Stop ();
		thrusters.particleSystem.Play (true);
		transform.parent=null;
		target = new Vector3 (transform.position.x, transform.position.y+2f, transform.position.z-3f);
		start = true;
		StartCoroutine (Land ());
	}

	public IEnumerator Land(){
		yield return new WaitForSeconds(2f);
		//animation.CrossFade("Place");
		//transform.position = target;
		target = new Vector3 (target.x, .9f, target.z);
		yield return new WaitForSeconds(1f);
		shield.particleSystem.Play (true);
		health.damageReductionPercent = 1;
		
		gameObject.AddComponent<Rigidbody> ();
		rigidbody.isKinematic = false;
		rigidbody.useGravity = false;
		rigidbody.drag = 1f;
		rigidbody.mass = 1000f;
		rigidbody.angularDrag = 1f;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		//thrusters.particleSystem.Stop (true);
		//animation.CrossFade("Place");
	}

	public void Vulnerable(){
		shield.particleSystem.Stop (true);
		vulnerable.particleSystem.Play (true);
		health.damageReductionPercent = 0.2f;
	}

	public void ExplodeBase(){
		bigbang.particleSystem.Play (true);
		
		audioManager.playSound ("baseDeathExplosion", 1);
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, 23);
		foreach (Collider hit in colliders) {
			if (hit && hit.gameObject.tag=="Building")
			{
				hit.gameObject.BroadcastMessage("blowUp");
			}
			
		}

		// lose
		string team = "";
		if (tag == "LeftBase") {
						team = "RED TEAM";
		} else {
			team = "BLUE TEAM";
		}
		GameObject.Find ("AllText").guiText.text = team + " WINS!";
	}
}
