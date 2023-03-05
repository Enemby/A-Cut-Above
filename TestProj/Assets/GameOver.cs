using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class GameOver : MonoBehaviour
{
    public virtual void Start()
    {
        Time.timeScale = 0;
    }

    public virtual void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0))
            {
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

}