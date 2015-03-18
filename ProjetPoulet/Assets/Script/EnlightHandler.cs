using UnityEngine;
using System.Collections;

public class EnlightHandler : MonoBehaviour {

	public GameObject platform;

	// Use this for initialization
	void Start () {
		platform.GetComponent<EnlightNext>().Enlight();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Jumpable" && col.gameObject != platform){
			platform.GetComponent<EnlightNext>().Shadow();
			col.gameObject.GetComponent<EnlightNext>().Enlight();
			platform = col.gameObject;
		}
	}
}
