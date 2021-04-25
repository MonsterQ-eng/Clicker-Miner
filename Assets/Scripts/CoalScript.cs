using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoalScript : MonoBehaviour
{

    private float money;
    private float[] upgradeCost = new float[] {100, 500, 1000, 1500, 2000, 2500};
    private float[] upgradeProfit = new float[] { 2, 4, 8, 16, 32, 64 };
    public bool[] upgradeBool = new bool[] { false, false, false, false, false, false };

    public Text upgradeButtonText;
    IEnumerator startDiging;
    public float profit = 1;
    public float time = 3;

    public GameControll gameCont;

    void Start()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (PlayerPrefs.HasKey("coalUpgrade"))
        {
            upgradeBool = PlayerPrefsX.GetBoolArray("coalUpgrade");
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
       
        StartCoroutine(startDiging);
    }

    IEnumerator StartDiging(float profit, float time)
    {
        while (true)
        {
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
        else if(!upgradeBool[1])
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
    

        StopCoroutine(startDiging);

        startDiging = StartDiging(profit, time);
        

        StartCoroutine(startDiging);
    }

    public void UpgradeButton()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (!upgradeBool[0])
        {
            if (money >= upgradeCost[0])
            {
                Debug.Log("COAL UPGRADE " + upgradeCost[0]);
                money -= upgradeCost[0];
                PlayerPrefs.SetFloat("money", money);
                upgradeBool[0] = true;
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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
                Debug.Log("COAL UPGRADE " + upgradeCost[1]);
                money -= upgradeCost[1];
                PlayerPrefs.SetFloat("money", money);
                upgradeBool[1] = true;
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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
                PlayerPrefsX.SetBoolArray("coalUpgrade", upgradeBool);
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

    private void SavePlayer()
    {

        gameCont.RoundMoney();
    }

    private float moreFromClick;

    public void OneClickDig()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        moreFromClick = PlayerPrefs.GetFloat("MoreClick", 1);
        money += profit * moreFromClick;
        PlayerPrefs.SetFloat("money", money);
        gameCont.RoundMoney();
    }


}
