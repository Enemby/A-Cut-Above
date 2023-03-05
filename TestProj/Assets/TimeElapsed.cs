using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[System.Serializable]
public partial class TimeElapsed : MonoBehaviour
{
    private Text myText;
    public virtual void Start()
    {
        myText = GetComponent<Text>();
    }

    public virtual void Update()
    {
        if (Time.timeScale != 0)
        {
            int myTime = (int) Time.timeSinceLevelLoad;
            this.myText.text = "Time Elapsed: " + myTime;
        }
    }

}