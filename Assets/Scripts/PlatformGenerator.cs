using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject aPlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler objectPool;

    private ItemGenerator itemGenerator;
    public float randomItemThreshhold;

    public float randomDangerThreshold;
    public ObjectPooler dangerPool;

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

            platformSelector = Random.Range(0, thePlatforms.Length);

            if(Random.Range (0f, 100f) < randomItemThreshhold)
            {
                itemGenerator.SpawnItems(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomDangerThreshold)
            {
                GameObject newDanger = dangerPool.GetPooledObject();

                //float dangerXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);


                Vector3 dangerPosition = new Vector3(5f, 2f, 0);

                newDanger.transform.position = transform.position + dangerPosition;
                newDanger.transform.rotation = transform.rotation;
                newDanger.SetActive(true);
            }



        }
    }
}
