using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public partial class HealthUI : MonoBehaviour
{
    public GameObject myPlayer;
    public Image myFadeElement; //Our blackUI thing.
    public virtual void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        float healthAlpha =  myPlayer.GetComponent<Player>().health * 0.01f;
        healthAlpha = (healthAlpha) - 1;
        healthAlpha = Mathf.Abs(healthAlpha);
        if (healthAlpha > 0.9f)
        {
            healthAlpha = 0.9f;
        }
        myFadeElement.color = new Color(0, 0, 0, healthAlpha);
    }

}