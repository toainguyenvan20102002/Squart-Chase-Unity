using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] listPrefabs;
    public Transform[] listPositionItem;

    float timeSpawnItem = 15f;

    float countDownTime;

    private void Start()
    {
        countDownTime = timeSpawnItem;
    }

    void GenerateItem()
    {
        int indexItem = Random.Range(0, listPrefabs.Length);
        int indexPosition = Random.Range(0, listPositionItem.Length);

        Instantiate(listPrefabs[indexItem],listPositionItem[indexPosition].position,Quaternion.identity);

    }

    private void Update()
    {
        countDownTime-=Time.deltaTime;
        if(countDownTime < 0)
        {
            GenerateItem();
            countDownTime = timeSpawnItem;
        }
    }
}
