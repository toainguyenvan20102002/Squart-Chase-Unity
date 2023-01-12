using System.Collections.Generic;
using UnityEngine;

public class PathCreate : MonoBehaviour
{
    List<Vector2> path = new List<Vector2>();

    [SerializeField] Transform player;

    int capacity = 700;

    public int GetSize()
    {
        return path.Count;
    }

    void AddPointToEndPath(Vector2 position)
    {
        path.Add(position);
        if(path.Count > capacity)
            path.RemoveAt(0);
    }

    private void FixedUpdate()
    {
        AddPointToEndPath(player.position);
    }

    public Vector2 GetPointFromDistance(int distanceIndex)
    {
        int index = path.Count - distanceIndex;
        if (index < 0) index = 0;
        return path[index];
    }
}
