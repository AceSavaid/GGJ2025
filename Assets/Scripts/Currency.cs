using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{

    int currency = 0;
    public TMP_Text currencyText;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = "$" + currency;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrency(int amount)
    {
        currency = amount;
        UpdateUI();
    }

    public int GetCurrency()
    {

        return currency;
    }

    public void UpdateCurrency(int amount)
    {
        currency += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        currencyText.text = "$ " + currency.ToString();

    }


}
