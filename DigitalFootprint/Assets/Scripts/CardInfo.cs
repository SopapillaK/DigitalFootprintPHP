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

    void Start()
    {
        //cardNumSave = cardNumber.text;
        //expDateSave = expDate.text;
        //cvvSave = cvv.text;
        //postalCodeSave = postalCode.text;
        

        cardNumber.text = PlayerPrefs.GetString("CardNumber", cardNumSave);
        expDate.text = PlayerPrefs.GetString("ExpDate", expDateSave);
        cvv.text = PlayerPrefs.GetString("CVV", cvvSave);
        postalCode.text = PlayerPrefs.GetString("PostalCode", postalCodeSave);

        
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
        Debug.Log("Card Number: " + cardNumber.text);
    }
}
