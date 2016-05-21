using UnityEngine;
using System.Collections;

public class OnExit : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("shake", true);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        anim.SetBool("shake", false);
    }

	void OnTriggerExit2D(Collider2D other){
		anim.SetBool ("shake", false);
	}
}
