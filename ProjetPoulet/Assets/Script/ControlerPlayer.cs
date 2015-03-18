using UnityEngine;
using System.Collections;

public class ControlerPlayer : MonoBehaviour {

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public float jumpHeight;
	private bool jumping = false;

	void Awake(){
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float  tmp = Input.GetAxis("Vertical");
		if(jumping){
			GetComponent<Animator>().SetBool("Jumping",true);
		}
		else{

			if(tmp!=0){
				GetComponent<Animator>().SetBool("Walking",true);

			}
			else{
				GetComponent<Animator>().SetBool("Walking",false);
			}
			GetComponent<Animator>().SetBool("Jumping",false);
		}
		tmp *= speed;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		Vector3 velocityChange = (tmp * transform.forward - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x,-maxVelocityChange,maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z,-maxVelocityChange,maxVelocityChange);
		velocityChange.y = 0;
		GetComponent<Rigidbody>().AddForce(velocityChange,ForceMode.VelocityChange);

	
		if (Input.GetMouseButtonDown (0) && !jumping) {
			GetComponent<Rigidbody>().velocity = new Vector3(velocity.x,CalculateJumpVerticalSpeed(), velocity.z);
		}

		//GetComponent<Rigidbody>().AddForce(new Vector3(0,-gravity*GetComponent<Rigidbody>().mass));

	}

	
	void SetVelocityOnPlayer(){
		float  tmp = Input.GetAxis("Vertical");
		if(Mathf.Abs(tmp) > 0.2f){
			gameObject.transform.Translate(speed*tmp*Time.deltaTime*Vector3.forward);
		}
	}


	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Jumpable" && col.collider.bounds.center.y <= GetComponent<Rigidbody>().worldCenterOfMass.y){
			gameObject.transform.parent =col.gameObject.transform;
			jumping=false;
			GetComponent<Animator>().SetBool("OnFloor",true);
		}

	}

	void OnCollisionExit(Collision col)
	{
		if(transform.parent!=null){
			if(col.gameObject == transform.parent.gameObject){
				jumping = true;
				transform.parent = null;
				GetComponent<Animator>().SetBool("OnFloor",false);
			}
		}
	}

	float CalculateJumpVerticalSpeed(){
		return Mathf.Sqrt(2*jumpHeight*gravity);
	}
}


