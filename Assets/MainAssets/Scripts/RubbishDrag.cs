using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class RubbishDrag : MonoBehaviour ,IBeginDragHandler,IDragHandler,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
	// this rubbish
	public GameObject rubbish;

	// this rubbish's position
	public Vector3 pos;

	// this rubbish's info
	public string info;
	Text infoText;

	// Audio
	AudioSource audioSwipe;
	AudioSource audioClick;

	// Use this for initialization
	void Start ()
	{
		// initialize
		rubbish = this.gameObject;

		pos = rubbish.GetComponent<RectTransform> ().localPosition;

		audioSwipe = GameObject.Find ("Audio/Swipe").GetComponent<AudioSource> ();
		audioClick = GameObject.Find ("Audio/Click").GetComponent<AudioSource> ();

		infoText = GameObject.Find ("State/Info").GetComponent<Text> ();
	}
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		audioClick.Play ();
	}

	public void OnDrag (PointerEventData eventData)
	{
		rubbish.transform.position = Input.mousePosition;
		rubbish.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
	}

	public void OnDrop (PointerEventData eventData)
	{
        // let rubbish back its own position
		rubbish.GetComponent<RectTransform> ().localPosition = pos;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		rubbish.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);

		audioSwipe.Play ();

		infoText.text = info;
		StartCoroutine ("Delay");
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (rubbish) {
			rubbish.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds (1f);
		infoText.text = "";
	}
}
