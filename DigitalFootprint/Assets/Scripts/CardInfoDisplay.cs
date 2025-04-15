using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoDisplay : MonoBehaviour
{
    public Text displayCardNum;
    public Text displayExpDate;
    public Text displayCVV;
    public Text displayPostalCode;

    public void SetDisplayInfo()
    {
        displayCardNum.text = "Card Number: " + CardInfo.cardNumSave;
        displayExpDate.text = "Expiration Date: " + CardInfo.expDateSave;
        displayCVV.text = "CVV: " + CardInfo.cvvSave;
        displayPostalCode.text = "Postal Code: " + CardInfo.postalCodeSave;
    }
}
