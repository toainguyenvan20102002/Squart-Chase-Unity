using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    bool isProtected;

    public bool IsProtected {set => isProtected = value; }

    private void Start()
    {
        isProtected = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.collider.tag == "Enemy")
            {
                if(!isProtected)
                {
                    GameManager.instance.EndGame();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision)
        {
            if(collision.tag == "Enemy")
            {
                if(!isProtected)
                {
                    GameManager.instance.EndGame();
                }
            }
        }
    }

}
