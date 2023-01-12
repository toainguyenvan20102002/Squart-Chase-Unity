using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyGameObject", 0.2f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
