using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{

    public string clickerName;
    Currency currency;

    Button button;

    Slider slider;

    int level = 0;
    public TextMeshProUGUI levelText;

    public int clickValue = 1;
    float clickMultiplyer = 1.0f;

    //autogen
    public bool autogain = false;
    public float autoTime = 10;
    float timer = 0;

    //item
    public GameObject itemToSpawn;

    //effects
    public AudioClip clickSound;
    public GameObject clickParticle;


    // Start is called before the first frame update
    void Awake()
    {
        currency= (Currency)FindObjectOfType<Currency>().GetComponent<Currency>();
        
        //levelText.text = "Multiplier: " + clickMultiplyer + " \tLevel:" + level;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (autogain)
        {
            RunAutoTime();
        }

    }

    

    public void Click()
    {
        currency.UpdateCurrency((int)(clickValue * clickMultiplyer));
        
        if (itemToSpawn)
        {
            SpawnItem();
        }
        PlayEffects();

    }

    public void SpawnItem()
    {
        if (itemToSpawn != null)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(50, Screen.width-800), Random.Range(50, Screen.height-200), Camera.main.farClipPlane / 2));
            GameObject spawnedItem = Instantiate(itemToSpawn, screenPosition, Quaternion.identity);
            Destroy(spawnedItem, 10);
        }
    }

    void PlayEffects()
    {
        if (clickSound)
        {
            AudioSource.PlayClipAtPoint(clickSound, new Vector3(0,0,0));
        }

        if (clickParticle)
        {
            GameObject particles = Instantiate(clickParticle);
            Destroy(particles, 3);
        }
    }

    public void SetAutoTime()
    {
        autogain = true;
        GetComponent<Button>().interactable = false;
    }

    public void RunAutoTime()
    {
        timer += Time.deltaTime;
        if (timer >= autoTime)
        {
            timer = 0;
            Click();
        }
    }
    
    public void UpgradeAutoTime(float value)
    {
        level++;
        autoTime = Mathf.Max(0.1f, autoTime - (autoTime * value));
    }

    public void UpgradeClickMultiplyer()
    {
        clickMultiplyer++;
        
    }

}
