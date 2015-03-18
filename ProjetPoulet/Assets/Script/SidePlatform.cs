using UnityEngine;
using System.Collections;

public class SidePlatform : MonoBehaviour {
	
	public  int range;
	public float speed;
	private bool side;
	public float[] pointSmooth;
	public float minSpeed;
	public float rangeSmooth;
	public ParticleSystem go;
	public ParticleSystem back;

	
	
	// Use this for initialization
	void Start () {
		side=true;
		back.gameObject.SetActive(false);
		go.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		float tmpSpeed = speed;
		for(int i = 0; i < pointSmooth.Length; i++){
			if(transform.localPosition.x < pointSmooth[i]+rangeSmooth && transform.localPosition.x > pointSmooth[i]-rangeSmooth){
				float tmp = minSpeed + (speed-minSpeed)*Mathf.Abs((pointSmooth[i]-transform.localPosition.x)/rangeSmooth);
				if(tmp < tmpSpeed){
					tmpSpeed=tmp;
				}
			}
		}
		if(side){
			if(!(go.gameObject.activeInHierarchy||!back.gameObject.activeInHierarchy)){
				back.gameObject.SetActive(false);
				go.gameObject.SetActive(true);
			}
			
			//print (tmpSpeed); 
			transform.localPosition = new Vector3(transform.localPosition.x+ Time.deltaTime*tmpSpeed,transform.localPosition.y ,transform.localPosition.z);
			
			if(transform.localPosition.x >= range){
				side = false;
			}
		}
		else{
			if(!(!go.gameObject.activeInHierarchy||back.gameObject.activeInHierarchy)){
				back.gameObject.SetActive(true);
				go.gameObject.SetActive(false);
			}
			transform.localPosition = new Vector3(transform.localPosition.x- Time.deltaTime*tmpSpeed,transform.localPosition.y ,transform.localPosition.z);
			if(transform.localPosition.x <= 0){
				side = true;
			}
		}
	}
}
