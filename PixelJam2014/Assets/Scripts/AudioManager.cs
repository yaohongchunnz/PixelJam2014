using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioSource leftSource;
	public AudioSource rightSource;


	public AudioClip baseDeathExplosion;
	public AudioClip borgDeathExplosion;
	public AudioClip combineNoise;
	public AudioClip getHit;
	public AudioClip pelvisAccelerating;
	public AudioClip pelvisIdle;
	public AudioClip pelvisMove;
	public AudioClip pelvisStop;
	public AudioClip pelvisThrustEnd;
	public AudioClip pelvisThrustHold;
	public AudioClip pelvisThrustStart;
	public AudioClip punchHit;
	public AudioClip throwPunch;
	public AudioClip torsoWalkUp;
	public AudioClip torsoWalkDown;

	// Use this for initialization
	void Start () {
		//this.playSound("handStep", "left");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playSound(string sound, int playerNumber, int types = 1, float delay = 0f){

		var track = Random.Range(1, types);
		var soundToPlay = sound + track.ToString();
		AudioClip clipToPlay = null;
		switch (soundToPlay){
		case "baseDeathExplosion1":
			clipToPlay = baseDeathExplosion;
			break;
		case "borgDeathExplosion1":
			clipToPlay = borgDeathExplosion;
		     break;
		case "combineNoise1":
			clipToPlay = combineNoise;
			break;
		case "pelvisAccelerating":
			clipToPlay = pelvisAccelerating;
			break;
		case "pelvisIdle":
			clipToPlay = pelvisIdle;
			break;
		case "pelvisMove":
			clipToPlay = pelvisMove;
			break;
		case "pelvisStop":
			clipToPlay = pelvisStop;
			break;
		case "pelvisThrustEnd":
			clipToPlay = pelvisThrustEnd;
			break;
		case "pelvisThrustHold":
			clipToPlay = pelvisThrustHold;
			break;
		case "pelvisThrustStart":
			clipToPlay = pelvisThrustStart;
			break;

		case "punchHit":
			clipToPlay = punchHit;
			break;

		case "throwPunch":
			clipToPlay = throwPunch;
			break;
			
		case "torsoWalkUp1":
			clipToPlay = torsoWalkUp;
			break;
		case "torsoWalkDown1":
			clipToPlay = torsoWalkDown;
			break;


	     
		}
		if(clipToPlay == null) {
			print ("Audio clip was not passed correctly to the Audio Manager");
			return;
		}

		if(playerNumber==1 || playerNumber==2){
			rightSource.PlayOneShot(clipToPlay);
		} else {
			leftSource.PlayOneShot(clipToPlay);
		}



	}
}
