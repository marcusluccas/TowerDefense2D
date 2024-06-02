using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointManager : MonoBehaviour
{
    public static MapPointManager instance { get; private set; }

    public List<Transform> mapPoints;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
