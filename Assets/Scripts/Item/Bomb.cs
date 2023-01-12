using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timeExists = 8f;
    float timeRemain = 10f;
    float countDownTime;
    bool isCollected;

    public GameObject explode;


    private void Awake()
    {
        countDownTime = timeExists;
        isCollected = false;
    }
    private void Update()
    {
        countDownTime -= Time.deltaTime;
        if (!isCollected)
        {
            if(countDownTime <=0 )
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Explode();
        }
    }
    void Explode()
    {
        GameObject lastEnemy = EnemyManager.instance.GetLastEnemy();
        if (lastEnemy == null || countDownTime <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        if(Vector2.Distance(transform.position,lastEnemy.transform.position) <= 1f)
        {
            Instantiate(explode,this.transform.position,Quaternion.identity);
            EnemyManager.instance.GenerateGhost(lastEnemy.transform.position);
            AudioManager.instance.Play("Explode");
            Destroy(lastEnemy);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.tag == "Player")
            {
                isCollected = true;
                countDownTime = timeRemain;
            }
        }
    }
}
