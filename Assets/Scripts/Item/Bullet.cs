using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speedBullet = 15f;
    Vector2 direct = Vector2.zero;

    public void SetDirect(Vector2 direct)
    {
        this.direct = direct;
        SetSprite();
    }

    void Fly()
    {
        transform.Translate(direct * speedBullet * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Fly();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(this.gameObject);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy")
             Destroy(this.gameObject);
    }

    void SetSprite()
    {        
        if (direct.x == -1)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
