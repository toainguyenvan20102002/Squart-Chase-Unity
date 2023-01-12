using UnityEngine;

public class GhostFollow : MonoBehaviour
{
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroyGhost", 6.0f);
    }
    void DestroyGhost()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime / 2f);
        Flip();
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        if (player.transform.position.x > transform.position.x)
        {
            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
        else
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
    }
}
