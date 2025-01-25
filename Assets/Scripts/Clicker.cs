using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{

    public GameObject clicker;
    public string clickerName;

    int currency = 0;
    public TextMeshProUGUI currencyText;

    Button button;
    public TextMeshProUGUI buttonText;

    Slider slider;

    int level = 0;
    public TextMeshProUGUI levelText;

    public int clickValue = 1;
    float clickMultiplyer = 1.0f;

    //autogen
    bool autogain = false;
    float autoTime = 10;
    float timer = 0;

    //item
    public GameObject itemToSpawn;

    //effects
    public AudioClip clickSound;
    public GameObject clickParticle;


    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = clickerName + ": \n"+ currency.ToString();

        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(Click);
        
        levelText.text = "Multiplier: " + clickMultiplyer + " \tLevel:" + level;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (autogain)
        {
            RunAutoTime();
        }
        UpdateUI();

    }

    void UpdateUI()
    {
        currencyText.text = clickerName + ": " + currency.ToString();
        
    }

    public void Click()
    {
        currency += (int)(clickValue * clickMultiplyer);
        
        if (itemToSpawn)
        {
            SpawnItem();
        }
        PlayEffects();
    }

    public void SpawnItem()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        GameObject spawnedItem = Instantiate(itemToSpawn, screenPosition, Quaternion.identity);
        Destroy(spawnedItem, 10);
        
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
        autoTime -= (autoTime * .1f);
    }

    public void UpgradeClickMultiplyer()
    {
        clickMultiplyer++;
        
    }


    void SetCurrency(int value)
    {
        currency = value;
    }

    public int GetCurrency()
    {
        return currency;
    }
}
