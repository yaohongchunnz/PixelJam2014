using UnityEngine;
using System.Collections;

public class FistsOfFury : MonoBehaviour {
	public int leftAttack = Animator.StringToHash ("LeftLayer.LeftArmAttackAnimation");
	public int rightAttack = Animator.StringToHash ("RightLayer.RightArmAttackAnimation");
	public int rightBlock = Animator.StringToHash ("RightLayer.RightArmBlockAnimation");
	public int leftBlock = Animator.StringToHash ("LeftLayer.LeftArmBlockAnimation");
	public Animator anim;
	public Animator animEnemy;
	public float damage = 10f;
	void OnCollisionEnter(Collision other){
		if (animEnemy == null) {
			if (transform.root.name == "Player2") {
				GameObject enemyTop = GameObject.FindGameObjectWithTag("Player3Animation");
				if(enemyTop != null){
					animEnemy = enemyTop.GetComponent<Animator>();
				}
			}
			if (transform.root.name == "Player4") {
				GameObject enemyTop = GameObject.FindGameObjectWithTag("Player1Animation");
				if(enemyTop != null){
					animEnemy = enemyTop.GetComponent<Animator>();
				}
			}
		}
		if (anim.GetCurrentAnimatorStateInfo (1).nameHash == leftAttack) {
			// LEFT
			print ("damaging " + other.gameObject.name +"  with left");
			float calcDamage = damage;
			if(animEnemy!=null){ // enemy is attached
				if(animEnemy.GetCurrentAnimatorStateInfo(1).nameHash == leftBlock){
					calcDamage -= 4;
				}
				if(animEnemy.GetCurrentAnimatorStateInfo(2).nameHash == rightBlock){
					calcDamage -= 4;				
				}
			}
			other.gameObject.BroadcastMessage("Damage",calcDamage,SendMessageOptions.DontRequireReceiver);
		}
//		print (anim.GetCurrentAnimatorStateInfo (1).nameHash + " : " + leftAttack);
//		print (anim.GetCurrentAnimatorStateInfo (2).nameHash + " : " + rightAttack);
		if (anim.GetCurrentAnimatorStateInfo (2).nameHash == rightAttack) {
			// RIGHT
			print ("damaging " + other.gameObject.name +"  with right");
			float calcDamage = damage;
			if(animEnemy!=null){ // enemy is attached
				if(animEnemy.GetCurrentAnimatorStateInfo(1).nameHash == leftBlock){
					calcDamage -= 4;
				}
				if(animEnemy.GetCurrentAnimatorStateInfo(2).nameHash == rightBlock){
					calcDamage -= 4;				
				}
			}
			other.gameObject.BroadcastMessage("Damage",calcDamage,SendMessageOptions.DontRequireReceiver);
		}
//		if (anim.GetBool ("LeftAttack") && !anim.GetBool ("RightAttack")) {
//
////			print ("damaging " + other.gameObject.name +"  with left");
//			other.gameObject.BroadcastMessage("Damage",10f,SendMessageOptions.DontRequireReceiver);
//		}
//		if (anim.GetBool ("RightAttack") && !anim.GetBool ("LeftAttack")) {
//			print ("damaging " + other.gameObject.name +"  with right");
//			other.gameObject.BroadcastMessage("Damage",10f,SendMessageOptions.DontRequireReceiver);
//		}
		print (other.gameObject.name);
	}

	// Use this for initialization
	void Start () {
		if (transform.root.name == "Player2") {
			anim = GameObject.FindGameObjectWithTag("Player1Animation").GetComponent<Animator>();
		}
		if (transform.root.name == "Player4") {
			anim = GameObject.FindGameObjectWithTag("Player3Animation").GetComponent<Animator>();
			GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player3Animation"); // Get a list of all the objets with the player tag into an array
			for (int i = 0; i < playerList.Length; i++)
			{
				if (playerList[i].GetComponent<Animator>() != null) // See if we can find the script on the returned object
				{
					anim = playerList[i].GetComponent<Animator>();
					break;
				}
			}
			if (anim == null) { // Check to make sure we found the player.
				Debug.LogError("Unable to find player object!");
				return; // Prevent any NullExceptionErrors
			}
		}
		print (leftAttack);
	}
	
	// Update is called once per frame
	void Update () {
		//print (anim.GetCurrentAnimatorStateInfo (2).nameHash);
	}
}
