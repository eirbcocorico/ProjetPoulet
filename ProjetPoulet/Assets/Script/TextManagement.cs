using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManagement : MonoBehaviour {

	public Animator anim;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(string text){
		gameObject.GetComponent<Text>().text = text;
	}

	public void EndAnimation(){
		anim.SetBool("Display",false);
	}

	public void BeginAnimation(){
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("DisplayText")){
			anim.CrossFade("DisplayText", 0.05f, -1, 0f);
		}

		anim.SetBool("Display",true);
	}
}
