using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class HealthBarHandler : MonoBehaviour {
	public float totalTime = 5.0f;
	public GameObject sprite;
	public Color maxBar;
	public Color minBar;
	private bool returnToBegin;
	private float tmpForLerp;
	public float timeLerp;
	private float tmpTime;
	public GameObject camera;
	public float minBlur;
	public float maxBlur;
	

	// Use this for initialization
	void Start () {
		GetComponent<Scrollbar>().size = 1;

	}
	
	// Update is called once per frame
	void Update () {
		if(returnToBegin){
			tmpTime += Time.deltaTime;
			GetComponent<Scrollbar>().size = Mathf.Lerp(tmpForLerp,1.0f,tmpTime/timeLerp);
			sprite.GetComponent<Image>().color = GetComponent<Scrollbar>().size * maxBar + (1-GetComponent<Scrollbar>().size) * minBar;
			if(GetComponent<Scrollbar>().size == 1){
				returnToBegin = false;
			}
		}
		else{
			GetComponent<Scrollbar>().size -= (Time.deltaTime/totalTime);
			sprite.GetComponent<Image>().color = GetComponent<Scrollbar>().size * maxBar + (1-GetComponent<Scrollbar>().size) * minBar;
		}
		camera.GetComponent<MotionBlur>().blurAmount = minBlur + (maxBlur-minBlur) * (1-GetComponent<Scrollbar>().size);
	}

	public void setReturnToBegin(bool a){
		returnToBegin = a;
	}

	public void setTmpForLerp(float a){
		tmpForLerp = a;
	}

	public void setTmpTime(float a){
		tmpTime = a;
	}

}
