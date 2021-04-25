using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabScript : MonoBehaviour
{

    public Button clickMoreI;
    public Button clickMoreII;

    public Text clickMoreIText;
    public Text clickMoreIIText;

    public Button smallerPaymentsI;
    public Button smallerPaymentsII;

    public Text smallerPaymentsTextI;
    public Text smallerPaymentsTextII;

    private float moreClick;
    private float smallerPayments;

    public ShopScript shopScript;

    public Text moneyText;
    private float money;

    public GameControll gameCont;

    private void Start()
    {
        moreClick = PlayerPrefs.GetFloat("MoreClick", 1);
        if(moreClick != 1)
        {
            if(moreClick >= 4)
            {
                clickMoreI.interactable = false;
                clickMoreII.interactable = true;
            }
            if(moreClick >= 9)
            {
                clickMoreII.interactable = false;
            }
        }
        else
        {
            clickMoreII.interactable = false;
        }
        clickMoreIText.text = "Buy: " + 20000;
        clickMoreIIText.text = "Buy: " + 100000;
        smallerPayments = PlayerPrefs.GetFloat("smallerPay", 1);

        if (smallerPayments != 1)
        {

            if (moreClick >= 4)
            {
                smallerPaymentsI.interactable = false;
                smallerPaymentsII.interactable = true;
            }
            if (moreClick >= 9)
            {
                smallerPaymentsII.interactable = false;
            }
        }
        else
        {
            smallerPaymentsII.interactable = false;
        }

        smallerPaymentsTextI.text = "Buy: " + 50000;
        smallerPaymentsTextII.text = "Buy: " + 500000;




    }

    private void Update()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        moneyText.text = money.ToString();
    }

    public void ClickMoreMoneyI()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= 20000)
        {
            money -= 20000;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            clickMoreI.interactable = false;
            moreClick = 5;
            PlayerPrefs.SetFloat("MoreClick", moreClick);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    public void SmallerPaymentsI()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= 50000)
        {
            money -= 50000;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            smallerPaymentsI.interactable = false;
            smallerPayments = 5;
            PlayerPrefs.SetFloat("smallerPay", smallerPayments);
            UpdateShop();
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    public void ClickMoreMoneyII()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= 100000)
        {
            money -= 100000;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            clickMoreII.interactable = false;
        moreClick = 10;
        PlayerPrefs.SetFloat("MoreClick", moreClick);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    public void SmallerPaymentsII()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= 500000)
        {
            money -= 500000;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            smallerPaymentsII.interactable = false;
        smallerPayments = 10;
        PlayerPrefs.SetFloat("smallerPay", smallerPayments);
        UpdateShop();
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    private void UpdateShop()
    {
        shopScript.UpdateCost2xCoins();
        shopScript.UpdateCost2xFaster();
        shopScript.UpdateCost3xCoins();
        shopScript.UpdateCost3xFaster();
    }


}
