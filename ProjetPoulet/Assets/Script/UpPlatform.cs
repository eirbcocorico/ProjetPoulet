using UnityEngine;
using System.Collections;

public class UpPlatform : MonoBehaviour {

	public  int range;
	public float speed;
	private bool up;
	public float[] pointSmooth;
	public float minSpeed;
	public float rangeSmooth;
	public ParticleSystem particleSystem;



	// Use this for initialization
	void Start () {
		up=true;
	}
	
	// Update is called once per frame
	void Update () {
		float tmpSpeed = speed;
		for(int i = 0; i < pointSmooth.Length; i++){
			if(transform.localPosition.y < pointSmooth[i]+rangeSmooth && transform.localPosition.y > pointSmooth[i]-rangeSmooth){
				float tmp = minSpeed + (speed-minSpeed)*Mathf.Abs((pointSmooth[i]-transform.localPosition.y)/rangeSmooth);
				if(tmp < tmpSpeed){
					tmpSpeed=tmp;
				}
			}
		}
		if(up){

			if(particleSystem.gameObject.activeInHierarchy == false){
				particleSystem.gameObject.SetActive(true);
			}
			transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y + Time.deltaTime*tmpSpeed,transform.localPosition.z);

			if(transform.localPosition.y >= range){
				up = false;
			}
		}
		else{
			if(particleSystem.gameObject.activeInHierarchy == true){
				particleSystem.gameObject.SetActive(false);
			}
			transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y - Time.deltaTime*tmpSpeed,transform.localPosition.z);
			if(transform.localPosition.y <= 0){
				up = true;
			}
		}
	}
}
