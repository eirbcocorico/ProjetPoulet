using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AcidHandler : MonoBehaviour {

	public GameObject healthBar;
	public Respawn respawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col) {
		if(col.gameObject.tag == "Acid"){
			//healthBar.GetComponent<HealthBarHandler>().setReturnToBegin(true);
			//healthBar.GetComponent<HealthBarHandler>().setTmpForLerp(healthBar.GetComponent<Scrollbar>().size);
			//healthBar.GetComponent<HealthBarHandler>().setTmpTime(0);
			//Destroy(col.gameObject);
			respawn.RespawnOther();
		}
	}
}
