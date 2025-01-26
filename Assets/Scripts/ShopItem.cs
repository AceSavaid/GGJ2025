using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Shop Item", menuName = "ScriptableObjects/Shop Item", order = 1)]

public class ShopItem : ScriptableObject
{
    public enum ItemTypes
    {
        Creation,
        Upgrade,
        Automation,
        WorldChange,
    };

    public string itemName;
    public string itemDescription;
    public int cost;
    public Sprite image;

    public ItemTypes itemType;

    public int itemUse = 1;
    int useCount = 0;

    [Header("Edit if Creation Upgrade or Automation")]
    
    GameObject upgradable;


    [Header("Edit if World Change")]

    string WorldName;
    GameObject worldspawner;
}
