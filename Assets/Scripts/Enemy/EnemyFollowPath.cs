using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public PathCreate pathCreate;
    public GameObject player;
    

    int distanceIndex = 10;


    public int DistanceIndex 
    {
        get => distanceIndex; 
        set => distanceIndex = value;
    }

    private void Awake()
    {
        pathCreate = GameObject.FindGameObjectWithTag("Path").GetComponent<PathCreate>();
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void FixedUpdate()
    {
        Follow();
    }
    private void Update()
    {
        Flip();
    }

    private void Follow()
    {
        Vector2 targetPosition = pathCreate.GetPointFromDistance(distanceIndex);
        transform.position = targetPosition;
    }

    private void OnDestroy()
    {
        EnemyManager.instance.RemoveEnemy(this);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        if(player.transform.position.x > transform.position.x)
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
