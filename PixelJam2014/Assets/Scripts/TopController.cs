using UnityEngine;
using System.Collections;

public class TopController : MonoBehaviour {
	public int playerNumber;
	public bool disabled = false;
	public GameObject pivotpoint;
	public float angle;
	public float turnSpeed = 50f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		if (playerNumber != 1 && playerNumber != 3) {
			print ("Set top player!");
		}
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (disabled)
						return;
		angle = transform.eulerAngles.y;
		
		if (Input.GetButtonDown ("L" + playerNumber.ToString ())) {
			anim.SetBool("LeftBlock",true);
		}
		if (Input.GetButtonUp ("L" + playerNumber.ToString ())) {
			anim.SetBool("LeftBlock",false);			
		}
		if (Input.GetButtonDown ("R" + playerNumber.ToString ())) {
			anim.SetBool("RightBlock",true);
		}
		if (Input.GetButtonUp ("R" + playerNumber.ToString ())) {
			anim.SetBool("RightBlock",false);			
		}
		punchingFists = Input.GetAxisRaw ("T" + playerNumber.ToString ());
		if (punchingFists == 1) {
						anim.SetBool ("LeftAttack", true);			
				} else if (punchingFists == -1) {
						anim.SetBool ("RightAttack", true);
				} else {
			
			anim.SetBool ("LeftAttack", false);
			anim.SetBool ("RightAttack", false);
				}


	}
	
	public float previous = 0;
	public float punchingFists;
	public float h;
	void FixedUpdate(){
		if (disabled)
						return;
		h = Input.GetAxis ("LA" + playerNumber.ToString ());
		if (h < 0.1f && h > -0.1f)
						h = 0;

		// rotation
		transform.RotateAround(pivotpoint.transform.position, Vector3.up, turnSpeed * h * Time.deltaTime);
	}
	
	public void DisableRobot(){
		disabled = true;
	}

}
