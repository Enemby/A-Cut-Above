using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Titlescreen : MonoBehaviour
{
    public float delay;
    public int levelIndex;
    private float timer;
    public virtual void Update()
    {
        if (this.timer < this.delay)
        {
            this.timer = this.timer + Time.deltaTime;
        }
        else
        {
            if (Input.anyKeyDown)
            {
                Application.LoadLevel(this.levelIndex);
            }
        }
    }

    public Titlescreen()
    {
        this.levelIndex = 1;
    }

}