using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance { get; private set; }

    public GameObject buildingPanel;
    public GameObject buildingUI;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
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

    public void OpenBuildingPanel()
    {
        buildingPanel.SetActive(true);
    }

    public void CloseBuildingPanel()
    {
        buildingPanel.SetActive(false);
    }

    public void SelectTower(GameObject tower)
    {
        buildingUI.SetActive(false);
        GameObject selectedTower = Instantiate(tower, new Vector3(0, 0, 0), Quaternion.identity);
        selectedTower.GetComponent<Tower>().isBuilding = true;
    }
}
