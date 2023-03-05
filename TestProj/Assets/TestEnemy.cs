using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TestEnemy : MonoBehaviour
{
    public Color startColor;
    public Color hitColor;
    public SpriteRenderer myRenderer;
    public float timer;
    public bool hit;
    public GameObject player;
    public float enemySpeed;
    public float lungeDistance;
    public float animateTimer;
    public Sprite[] sprites;
    public float animateDelay;
    public int mySprite;
    public bool lunging;
    public int health;
    public virtual void Start()
    {
        this.myRenderer = this.GetComponent<SpriteRenderer>();
        this.startColor = this.myRenderer.color;
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        this.animateSprites();
        if (this.hit == true)
        {
            this.timer = this.timer + (Time.deltaTime * 4);
            if (this.timer >= 1)
            {
                this.timer = 0;
                this.hit = false;
            }
            this.myRenderer.color = Color.Lerp(this.myRenderer.color, this.hitColor, this.timer);
        }
        else
        {
            this.myRenderer.color = this.startColor;
        }
        if (Vector3.Distance(this.transform.position, this.player.transform.position) <= this.lungeDistance)
        {
            this.lunging = true;
            this.transform.up = this.player.transform.position - this.transform.position;
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.transform.position, this.enemySpeed * 4);
        }
        else
        {
            this.lunging = false;
            this.transform.up = this.player.transform.position - this.transform.position;
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.transform.position, this.enemySpeed);
        }
    }

    public virtual void animateSprites()
    {
        this.animateTimer = this.animateTimer + Time.deltaTime;
        if (this.lunging == false)
        {
            if (this.animateTimer >= this.animateDelay)
            {
                if ((this.mySprite + 1) < this.sprites.Length)
                {
                    this.mySprite = this.mySprite + 1;
                }
                else
                {
                    this.mySprite = 0;
                }
                this.GetComponent<SpriteRenderer>().sprite = this.sprites[this.mySprite];
                this.animateTimer = 0;
            }
        }
        else
        {
            if (this.animateTimer >= (this.animateDelay * 0.5f))
            {
                if ((this.mySprite + 1) < this.sprites.Length)
                {
                    this.mySprite = this.mySprite + 1;
                }
                else
                {
                    this.mySprite = 0;
                }
                this.GetComponent<SpriteRenderer>().sprite = this.sprites[this.mySprite];
                this.animateTimer = 0;
            }
        }
    }

    public virtual void Hit()
    {
        this.hit = true;
        this.health = this.health - 1;
        if (this.health <= 0)
        {
            this.player.BroadcastMessage("EnemyKilled");
            UnityEngine.Object.Destroy(this.gameObject);
        }
    }

    public TestEnemy()
    {
        this.enemySpeed = 0.1f;
        this.lungeDistance = 2;
        this.animateDelay = 0.1f;
        this.health = 2;
    }

}