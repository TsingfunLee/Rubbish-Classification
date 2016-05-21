using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{

    // 对应垃圾tag
    public string tagName;

    // Audio
    AudioSource audioRight;
    AudioSource audioWrong;
    AudioSource audioDestroy;
    AudioSource audioEnd;

    // right rubbish num
    static int rightNum;

    // prompting message
    StateInfo state;

    // Use this for initialization
    void Start()
    {
        rightNum = 0;

        audioRight = GameObject.Find("Audio/Right").GetComponent<AudioSource>();
        audioWrong = GameObject.Find("Audio/Wrong").GetComponent<AudioSource>();
        audioDestroy = GameObject.Find("Audio/Destroy").GetComponent<AudioSource>();
        audioEnd = GameObject.Find("Audio/End").GetComponent<AudioSource>();

        state = GameObject.Find("State").GetComponent<StateInfo>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Are the rubbish right?
        if (other.tag == tagName)
        {
            // play right audio
            if (!audioRight.isPlaying)
            {
                audioRight.Play();
            }
            // destroy rubbish
            // right num +1
            if (other.gameObject != null)
            {
                Destroy(other.gameObject);
                audioDestroy.Play();
                rightNum++;
            }
            // if all right ,play end audio,show vitory text
            if (rightNum == 24)
            {
                if (!audioEnd.isPlaying)
                {
                    audioEnd.Play();
                }
                state.Vicotory();
            }
            // show right text
            state.Right();
        }
        else
        {
            // let rubbish back its own position
            other.gameObject.GetComponent<RectTransform>().localPosition = other.GetComponent<RubbishDrag>().pos;
            // play wrong audio
            if (!audioWrong.isPlaying)
            {
                audioWrong.Play();
            }
            // show wrong text
            state.Wrong();
        }
    }
}
