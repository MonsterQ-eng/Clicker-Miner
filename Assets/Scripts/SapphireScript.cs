using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SapphireScript : MonoBehaviour
{
    private float money;
    private float[] upgradeCost = new float[] { 50000, 100000, 150000, 200000, 250000, 300000 };
    private float[] upgradeProfit = new float[] { 400 , 800, 1600, 3200, 5000, 10000 };
    public bool[] upgradeBool = new bool[] { false, false, false, false, false, false };

    public Text upgradeButtonText;
    IEnumerator startDiging;

    public GameControll gameCont;
    public float time = 3;
    public float profit = 200;
    public bool isActivesapphire;
    void Start()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        isActivesapphire = PlayerPrefsX.GetBool("sapphireActiv", false);
        if (PlayerPrefs.HasKey("sapphireUpgrade"))
        {
            upgradeBool = PlayerPrefsX.GetBoolArray("sapphireUpgrade");
        }

        for (int i = 0; i < upgradeBool.Length; i++)
        {
            if (upgradeBool[i])
            {
                profit = upgradeProfit[i];

            }
        }

        ChangeButtonText();

        startDiging = StartDiging(profit, time);
        if (isActivesapphire)
            StartCoroutine(startDiging);
    }

    IEnumerator StartDiging(float profit, float time)
    {
        while (true)
        {
            Debug.Log("sapphire! " + profit);
            money = PlayerPrefs.GetFloat("money", 0);
            money += profit;
            PlayerPrefs.SetFloat("money", money);
            gameCont.RoundMoney();
            yield return new WaitForSeconds(time);
        }
    }


    public void ChangeButtonText()
    {
        if (!upgradeBool[0])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[0];
        }
        else if (!upgradeBool[1])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[1];
        }
        else if (!upgradeBool[2])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[2];
        }
        else if (!upgradeBool[3])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[3];
        }
        else if (!upgradeBool[4])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[4];
        }
        else if (!upgradeBool[5])
        {
            upgradeButtonText.text = "BUY: " + upgradeCost[5];
        }
    }


    public void UpdateCoroutine()
    {

        isActivesapphire = PlayerPrefsX.GetBool("sapphireActiv", false);
       
        if(isActivesapphire)
        StopCoroutine(startDiging);

        startDiging = StartDiging(profit, time);
        
        if (isActivesapphire)
            StartCoroutine(startDiging);
    }

    public void UpgradeButton()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (!upgradeBool[0])
        {
            if (money >= upgradeCost[0])
            {
                money -= upgradeCost[0];
                PlayerPrefs.SetFloat("money", money);

                upgradeBool[0] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
                
                //Save upgrade bool
                SavePlayer();
            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }
        else if (!upgradeBool[1])
        {
            if (money >= upgradeCost[1])
            {
                money -= upgradeCost[1];
                PlayerPrefs.SetFloat("money", money);

                upgradeBool[1] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
               
                //Save upgrade bool
                SavePlayer();


            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }
        else if (!upgradeBool[2])
        {
            if (money >= upgradeCost[2])
            {
                money -= upgradeCost[2];
                PlayerPrefs.SetFloat("money", money);

                upgradeBool[2] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
               
                //Save upgrade bool
                SavePlayer();

            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }
        else if (!upgradeBool[3])
        {
            if (money >= upgradeCost[3])
            {
                money -= upgradeCost[3];
                PlayerPrefs.SetFloat("money", money);

                upgradeBool[3] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
               
                //Save upgrade bool
                SavePlayer();

            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }
        else if (!upgradeBool[4])
        {
            if (money >= upgradeCost[4])
            {
                money -= upgradeCost[4];
                PlayerPrefs.SetFloat("money", money);

                upgradeBool[4] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
                
                //Save upgrade bool
                SavePlayer();

            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }
        else if (!upgradeBool[5])
        {
            if (money >= upgradeCost[5])
            {
                money -= upgradeCost[5];
                PlayerPrefs.SetFloat("money", money);
                upgradeBool[5] = true;
                PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
                
                //Save upgrade bool
                SavePlayer();

            }
            else
            {
                gameCont._ShowAndroidToastMessage("No enought money!");

            }
        }

        for (int i = 0; i < upgradeBool.Length; i++)
        {
            if (upgradeBool[i])
            {
                profit = upgradeProfit[i];
            }
        }
        ChangeButtonText();
        UpdateCoroutine();
    }

    public GameObject mineshaft;
    public GameObject button;

    public void Buysapphire()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= gameCont.newMineshaftCost[3])
        {
            money -= gameCont.newMineshaftCost[3];
            PlayerPrefs.SetFloat("money", money);
            gameCont.SaveMineshaft(3);

            isActivesapphire = true;
            PlayerPrefsX.SetBool("sapphireActiv", isActivesapphire);  //Save sapphire
            UpdateCoroutine();
            gameCont.UpdateButtonShow();
            SavePlayer();
            button.SetActive(false);
            mineshaft.SetActive(true);
        }
        else
        {
            gameCont._ShowAndroidToastMessage("No enought money!");

        }
    }

    private void SavePlayer()
    {
        PlayerPrefsX.SetBoolArray("sapphireUpgrade", upgradeBool);
        PlayerPrefs.SetFloat("money", money);
        gameCont.RoundMoney();
    }

    private float moreFromClick;

    public void OneClickMoney()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        moreFromClick = PlayerPrefs.GetFloat("MoreClick", 1);
        money += profit * moreFromClick;
        PlayerPrefs.SetFloat("money", money);
        gameCont.RoundMoney();
    }
}
