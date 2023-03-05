using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class juiceScript : MonoBehaviour
{
    //add some "juice" and screenshake to the game
    public float cameraDrift;
    public float screenshake;
    public float returnSpeed;
    //Balancing stuff, TOUCH CAREFULLY
    public float zoomSpeed;
    public float spinSpeed;
    //misc vars
    public bool hit;
    public float shakeTime;
    private float timer;
    private GameObject player;
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        hitCheck();
        transform.position = Vector3.MoveTowards(this.transform.position, Vector3.zero, this.returnSpeed);
        if (this.hit == true)
        {
            this.timer = this.timer + Time.deltaTime;
            this.transform.position = this.transform.position + (Random.insideUnitSphere * this.screenshake);
            if (this.timer >= this.shakeTime)
            {
                this.hit = false;
                this.timer = 0;
            }
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.transform.position, this.cameraDrift);
        this.Zoom();

        {
            int _7 = -10;
            Vector3 _8 = this.transform.position;
            _8.z = _7;
            this.transform.position = _8;
        }
        this.Quit();
    }

    public virtual void Zoom()
    {
        if (GetComponent<Camera>().orthographicSize > 0.8f)
        {
            GetComponent<Camera>().orthographicSize = GetComponent<Camera>().orthographicSize - zoomSpeed;
        }
    }

    public virtual void hitCheck()
    {
        hit = player.GetComponent<Player>().hit;
    }

    public virtual void Quit()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public juiceScript()
    {
        cameraDrift = 0.016f;
        screenshake = 0.005f;
        returnSpeed = 0.015f;
        zoomSpeed = 0.01f;
        spinSpeed = 0.1f;
        shakeTime = 0.2f;
    }

}