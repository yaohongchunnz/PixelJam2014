using UnityEngine;
using System.Collections;

public class BottomControls : MonoBehaviour {
	public int playerNumber=0;
	
	public float rightDirection = 0f;
	public float leftDirection = 0f;

	// Use this for initialization
	void Start () {
		if (playerNumber != 2 && playerNumber != 4) {
			print ("Please set player number! 2 or 4");
		}
	}

	private float previous = 0;
	void Update(){
		rightDirection = Input.GetAxis ("RA" + playerNumber.ToString ());
		leftDirection = Input.GetAxis ("LA" + playerNumber.ToString ());
	}


	public float GetVertical(){
		if(leftDirection == rightDirection || (leftDirection <0.2f && leftDirection > -0.2f &&rightDirection <0.2f && rightDirection>-0.2f)){
			return 0f;
		}
		if(leftDirection > 0f && rightDirection > 0f){
			return (leftDirection+rightDirection)/2f;
		}
		else if(leftDirection < 0f && rightDirection < 0f){
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
	public float turnSpeed = 5f;
	public float speed = 500f;
	void FixedUpdate(){
		v = GetVertical();
		h = GetHorizontal();
		
		Vector3 targetVelocity = new Vector3(0,0,v);
		targetVelocity = transform.TransformDirection(targetVelocity);
		if(v < 0){			
			targetVelocity *= speed/2f;
		}
		else{
			targetVelocity *= speed;
		}
		
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = targetVelocity-velocity;
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		
		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
		
		// Rotation
		Vector3 turnVelocity = new Vector3(0,turnSpeed*h,0);
		Quaternion deltaRotation = Quaternion.Euler(turnVelocity * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
}
