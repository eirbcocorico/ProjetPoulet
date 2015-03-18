using UnityEngine;
using System.Collections;

public class EnlightNext : MonoBehaviour {

	public GameObject nextPlatform;
	public Shader enlightShader;
	public Shader usualShader;
	public Color colorEnlight;
	private Color[] usualColor;

	// Use this for initialization
	void Start () {
		if(usualShader == null){
			usualShader = nextPlatform.GetComponentInChildren<MeshRenderer>().material.shader;
		}
		MeshRenderer[] mat = nextPlatform.GetComponentsInChildren<MeshRenderer>();
		usualColor = new Color[mat.Length];
		for(int i = 0; i < mat.Length;i++){
			if(mat[i].gameObject.tag == "Jumpable"){
				usualColor[i] = mat[i].material.GetColor("_Tint");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enlight(){
		MeshRenderer[] mat = nextPlatform.GetComponentsInChildren<MeshRenderer>();
		foreach(MeshRenderer mati in mat){
			if(mati.gameObject.tag == "Jumpable"){
				mati.material.shader = enlightShader;
				mati.material.SetColor("_Tint", colorEnlight);
			}
		}
	}

	public void Shadow(){
		MeshRenderer[] mat = nextPlatform.GetComponentsInChildren<MeshRenderer>();
		for(int i=0; i < mat.Length;i++){
			if(mat[i].gameObject.tag == "Jumpable"){
				mat[i].material.shader = usualShader;
				mat[i].material.SetColor("_Tint", usualColor[i]);
			}
		}
	}
}
