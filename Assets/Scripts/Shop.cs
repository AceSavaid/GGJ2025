using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ShopItem> items = new List<ShopItem>();
    List<ShopItem> boughtItes = new List<ShopItem>();

    Currency currency;

    public GameObject itemObject;
    public Transform shopSpawn;

    void Start()
    {

        UpdateShop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateShop()
    {
        
        foreach (ShopItem item in items)
        {
            GameObject newItem = Instantiate(itemObject, shopSpawn);
            var shopItemScript = newItem.GetComponent<ShopItemInstantiation>();
            if (shopItemScript != null)
            {
                shopItemScript.UpdateInformation(item.itemName, item.itemDescription, item.cost, item.image);
                shopItemScript.item = item;
                shopItemScript.maxPurchase = item.itemUse;
            }

        }

    }
}
