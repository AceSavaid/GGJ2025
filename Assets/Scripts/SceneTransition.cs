using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int requirement = 100000;
    Currency currency;

    // Start is called before the first frame update
    void Start()
    {
        currency = (Currency)FindObjectOfType<Currency>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Transition()
    {
        if (currency.GetCurrency() >= requirement)
        {
            SceneManager.LoadScene("Hell");
        }
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}
