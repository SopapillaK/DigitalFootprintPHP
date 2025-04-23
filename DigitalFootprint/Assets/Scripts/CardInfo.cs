using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public InputField cardNumber;
    public static string cardNumSave;

    public InputField expDate;
    public static string expDateSave;

    public InputField cvv;
    public static string cvvSave;

    public InputField postalCode;
    public static string postalCodeSave;

    public Text displayCardNum;
    public Text displayExpDate;
    public Text displayCVV;
    public Text displayPostalCode;

    public AudioClip postSound;
    public GameObject stolenInfoPage;
    public bool isPrivate = false;
    public bool pic1 = false;
    public bool pic2 = false;
    public bool pic3 = false;
    public GameObject Pic1;
    public GameObject Pic2;
    public GameObject Pic3;

    public GameObject instaPage;

    void Start()
    {
        cardNumSave = null;
        expDateSave = null;
        cvvSave = null;
        postalCodeSave = null;
        

        cardNumber.text = PlayerPrefs.GetString("CardNumber", cardNumSave);
        expDate.text = PlayerPrefs.GetString("ExpDate", expDateSave);
        cvv.text = PlayerPrefs.GetString("CVV", cvvSave);
        postalCode.text = PlayerPrefs.GetString("PostalCode", postalCodeSave);

        
    }

    public void PostInstaPic1()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(postSound);

        pic1 = true;
        Invoke("Stolen", 2f);
    }

    public void PostInstaPic2()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(postSound);

        pic2 = true;
        Invoke("Stolen", 2f);
    }

    public void PostInstaPic3()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(postSound);

        pic3 = true;
        Invoke("Stolen", 2f);
    }

    public void Stolen()
    {
        instaPage.SetActive(false);
        stolenInfoPage.SetActive(true);

        if (pic1 == true)
        {
            Pic1.SetActive(true);
        }
        if (pic2 == true)
        {
            Pic2.SetActive(true);
        }
        if (pic3 == true)
        {
            Pic3.SetActive(true);
        }
    }

    public void IsPrivate()
    {
        isPrivate = true;
    }

    // Call this to save:
    public void SaveCardInfo()
    {
        PlayerPrefs.SetString("CardNumber", cardNumber.text);
        PlayerPrefs.SetString("ExpDate", expDate.text);
        PlayerPrefs.SetString("CVV", cvv.text);
        PlayerPrefs.SetString("PostalCode", postalCode.text);

        PlayerPrefs.Save();

        displayCardNum.text = "Card Number: " + cardNumber.text;
        displayExpDate.text = "Expiration Date: " + expDate.text;
        displayCVV.text = "CVV: " + cvv.text;
        displayPostalCode.text = "Postal Code: " + postalCode.text;
        Debug.Log("Card info saved!");
        //Debug.Log("Card Number: " + cardNumber.text);
    }
}
