using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject aPlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public ObjectPooler objectPool;

    private ItemGenerator itemGenerator;
    public float randomItemThreshhold;

    // Start is called before the first frame update
    void Start()
    {
        itemGenerator = FindObjectOfType<ItemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(aPlatform, transform.position, transform.rotation);
            GameObject newPlatform = objectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            if(Random.Range (0f, 100f) < randomItemThreshhold)
            {
                itemGenerator.SpawnItems(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            
            
        }
    }
}
