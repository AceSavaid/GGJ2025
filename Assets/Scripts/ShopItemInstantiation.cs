using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemInstantiation : MonoBehaviour
{



    Currency currency;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text priceText;
    public Image image;

    public int price;

    public ShopItem item; 

    
    // Start is called before the first frame update
    void Awake()
    {
        currency = (Currency)FindObjectOfType<Currency>();
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
        if(currency.GetCurrency() >= price)
        {
            currency.UpdateCurrency(-price);

            switch (item.itemType)
            {
                case ShopItem.ItemTypes.Creation: //creation

                    break;
                case ShopItem.ItemTypes.Upgrade: // upgrade

                    break;
                case ShopItem.ItemTypes.Automation: //automation

                    break;
                case ShopItem.ItemTypes.WorldChange://world change

                    break;

                default:
                    break;
            }

        }
    }

}
