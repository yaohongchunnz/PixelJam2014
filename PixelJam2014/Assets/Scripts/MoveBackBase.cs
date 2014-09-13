using UnityEngine;
using System.Collections;

public class MoveBackBase : MonoBehaviour {

	public Vector3 target;
	bool start = false;

	public GameObject shield;
	public GameObject vulnerable;
	public Health health;

	void Start(){
		health = GetComponent<Health> ();
	}

	// Update is called once per frame
	void Update () {
		if (start) {
			transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime*2);
				}
	}

	public void LaunchOff(){
		animation.Stop ();
		transform.parent=null;
		target = new Vector3 (transform.position.x, transform.position.y+1.5f, transform.position.z);
		start = true;
		StartCoroutine (Land ());
	}

	public IEnumerator Land(){
		yield return new WaitForSeconds(5f);
		//animation.CrossFade("Place");
		//transform.position = target;
		target = new Vector3 (target.x, .9f, target.z);
		yield return new WaitForSeconds(4f);
		//animation.CrossFade("Place");
	}

	public void Vulnerable(){
		shield.particleSystem.Stop (true);
		vulnerable.particleSystem.Play (true);
		health.damageReductionPercent = 0.2f;
	}
}
