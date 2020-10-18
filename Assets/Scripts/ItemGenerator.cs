using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public ObjectPooler itemPool;

    public float distBetweenItems;

    public void SpawnItems(Vector3 startPosition)
    {
        GameObject item1 = itemPool.GetPooledObject();
        item1.transform.position = startPosition;
        item1.SetActive(true);

        GameObject item2 = itemPool.GetPooledObject();
        item2.transform.position = new Vector3(startPosition.x - distBetweenItems, startPosition.y, startPosition.z);
        item2.SetActive(true);

        GameObject item3 = itemPool.GetPooledObject();
        item3.transform.position = new Vector3(startPosition.x + distBetweenItems, startPosition.y, startPosition.z);
        item3.SetActive(true);
    }


}
