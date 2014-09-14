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
	public AudioClip torsoWalk1;
	public AudioClip torsoWalk1alt;
	public AudioClip torsoWalk2;
	public AudioClip torsoWalk2alt;

	// Use this for initialization
	void Start () {
		//this.playSound("handStep", "left");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void playSound(string sound, int playerNumber, int types = 1, float delay = 0f){

		var track = Random.Range(1, types);
		var soundToPlay = sound + track.ToString();
		AudioClip clipToPlay = null;
		switch (soundToPlay){
		case "baseDeathExplosion":
			clipToPlay = baseDeathExplosion;
			break;
		case "borgDeathExplosion":
			clipToPlay = borgDeathExplosion;
		     break;
		case "combineNoise":
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

		case "torsoWalk1":
			clipToPlay = torsoWalk1;
			break;
		case "torsoWalk1alt":
			clipToPlay = torsoWalk1alt;
			break;
		case "torsoWalk2":
			clipToPlay = torsoWalk2;
			break;
		case "torsoWalk2alt":
			clipToPlay = torsoWalk2alt;
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
