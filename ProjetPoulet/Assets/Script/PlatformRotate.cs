using UnityEngine;
using System.Collections;

public class PlatformRotate : MonoBehaviour {
	public float AngularSpeed;
	public float[] SmoothAngles;
	public float AngularRangeSmooth;
	public float AngularMinSpeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float tmpSpeed=AngularSpeed;
		float tmpAngle = Mathf.Clamp(transform.localEulerAngles.y,0.0f,360.0f);
		for(int i=0;i<SmoothAngles.Length;i++){
			if((SmoothAngles[i]+AngularRangeSmooth - tmpAngle) > 360.0f){
				tmpAngle += 360.0f;
			}
			else if((tmpAngle-(SmoothAngles[i]-AngularRangeSmooth)) > 360.0f){
				tmpAngle -= 360.0f;
			}

			if(tmpAngle < (SmoothAngles[i]+ AngularRangeSmooth) && tmpAngle > (SmoothAngles[i]- AngularRangeSmooth)){
				float tmp = AngularMinSpeed + (AngularSpeed-AngularMinSpeed) * Mathf.Abs((SmoothAngles[i] -tmpAngle)/AngularRangeSmooth);

				if(tmp < tmpSpeed){
					tmpSpeed = tmp;
				}
			}
		}
		transform.Rotate(Vector3.up*Time.deltaTime*tmpSpeed);
	}
}
