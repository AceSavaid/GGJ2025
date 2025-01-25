using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyScript : MonoBehaviour
{
    Clicker Clicker;

    int currency;

    // Start is called before the first frame update
    void Start()
    {
        currency = Clicker.GetCurrency();

    }

    // Update is called once per frame
    void Update()
    {
        currency = Clicker.GetCurrency();



    }

    public void SetCurrency(int currency)
    {
        currency = currency;
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
