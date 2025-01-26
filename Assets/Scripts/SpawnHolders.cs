using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHolders : MonoBehaviour
{
    public List<Clicker> clickers = new List<Clicker>();
    List<Transform> spawnpoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateClicker(int index)
    {
        clickers[index].gameObject.SetActive(true);


    }

    public void UpgradeClicker(int index)
    {

        clickers[index].UpgradeClickMultiplyer();
        
    }

    public void AutomateClicker(int index)
    {
        clickers[index].SetAutoTime();
    }

    public void UpgradeAutoClick(int index)
    {
        clickers[index].UpgradeAutoTime(0.2f);
    }
}
