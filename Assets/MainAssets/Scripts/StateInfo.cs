using UnityEngine;
using System.Collections;

public class StateInfo : MonoBehaviour
{
	[SerializeField]GameObject right;
	[SerializeField]GameObject wrong;
	[SerializeField]GameObject victory;

	Animator animR;
	Animator animW;
	Animator animV;
	AnimatorStateInfo animState;

	// Use this for initialization
	void Start ()
	{
		animR = right.GetComponent<Animator> ();
		animW = wrong.GetComponent<Animator> ();
		animV = victory.GetComponent<Animator> ();
	}

	public void Right ()
	{
		right.SetActive (true);
		wrong.SetActive (false);
		animR.SetBool ("visible", true);

		animState = animR.GetCurrentAnimatorStateInfo (0);
		if (animState.fullPathHash == Animator.StringToHash ("Base Layer.State")) {
			if (!animR.IsInTransition (0)) {
				animR.SetBool ("visible", false);
			}
		}
	}

	public void Wrong ()
	{
		right.SetActive (false);
		wrong.SetActive (true);
		animW.SetBool ("visible", true);

		animState = animW.GetCurrentAnimatorStateInfo (0);
		if (animState.fullPathHash == Animator.StringToHash ("Base Layer.State")) {
			if (!animW.IsInTransition (0)) {
				animW.SetBool ("visible", false);
			}
		}
	}

	public void Vicotory ()
	{
		victory.SetActive (true);
		animV.SetBool ("victory", true);
		Debug.Log ("victory");
	}
}
