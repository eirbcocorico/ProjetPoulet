using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

	public HealthBarHandler healthBarHandler;
	public GameObject respawnPoint;
	public Scrollbar scrollbarScript;
	public TextManagement textManagement;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -10.0f || scrollbarScript.size == 0){
			gameObject.transform.position = respawnPoint.transform.position + Vector3.up*2.0f ;
			gameObject.transform.eulerAngles = respawnPoint.transform.eulerAngles;
			healthBarHandler.setReturnToBegin(true);
			textManagement.SetText("Harry is a super chicken \n He can't die...");
			textManagement.BeginAnimation();
		}
	}
	public void RespawnOther(){
		gameObject.transform.position = respawnPoint.transform.position + Vector3.up*2.0f ;
		gameObject.transform.eulerAngles = respawnPoint.transform.eulerAngles;
		healthBarHandler.setReturnToBegin(true);
		textManagement.SetText("MORE ACID...");
		textManagement.BeginAnimation();
	}
}
