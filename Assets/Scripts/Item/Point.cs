using UnityEngine;

public class Point : MonoBehaviour
{
    public TypePoint typePoint;

    private int GetPoint()
    {
        return (int) typePoint;
    }

    public enum TypePoint
    {
        SMALLPOINT = 5,
        BIGPOINT = 10
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.tag == "Player")
            {
                PointManager.instance.AddPoint(GetPoint());
                AudioManager.instance.Play("Point");
                PointManager.instance.GeneratePoint(this.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
