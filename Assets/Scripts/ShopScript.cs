using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{

    public GameControll gameCont;
    private float money;
    public Text moneyText;

    


    //2 X FASTER MINING FOR 10 SEC
    private int howMany2xFasterTimesClicked;
    private float priceUpgrade2xFaster;
    public Text buttonText2xFaster;

    //3 X FASTER MINING FOR 10 SEC
    private int howMany3xFasterTimesClicked;
    private float priceUpgrade3xFaster;
    public Text buttonText3xFaster;

    //2 X MORE COINS
    private int howMany2xCoinsTimesClicked;
    private float priceUpgrade2xCoins;
    public Text buttonText2xCoins;

    //3 X MORE COINS
    private int howMany3xCoinsTimesClicked;
    private float priceUpgrade3xCoins;
    public Text buttonText3xCoins;


    private float smallerPayments;

    private void Start()
    {

        UpdateCost2xFaster();
        UpdateCost3xFaster();
        UpdateCost2xCoins();
        UpdateCost3xCoins();

        
    }

    private void Update()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        moneyText.text = money.ToString();
    }

    // 2 X FASTER MINING FOR 10 SEC
    public void UpdateCost2xFaster()
    {
        howMany2xFasterTimesClicked = PlayerPrefs.GetInt("howMany2xFaster", 0);
        smallerPayments = PlayerPrefs.GetFloat("smallerPay", 1);
        if (howMany2xFasterTimesClicked == 0)
        {
            priceUpgrade2xFaster = 500;
        }
        else
        {
            priceUpgrade2xFaster = (500 * howMany2xFasterTimesClicked)/smallerPayments;
        }
        buttonText2xFaster.text = "Buy: " + priceUpgrade2xFaster;
    }
    public void x2FasterMining()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if(money >= priceUpgrade2xFaster)
        {
            money -= priceUpgrade2xFaster;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            howMany2xFasterTimesClicked++;
            PlayerPrefs.SetInt("howMany2xFaster", howMany2xFasterTimesClicked);
            UpdateCost2xFaster();
            gameCont.FasterMining(2);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }


    //3 X FASTER MINING FOR 10 SEC
    public void UpdateCost3xFaster()
    {
        howMany3xFasterTimesClicked = PlayerPrefs.GetInt("howMany3xFaster", 0);
        smallerPayments = PlayerPrefs.GetFloat("smallerPay", 1);

        if (howMany3xFasterTimesClicked == 0)
        {
            priceUpgrade3xFaster = 1000;
        }
        else
        {
            priceUpgrade3xFaster = (500 * howMany3xFasterTimesClicked)/smallerPayments;
        }
        buttonText3xFaster.text = "Buy: " + priceUpgrade3xFaster;
    }
    public void x3FasterMining()
    {
        money = PlayerPrefs.GetFloat("money", 0);

        if (money >= priceUpgrade3xFaster)
        {
            money -= priceUpgrade3xFaster;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            howMany3xFasterTimesClicked++;
            PlayerPrefs.SetInt("howMany3xFaster", howMany3xFasterTimesClicked);
            UpdateCost3xFaster();
            gameCont.FasterMining(3);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    //2 X MORE COINS FOR 10 SEC
    public void UpdateCost2xCoins()
    {
        howMany2xCoinsTimesClicked = PlayerPrefs.GetInt("howMany2xCoins", 0);
        smallerPayments = PlayerPrefs.GetFloat("smallerPay", 1);

        if (howMany2xCoinsTimesClicked == 0)
        {
            priceUpgrade2xCoins = 500;
        }
        else
        {
            priceUpgrade2xCoins = (500 * howMany2xCoinsTimesClicked)/smallerPayments;
        }
        buttonText2xCoins.text = "Buy: " + priceUpgrade2xCoins;
    }

    public void x2MoreCoins()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= priceUpgrade2xCoins)
        {
            money -= priceUpgrade2xCoins;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            howMany2xCoinsTimesClicked++;
            PlayerPrefs.SetInt("howMany2xCoins", howMany2xCoinsTimesClicked);
            UpdateCost2xCoins();
            gameCont.CoinsMining(2);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }

    //3 X MORE COINS FOR 10 SEC
    public void UpdateCost3xCoins()
    {
        howMany3xCoinsTimesClicked = PlayerPrefs.GetInt("howMany3xCoins", 0);
        smallerPayments = PlayerPrefs.GetFloat("smallerPay", 1);

        if (howMany3xCoinsTimesClicked == 0)
        {
            priceUpgrade3xCoins = 1000;
        }
        else
        {
            priceUpgrade3xCoins = (500 * howMany3xCoinsTimesClicked)/smallerPayments;
        }
        buttonText3xCoins.text = "Buy: " + priceUpgrade3xCoins;
    }
    public void x3CoinsMining()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= priceUpgrade3xCoins)
        {
            money -= priceUpgrade3xCoins;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            howMany3xCoinsTimesClicked++;
            PlayerPrefs.SetInt("howMany3xCoins", howMany3xCoinsTimesClicked);
            UpdateCost3xCoins();
            gameCont.CoinsMining(3);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("Not enought money!");
        }
    }
}
