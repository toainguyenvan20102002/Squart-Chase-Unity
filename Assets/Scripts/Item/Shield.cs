using UnityEngine;

public class Shield : MonoBehaviour
{
    float timeExists = 8f;
    float timeProtect = 4f;

    float countDownTime;
    bool isCollected;
    GameObject player;

    private void Awake()
    {
        countDownTime = timeExists;
        isCollected = false;
    }

    private void Update()
    {
        countDownTime -= Time.deltaTime;
        if(!isCollected)
        {
            if (countDownTime <= 0)
                Destroy(gameObject);
        }   
        else
        {
            Protect();
            if(countDownTime <= 0)
            {
                player.GetComponent<PlayerHealth>().IsProtected = false;
                Destroy(gameObject);
            }
        }
    }

    void Protect()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.CompareTag("Enemy") && isCollected)
            {
                player.GetComponent<PlayerHealth>().IsProtected = false;
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            if (collision.CompareTag("Player") && !isCollected)
            {
                isCollected = true;
                player = collision.gameObject;
                player.GetComponent<PlayerHealth>().IsProtected = true;
                countDownTime = timeProtect;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision)
    //    {
    //        if (collision.CompareTag("Enemy") && isCollected)
    //        {
    //            player.GetComponent<PlayerHealth>().IsProtected = false;
    //            Destroy(gameObject);
    //            return;
    //        }
    //        if (collision.CompareTag("Player") && !isCollected)
    //        {
    //            isCollected = true;
    //            player = collision.gameObject;
    //            player.GetComponent<PlayerHealth>().IsProtected = true;
    //            countDownTime = timeProtect;
    //        }
    //    }
    //}
}
