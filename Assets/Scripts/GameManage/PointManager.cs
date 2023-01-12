using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    int point = 0;

    int[] checkPoint = new int[] {5,5,10};
    public GameObject smallPointPrefab;
    public GameObject bigPointPrefab;
    [Range(0.1f,0.5f)] public float percentBigPoint = 0.25f;


    [Header("Position Instantiate")]
    public Transform[] pointPositions;

    private GameObject currentPoint;

    public int GetPoint()
    {
        return point;
    }

    private void Awake()
    {  
        point = 0;
    }
    private void Start()
    {
        if(instance == null) instance = this;

        GeneratePoint(pointPositions[0].position);
    }

    public void AddPoint(int add)
    {
        if (add <= 0) return;
        point += add;

        GUIManager.instance.UpdatePoint(point);
    }

    private void CalCheckPoint()
    {
        if(point >= checkPoint[2])
        {
            checkPoint[0] = checkPoint[1];
            checkPoint[1] = checkPoint[2];
            checkPoint[2] = checkPoint[0] + checkPoint[1];

            EnemyManager.instance.GenerateEnemy();
            Debug.Log(point);
        }
    }

    private void Update()
    {
        CalCheckPoint();
    }

    public void GeneratePoint(Vector2 exceptPosition)
    {
        Point.TypePoint typePoint = Random.Range(0, 100) > percentBigPoint * 100 ? Point.TypePoint.SMALLPOINT : Point.TypePoint.BIGPOINT;
        GameObject pointGO;
        Vector2 position = Vector2.zero;
        do
        {
            position = pointPositions[Random.Range(0, pointPositions.Length)].position;
        } while (position == exceptPosition);

        switch (typePoint)
        {
            case Point.TypePoint.SMALLPOINT:
                pointGO = Instantiate(smallPointPrefab, position, Quaternion.identity);
                break;
            case Point.TypePoint.BIGPOINT:
                pointGO = Instantiate(bigPointPrefab, position, Quaternion.identity);
                break;
            default:
                pointGO = Instantiate(smallPointPrefab, position, Quaternion.identity);
                break;
        }
        currentPoint = pointGO;
    }

    public Vector2 GetCurrentPointPosition()
    {
        if (currentPoint == null) return Vector2.zero;
        return currentPoint.transform.position;
    }
}
