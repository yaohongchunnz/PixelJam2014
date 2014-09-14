using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour
{
	
	private Animator anim;              // Reference to the animator component.
	public Proximity proximity;

	public float speed=3f;
	public float turnSpeed=30f;

	public int playerNumber = 0;
	
	public bool connecting = false;
	public bool falling = false;
	public bool disabled = false;

	public GameObject topPoint;
	public GameObject connectionPoint;

	public GameObject thrusters;

	public GameObject boom;
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		proximity = GetComponent<Proximity> ();
	}
	
	public float h;
	public float v;
	void FixedUpdate ()
	{
		if (connecting) {
			transform.position = Vector3.Lerp(transform.position,topPoint.transform.position,Time.deltaTime*4);
			transform.rotation = Quaternion.Slerp(transform.rotation, topPoint.transform.rotation,Time.deltaTime*2);
		}

		if (falling) {
			
			transform.position = Vector3.Lerp(transform.position,connectionPoint.transform.position,Time.deltaTime*10);
			transform.rotation = Quaternion.Slerp(transform.rotation, connectionPoint.transform.rotation,Time.deltaTime*1);
				}
		if (disabled)
						return;
		// Cache the inputs.
		h = Input.GetAxis("H"+playerNumber.ToString());
	 	v = Input.GetAxis("V"+playerNumber.ToString());
		bool getOn = Input.GetButton("A"+playerNumber.ToString());



		if (h < 0.2f && h > -0.2f) {
			h=0f;
				}
		else if(v < 0.2f && v > -0.2f) {
			v=0f;
		}

		transform.Translate (Vector3.forward * speed * v * Time.deltaTime);
		transform.Rotate (Vector3.up * turnSpeed *h* Time.deltaTime);

		if (h > 0.1f || h < -0.1f || v > 0.1f || v<-0.1f) {
						anim.SetBool ("Walk", true);
				} else {
			anim.SetBool("Walk",false);
				}
		
		if (getOn && proximity.isInRange) {
			GameObject.Find ("Player"+(playerNumber+1).ToString()).BroadcastMessage("Combine","Player"+playerNumber.ToString());
			disabled=true;
			anim.SetBool("Walk",false);
			connectionPoint = GameObject.Find("Player"+(playerNumber+1).ToString()+"ConnectionPoint");
			topPoint = GameObject.Find("Player"+(playerNumber+1).ToString()+"TopPoint");
			connecting= true;
			rigidbody.useGravity=false;
			StartCoroutine(Fall ());
			// play particles & sound
			thrusters.particleSystem.Play(true);
			print ("combining!!");
		}
	}
	
	IEnumerator Fall() {				
		yield return new WaitForSeconds(0.9f);
		connecting = false;
		falling = true;
		thrusters.particleSystem.Stop (true);
		yield return new WaitForSeconds(0.4f);
		GameObject.Find ("Player"+(playerNumber+1).ToString()).BroadcastMessage("EnableTop");

		Destroy (this.gameObject);
	}

	public void DisableRobot(){
		boom.particleSystem.Play (true);
		disabled = true;
	}

	void Update ()
	{

	}

	void PlaySound(string s){
		// up or stomp

	}
	

}