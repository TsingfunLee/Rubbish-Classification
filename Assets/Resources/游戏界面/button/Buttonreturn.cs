using UnityEngine;
using System.Collections;

public class Buttonreturn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick2_() 
	{
		Debug.Log("onclick");
		Application.LoadLevel (0);
	}

}
