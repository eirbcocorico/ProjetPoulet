using UnityEngine;
using System.Collections;

public class BeginCameraHandler : MonoBehaviour {
	
	public GameObject canva;
	public MouseLook mouseLookCamera;
	public MouseLook mouseLookPlayer;
	public ControlerPlayer controlPlayer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnAnimationFinish(){
		canva.SetActive(true);
		mouseLookCamera.enabled = true;
		mouseLookPlayer.enabled = true;
		controlPlayer.enabled = true;
	}
}
