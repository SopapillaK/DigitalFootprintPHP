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
    public GameObject paypalPage;
    public bool infoStolen = false;


    public GameObject shoppingCart;

    public void CardPay()
    {
        temuPage.SetActive(false);
        cardPage.SetActive(true);


        infoStolen = true;
    }

    public void PayPalPay()
    {
        temuPage.SetActive(false);
        paypalPage.SetActive(true);

    }

    public void InstagramPage()
    {
        //instaPage.GetComponent<CardInfoDisplay>().SetDisplayInfo();
        instaPage.SetActive(true);
        items1.SetActive(false);
        items2.SetActive(false);

        shoppingCart.SetActive(false);
    }

    public void ToShopPage()
    {
        cardPage.SetActive(false);
        paypalPage.SetActive(false);
        items1.SetActive(true);
        items2.SetActive(true);

    }
}
