using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemInstantiation : MonoBehaviour
{



    Currency currency;
    SpawnHolders spawnHolder;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text priceText;
    public Image image;

    public ShopItem item;

    public int price;

    public GameObject clickerPrefab;
    public Transform creationSpawnPoint;

    public int purchaseCount;
    public int maxPurchase;

    // Start is called before the first frame update
    void Awake()
    {
        currency = (Currency)FindObjectOfType<Currency>();
        spawnHolder = FindObjectOfType<SpawnHolders>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInformation(string title, string desc, int cost, Sprite sprite)
    {
        if (title != null)
        {
            titleText.text = title;
        }
        if (desc != null)
        {
            descriptionText.text = desc;

        }
        if (cost != 0)
        {
            price = cost;
            priceText.text ="$" + cost;

        }
        if (sprite != null)
        {
            image.sprite = sprite;
        }

        
    }

    public void Clicked()
    {
        if (currency.GetCurrency() >= price)
        {
            currency.UpdateCurrency(-price);

            switch (item.itemType)
            {
                case ShopItem.ItemTypes.Creation:
                    spawnHolder.ActivateClicker(item.ClickerID);
                    break;

                case ShopItem.ItemTypes.Upgrade:
                    spawnHolder.UpgradeClicker(item.ClickerID);
                    break;

                case ShopItem.ItemTypes.Automation:
                    spawnHolder.AutomateClicker(item.ClickerID);
                    break;

                case ShopItem.ItemTypes.UpgradeAuto:
                    // Placeholder for future implementation
                    spawnHolder.UpgradeAutoClick(item.ClickerID);
                    break;

                default:
                    Debug.LogWarning("Unhandled Shop Item Type");
                    break;
            }
            purchaseCount++;
            if (purchaseCount >= maxPurchase)
            {
                GetComponent<Button>().interactable = false;
            }
            
        }
        else
        {
            Debug.Log("Not enough currency!");
        }
    }

    void CreateClicker()
    {
        if (clickerPrefab == null)
        {
            Debug.LogError("Clicker prefab is not assigned!");
            return;
        }

        Transform spawnPoint = creationSpawnPoint != null ? creationSpawnPoint : transform; // Default spawn point is this object's position
        Instantiate(clickerPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Created a new Clicker object.");
    }

    void UpgradeClicker()
    {
        Clicker clicker = FindObjectOfType<Clicker>();
        if (clicker != null)
        {
            clicker.UpgradeClickMultiplyer(); // Increases click multiplier
            clicker.UpgradeAutoTime(0.2f);   // Reduces autoTime by 20%
            Debug.Log("Upgraded Clicker: Multiplier increased, AutoTime reduced.");
        }
        else
        {
            Debug.LogWarning("No Clicker found to upgrade!");
        }
    }

    void AutomateClicker()
    {
        Clicker clicker = FindObjectOfType<Clicker>();
        if (clicker != null)
        {
            clicker.SetAutoTime(); // Enables automatic clicking
            Debug.Log("Clicker automation enabled.");
        }
        else
        {
            Debug.LogWarning("No Clicker found to automate!");
        }
    }


}
