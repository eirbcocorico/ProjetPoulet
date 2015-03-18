using UnityEngine;
using System.Collections;

public class SkyboxManager : MonoBehaviour {

	public float time = 10.0f;
	private float tmpTime;
	public Material skyboxMat;
	private Color nextColor;
	private Color currentColor;

	// Use this for initialization
	void Start () {
		currentColor =  skyboxMat.GetColor("_Tint");
		nextColor =  new Color (Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
	}
	
	// Update is called once per frame
	void Update () {
		tmpTime += Time.deltaTime;

		skyboxMat.SetColor ("_Tint", new Color(Mathf.Lerp(currentColor.r,nextColor.r, tmpTime/time),
		                                            Mathf.Lerp(currentColor.g,nextColor.g, tmpTime/time),
		                                            Mathf.Lerp(currentColor.b,nextColor.b, tmpTime/time),
		                                            skyboxMat.GetColor("_Tint").a));

		if(tmpTime<= (time/2)){
			skyboxMat.SetFloat("_Blend", Mathf.Lerp(0.0f,1.0f, tmpTime/(time/2)));
		}
		else{
			skyboxMat.SetFloat("_Blend", Mathf.Lerp(1.0f,0.0f, (tmpTime - (time/2))/(time/2)));
			if(tmpTime > time){
				tmpTime=0;
				currentColor = nextColor;
				nextColor = new Color (Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));	
			}
		}



	}
}
