using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public partial class FadeInCanvas : MonoBehaviour
{
    public float fadeSpeed;
    public float delay;
    public Image image;
    public Text text;
    private float timer;
    public void Update()
    {
        if (timer < delay)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (image == true)
            {

                {
                    float _1 = GetComponent<Image>().color.a + fadeSpeed;
                    Image _2 = GetComponent<Image>();
                    Color _3 = _2.color;
                    _3.a = _1;
                    _2.color = _3;
                }
            }
            if (text == true)
            {

                {
                    float _4 = GetComponent<Text>().color.a + fadeSpeed;
                    Text _5 = GetComponent<Text>();
                    Color _6 = _5.color;
                    _6.a = _4;
                    _5.color = _6;
                }
            }
        }
    }
}