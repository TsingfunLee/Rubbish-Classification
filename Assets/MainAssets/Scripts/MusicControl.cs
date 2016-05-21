using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour
{

	void Awake(){
		AudioListener.pause = false;
	}

	public void PauseMusic ()
	{
		AudioListener.pause = true;
	}

	public void PlayMusic ()
	{
		AudioListener.pause = false;
	}
}
