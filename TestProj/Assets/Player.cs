using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Player : MonoBehaviour
{
    public float speed;
    public bool moving;
    public bool hit;
    public GameObject gameOverObj;
    private Color startColor;
    private SpriteRenderer myRenderer;
    private float timer;
    private float slashTimer;
    private bool hitEnemy;
    public float rushTime; //How fast we accelerate while dashing
    public float health;
    public Color hitColor;
    public virtual void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        startColor = myRenderer.color;
    }

    public virtual void EnemyKilled() //If we killed a guy, do stuff.
    {
        if (health < 100)
        {
            health = health + 5;
        }
        if (health > 100)
        {
            health = 100;
        }
    }

    public virtual void Update()
    {
        Camera myCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 mousePos = Input.mousePosition;
        Vector3 myVector = myCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        if (Input.GetButtonDown("Fire1"))
        {
            moving = true;
            slashTimer = this.speed;
        }
        /*
		var myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		myCube.transform.position = myVector;
		myCube.transform.localScale *=0.1;
	*/
        if (moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, myVector, slashTimer);
            slashTimer = slashTimer + (Time.deltaTime * rushTime);
            if (Vector3.Distance(transform.position, myVector) <= 0.025f)
            {
                moving = false;
            }
            if (hitEnemy == true)
            {
                GetComponent<TrailRenderer>().enabled = true;
                GetComponent<ParticleSystem>().enableEmission = true;
            }
            else
            {
                GetComponent<TrailRenderer>().enabled = false;
                GetComponent<ParticleSystem>().enableEmission = false;
            }
        }
        else
        {
            this.hitEnemy = false;
        }
        this.transform.up = myVector - this.transform.position;

        {
            int _9 = 0;
            Quaternion _10 = this.transform.rotation;
            Vector3 _11 = _10.eulerAngles;
            _11.x = _9;
            _10.eulerAngles = _11;
            this.transform.rotation = _10;
        }
        hitLogic();
    }

    public virtual void Hit()
    {
        hit = true;
        health = health - 1;
    }

    public virtual void hitLogic()
    {
        if (hit == true)
        {
            timer = timer + (Time.deltaTime * 4);
            if (timer >= 1)
            {
                timer = 0;
                hit = false;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                    gameOverObj.active = true;
                }
            }
            myRenderer.color = Color.Lerp(myRenderer.color, hitColor, timer);
        }
        else
        {
            myRenderer.color = startColor;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (moving == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                hitEnemy = true;
                other.gameObject.BroadcastMessage("Hit");
                Debug.Log("Enemy Hit");
            }
        }
        else
        {
            if (other.gameObject.tag == "Enemy")
            {
                Hit();
            }
        }
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (moving == false)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Hit();
            }
        }
    }

    public void player()
    { //Unncessary constructor
        speed = 0.1f;
        slashTimer = 0.1f;
        rushTime = 1.1f;
        health = 3;
    }

}