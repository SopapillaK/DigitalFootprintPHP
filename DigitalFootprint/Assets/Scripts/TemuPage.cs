using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemuPage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject items1;
    public GameObject items2;
    public GameObject temuPage;
    public GameObject instaPage;
    public GameObject cardPage;
    public bool infoStolen = false;

    public void CardPay()
    {
        temuPage.SetActive(false);
        cardPage.SetActive(true);


        infoStolen = true;
    }

    public void PayPalPay()
    {
        temuPage.SetActive(false);
        items1.SetActive(true);
        items2.SetActive(true);
    }

    public void InstagramPage()
    {
        instaPage.SetActive(true);
    }

    public void ToShopPage()
    {
        cardPage.SetActive(false);
        items1.SetActive(true);
        items2.SetActive(true);

    }
}
