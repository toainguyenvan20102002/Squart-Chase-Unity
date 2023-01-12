using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefabs;
    GameObject player;

    float timeToAttack = 5f;

    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    const float k_GroundedRadius = 0.5f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.

    float countDownTime;
    private void Start()
    {
        countDownTime = timeToAttack;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        countDownTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
    }

    public void Attack()
    {

        if (!m_Grounded || countDownTime > 0) return;
        // Attack
        Vector2 direct = new Vector2( (player.transform.position.x > transform.position.x ? 1 : -1) , 0);
        GameObject bullet = Instantiate(bulletPrefabs, this.transform.position,Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirect(direct);
        AudioManager.instance.Play("Shoot");

        // Set Original CountDownTime
        countDownTime = timeToAttack;
    }
}
