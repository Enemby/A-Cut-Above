using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public float intensitySpeed;
    public bool escalate; //increase spawn rate over time?
    public GameObject myEnemy;
    public float spawnRange;
    private GameObject myPlayer;
    private float timer;
    private float intensityTimer;
    public virtual void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Update()
    {
        if (escalate == true)
        {
            if (intensityTimer < 1)
            {
                intensityTimer = intensityTimer + (Time.deltaTime * 0.001f);
            }
            if (intensityTimer > 1)
            {
                intensityTimer = 1;
            }
        }
        else
        {
            intensityTimer = 0;
        }
        if (timer <= spawnTime)
        {
            timer = timer + Time.deltaTime;
            timer = timer + intensityTimer;
        }
        else
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    public virtual void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * this.spawnRange;
        Vector3 spawnPos = new Vector3(randomCircle.x, randomCircle.y, 0);
        GameObject spawnedEnemy = Instantiate(myEnemy, spawnPos, Quaternion.identity);
        if (Vector3.Distance(spawnedEnemy.transform.position, myPlayer.transform.position) < 0.2f)
        {
            Destroy(spawnedEnemy.gameObject);
        }
    }

    public EnemySpawner()
    {
        spawnTime = 1;
        intensitySpeed = 0.1f;
        spawnRange = 10;
    }

}