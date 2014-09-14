using UnityEngine;
using System.Collections;

public class BottomControls : MonoBehaviour {
	public int playerNumber=0;
	
	public float rightDirection = 0f;
	public float leftDirection = 0f;
	public bool rightBoost = false;
	public bool leftBoost = false;

	public bool carryingBase = true;
	
	public GameObject myBase;
	public GameObject top;

	public GameObject myGUI;

	public GameObject boom;
	// Use this for initialization
	void Start () {
		if (playerNumber != 2 && playerNumber != 4) {
			print ("Please set player number! 2 or 4");
		}
		if (name == "Player2") {
						playerNumber = 2;
			tag = "LeftTeamRobot";
				} else if (name == "Player4") {
			playerNumber=4;
			tag = "RightTeamRobot";
				}

		gameObject.AddComponent<Rigidbody> ();
		rigidbody.drag = 1f;
		rigidbody.mass = 100f;
		rigidbody.angularDrag = 1f;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		StartCoroutine (FreezeY());

	}

	IEnumerator FreezeY(){
		yield return new WaitForSeconds(1f);
		//rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
	}

	private float previous = 0;
	void Update(){
		rightDirection = Input.GetAxis ("RA" + playerNumber.ToString ());
		leftDirection = Input.GetAxis ("LA" + playerNumber.ToString ());
		if (Input.GetButtonDown ("R" + playerNumber.ToString ())) {
			rightBoost = true;
		} 
		
		if(Input.GetButtonUp ("R" + playerNumber.ToString ())){
			rightBoost=false;
		}
		if (Input.GetButtonDown ("L" + playerNumber.ToString ())) {
			leftBoost = true;
		} 
		
		if(Input.GetButtonUp ("L" + playerNumber.ToString ())){
			leftBoost=false;
		}
	}


	public float GetVertical(){
		if((leftDirection <0.2f && leftDirection > -0.2f &&rightDirection <0.2f && rightDirection>-0.2f)){
			return 0f;
		}
		if(leftDirection > 0.1f && rightDirection > 0.1f){
			return (leftDirection+rightDirection)/2f;
		}
		else if(leftDirection < -0.1f && rightDirection < -0.1f){
			return (leftDirection+rightDirection)/2f;
		}
		else {
			return 0f;
		}
	}

	public float GetHorizontal(){
		if(leftDirection == rightDirection || (leftDirection <0.2f && leftDirection > -0.2f &&rightDirection <0.2f && rightDirection>-0.2f)){
			return 0f;
		}
		else if(leftDirection < rightDirection){ //turn left
			if(leftDirection<0f){
				if(rightDirection > 0f){
					return -(Mathf.Abs(leftDirection)+rightDirection/2f);	
				}	
				else{
					return -((Mathf.Abs(leftDirection)-Mathf.Abs(rightDirection))/2f);
				}
			}
			
			else{
				return -((rightDirection-leftDirection)/2f);
			}
		}
		else{ //L > R
			if(rightDirection<0f){ //turnright
				if(leftDirection > 0f){
					return (Mathf.Abs(rightDirection)+leftDirection/2f);	
				}	
				else{
					return ((Mathf.Abs(rightDirection)-Mathf.Abs(leftDirection))/2f);
				}
			}
			
			else{
				return ((leftDirection-rightDirection)/2f);
			}
		}
	}	

	public float v;
	public float h;
	public float maxVelocityChange = 10f;
	public float turnSpeed = 75f;
	public float speed = 7f;
	public float maxVelocity = 10;
	public float currentVelocity = 10;
	public bool disabled = false;
	void FixedUpdate(){
		v = GetVertical();
		h = GetHorizontal();
		if (v > 0.9f) {
			v = 1f;
		}
		else if (v < -0.9f) {
			v=-1f;
		}
		if (h > 0.9f) {
			h = 1f;
		}
		else if (h < -0.9f) {
			h=-1f;
		}
		if (h < 0.1f && h > -0.1f) {
			h=0f;
		}
		if (v < 0.1f && v > -0.1f) {
			v=0f;
		}
		h *= 2f;

		if (rightBoost) {
			if(v!=0f){
				v+=(v*0.5f);
			}
			if(h!=0f){
				h+=(h*1f);
			}
				}
//		if (rightBoost) {
//			if(v!=0){
//				v+=(0.25f*v);
//			}
//			if(h!=0 || v!=0){
//				h-=(1f);
//			}
//		}
//		if (leftBoost) {
//			if(v!=0){
//				v+=(0.25f*v);
//			}
//			if(h!=0 || v!=0){
//				h+=(1f);
//			}
//		}
		Move ();
		
		//animation
		if (v != 0 || h != 0) {
			PlayWheels ();
		} else {
			StopWheels();
		}
	}

	void Move ()
	{
		if (disabled)
						return;
		Vector3 targetVelocity = new Vector3 (0, 0, v);
		targetVelocity = transform.TransformDirection (targetVelocity);
		if (v < 0) {
			targetVelocity *= speed / 1.3f;
		}
		else {
			targetVelocity *= speed;
		}
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = targetVelocity - velocity;
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		//rigidbody.MovePosition(transform.position + (new Vector3(0,0,speed)*v) * Time.deltaTime);
		rigidbody.AddForce (velocityChange*Time.deltaTime, ForceMode.VelocityChange);
		//if(rigidbody.velocity.z < maxVelocity && rigidbody.velocity.z > -maxVelocity)
		//rigidbody.AddForce(transform.forward*speed*v, ForceMode.Acceleration);


		// Rotation
		Vector3 turnVelocity = new Vector3 (0, turnSpeed * h* Time.deltaTime, 0);
		Quaternion deltaRotation = Quaternion.Euler (turnVelocity );
		//rigidbody.rot(transform.up*turnSpeed*h, ForceMode.Acceleration);
		rigidbody.MoveRotation (rigidbody.rotation * deltaRotation);


		//rigidbody.AddTorque (0, turnSpeed * h*Time.deltaTime, 0,ForceMode.Acceleration);
	}

	public void PlayWheels(){
		GameObject[] wheels = GameObject.FindGameObjectsWithTag ("Player" + playerNumber.ToString () + "Wheels");
		for (int i = 0; i < wheels.Length; i++) {
			wheels[i].animation.CrossFade("WheelSpin");
		}
	}

	public void StopWheels(){
		GameObject[] wheels = GameObject.FindGameObjectsWithTag ("Player" + playerNumber.ToString () + "Wheels");
		for (int i = 0; i < wheels.Length; i++) {
			wheels[i].animation.Stop();
		}
	}
	public void DisableRobot(){
			disabled = true;
		print (name + " died");
		boom.particleSystem.Play (true);
		if (carryingBase) {
						myBase.GetComponent<MoveBackBase> ().ExplodeBase ();
				} else {
			myBase.GetComponent<MoveBackBase>().Vulnerable();
				}

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, 7);
		foreach (Collider hit in colliders) {
			if (hit && hit.gameObject.tag=="Building")
			{
				hit.gameObject.BroadcastMessage("blowUp");
			}
			
		}
	}

	public void Combine(string caller){
		print ("Checking...!");
		if (caller.Contains ("Player" + (playerNumber - 1).ToString ())) {
			if(carryingBase){
				myBase.BroadcastMessage("LaunchOff");
				carryingBase=false;
				print ("Combined!");
				rigidbody.mass = 2000f;
			}

				} else {
			//enemy has combined!
				}
	}
	public void EnableTop(){

		top.SetActive (true);
		GameObject gui = Instantiate (myGUI) as GameObject;
		GetComponent<Health> ().IncreaseHealth (50);
		GetComponent<Health> ().damageReductionPercent = 0.2f;
	}
}
