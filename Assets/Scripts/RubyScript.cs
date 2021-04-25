using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyScript : MonoBehaviour
{
    private float money;
    private float[] upgradeCost = new float[] { 15000, 20000, 25000, 35000, 40000, 45000 };
    private float[] upgradeProfit = new float[] { 200, 400, 800, 1000,1200, 2000 };
    public bool[] upgradeBool = new bool[] { false, false, false, false, false, false };

    public Text upgradeButtonText;
    IEnumerator startDiging;

    public GameControll gameCont;
   public float time = 3;
   public float profit = 100;
    public bool isActiveruby;
    void Start()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        isActiveruby = PlayerPrefsX.GetBool("rubyActiv", false);
        if (PlayerPrefs.HasKey("rubyUpgrade"))
        {
            upgradeBool = PlayerPrefsX.GetBoolArray("rubyUpgrade");
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
        if (isActiveruby)
            StartCoroutine(startDiging);
    }

    IEnumerator StartDiging(float profit, float time)
    {
        while (true)
        {
            Debug.Log("ruby! " + profit);
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

        isActiveruby = PlayerPrefsX.GetBool("rubyActiv", false);
        if(isActiveruby)
        StopCoroutine(startDiging);

        startDiging = StartDiging(profit, time);
        
        if (isActiveruby)
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
               
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
                
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
               
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
               
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
                
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
                PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
                
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

    public void Buyruby()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        if (money >= gameCont.newMineshaftCost[2])
        {
            money -= gameCont.newMineshaftCost[2];
            PlayerPrefs.SetFloat("money", money);
            gameCont.SaveMineshaft(2);

            isActiveruby = true;
            PlayerPrefsX.SetBool("rubyActiv", isActiveruby);  //Save ruby
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
        PlayerPrefsX.SetBoolArray("rubyUpgrade", upgradeBool);
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
