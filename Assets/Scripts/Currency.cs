using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyScript : MonoBehaviour
{
    Clicker clicker;

    int currency;

    // Start is called before the first frame update
    void Start()
    {
        clicker = GetComponent<Clicker>();
        currency = clicker.GetCurrency();

    }

    // Update is called once per frame
    void Update()
    {
        currency = clicker.GetCurrency();

    }

    public void SetCurrency(int amount)
    {
        currency = amount;
    }

    public int GetCurrency()
    {

        return currency;
    }

    public void UpdateCurrency(int amount)
    {
        currency += amount;
    }


}
