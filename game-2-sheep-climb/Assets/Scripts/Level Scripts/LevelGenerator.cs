using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject platformStart;
    [SerializeField]
    private GameObject platformEnd;
    [SerializeField]
    private GameObject platform2;
    [SerializeField]
    private GameObject platform3;
    [SerializeField]
    private GameObject playerPrefab;

    private Vector3 lastPos;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [SerializeField]
    private int amountToSpawn = 100;
    private int beginAmount = 0;

    private float blockWidth = 0.5f;
    private float blockHeight = 0.2f;

    void InstantiateLevel()
    {
        for(int i=beginAmount; i<amountToSpawn; i++)
        {
            GameObject newPlatform;
            if (i == 0)
            {
                newPlatform = Instantiate(platformStart);
            }
            else if (i == amountToSpawn - 1)
            {
                newPlatform = Instantiate(platformEnd);
                newPlatform.tag = "EndPlatform";
            }
            else
            {
                newPlatform = Instantiate(platform3);
            }
            newPlatform.transform.parent = transform;
            spawnedPlatforms.Add(newPlatform);

            if (i == 0)
            {
                lastPos = newPlatform.transform.position;
                // instantiate player
                Vector3 temp = lastPos;
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
                continue;
            }
            int pos = Random.Range(0, 2);
            if (pos == 0)
            {
                newPlatform.transform.position = new Vector3(lastPos.x-blockWidth, lastPos.y+blockHeight, lastPos.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(lastPos.x, lastPos.y+blockHeight, lastPos.z+blockWidth);
            }
            lastPos = newPlatform.transform.position;

            // fancy animation
            if (i < 25)
            {
                float endPos = newPlatform.transform.position.y;
                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y - blockHeight * 3f, newPlatform.transform.position.z);
                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
            }


        } // for loop
    } // Instantiate Level

    // Start is called before the first frame update
    void Awake()
    {
        InstantiateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} // awake
