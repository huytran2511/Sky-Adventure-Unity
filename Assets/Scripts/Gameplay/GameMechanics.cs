using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    public static GameMechanics instance;

    [SerializeField]
    private GameObject platform;
    private float PLATFORM_DISTANCE = 6.5f;
    private int platformCount;
    private float lastPlatformPositionY;

    void Awake()
    {
        SingletonInit();
        CreatePlatform();
    }

    void Update()
    {
        
    }

    void OnDisable()
    {
        instance = null;
    }

    private void SingletonInit()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CreatePlatform()
    {
        lastPlatformPositionY += PLATFORM_DISTANCE;

        GameObject newPlatform = Instantiate(platform);
        newPlatform.transform.position = new Vector3(0, lastPlatformPositionY, 0);
        newPlatform.name = "Platform" + platformCount;

        platformCount++;
    }
}
