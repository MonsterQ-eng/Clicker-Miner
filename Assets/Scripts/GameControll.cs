using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{

    public Text moneyText;
    private float money;

    public static GameControll gameCont;

    public bool[] mineshaft = new bool[] { false, false, false, false, false, false, false };
    public float[] newMineshaftCost = new float[] {1000, 5000, 10000, 100000, 500000, 750000, 1000000};

    public GameObject[] allMineshaft;

    public Button[] newMineshaftButton; 
    public Text[] newMineshaftButtonText;
    public CoalScript coal;
    public IronScript iron;
    public GoldScript gold;
    public RubyScript ruby;
    public SapphireScript sapphire;
    public DiamonScript diamond;
    public EmeralScript emera;
    public UranScript uran;

    public Animator[] pickaxe;
    public ParticleSystem[] particle;
    private bool shopUpgradeActive = false;

    public GameObject upgradePanel;
    public Text upgradeText;
    private float timeStart = 30;
    private float timeTemp = 30;

    void Start()
    {
        gameCont = this;
        money = PlayerPrefs.GetFloat("money", 0);
        moneyText.text = money.ToString();
        if (PlayerPrefs.HasKey("mineshaft"))
        {
            mineshaft = PlayerPrefsX.GetBoolArray("mineshaft");
        }
        UpdateButtonShow();
        ShowAllMineshaft();
        timeTemp = timeStart;

    }

    private void Update()
    {
        if (shopUpgradeActive)
        {
            if(timeTemp <= 0)
            {
                upgradeText.text = "0";
                timeTemp = timeStart;
                upgradePanel.SetActive(false);
            }
            else
            {
                upgradePanel.SetActive(true);
                timeTemp -= 1 * Time.deltaTime;
                upgradeText.text = timeTemp.ToString("00");
            }
        }
    }

    public void SaveMineshaft(int i)
    {
        mineshaft[i] = true;
        PlayerPrefsX.SetBoolArray("mineshaft", mineshaft);
    }
    
    public void RoundMoney()
    {
        money = PlayerPrefs.GetFloat("money", 0);
        moneyText.text = money.ToString();
    }


    public void UpdateButtonShow()
    {
        if (!mineshaft[0])
        {
            newMineshaftButton[0].gameObject.SetActive(true);
            newMineshaftButtonText[0].text = "New mineshaft ?\n" + newMineshaftCost[0];

        }
        else if (!mineshaft[1])
        {
            newMineshaftButton[1].gameObject.SetActive(true);
            newMineshaftButtonText[1].text = "New mineshaft ?\n" + newMineshaftCost[1];
        }
        else if (!mineshaft[2])
        {
            newMineshaftButton[2].gameObject.SetActive(true);
            newMineshaftButtonText[2].text = "New mineshaft ?\n" + newMineshaftCost[2];
        }
        else if (!mineshaft[3])
        {
            newMineshaftButton[3].gameObject.SetActive(true);
            newMineshaftButtonText[3].text = "New mineshaft ?\n" + newMineshaftCost[3];
        }
        else if (!mineshaft[4])
        {
            newMineshaftButton[4].gameObject.SetActive(true);
            newMineshaftButtonText[4].text = "New mineshaft ?\n" + newMineshaftCost[4];
        }
        else if (!mineshaft[5])
        {
            newMineshaftButton[5].gameObject.SetActive(true);
            newMineshaftButtonText[5].text = "New mineshaft ?\n" + newMineshaftCost[5];
        }
        else if (!mineshaft[6])
        {
            newMineshaftButton[6].gameObject.SetActive(true);
            newMineshaftButtonText[6].text = "New mineshaft ?\n" + newMineshaftCost[6];
        }
    }

    public void ShowAllMineshaft()
    {
        for (int i = 0; i < mineshaft.Length; i++)
        {
            if (mineshaft[i])
            {
                allMineshaft[i].SetActive(true);
            }
        }
    }

    public void DebugMoney()
    {
        money += 1000;
        PlayerPrefs.SetFloat("money", money);
        RoundMoney();
    }

   

    //Faster Mining
    public void FasterMining(int multi)
    {
        StartCoroutine(FasterMiningENUM(multi));
    }

    IEnumerator FasterMiningENUM(int multi)
    {
        for (int i = 0; i < pickaxe.Length; i++)
        {
            pickaxe[i].speed = multi * 2;
        }
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].Stop();
            var main = particle[i].main;
            main.duration = main.duration / multi;
            particle[i].Play();
        }

        //COAL
        coal.time = coal.time / multi;
        coal.UpdateCoroutine();
        //IRON
        iron.time = iron.time / multi;
        iron.UpdateCoroutine();
        //Gold
        gold.time = gold.time / multi;
        gold.UpdateCoroutine();
        //RUBY
        ruby.time = ruby.time / multi;
        ruby.UpdateCoroutine();
        //Sapphire
        sapphire.time = sapphire.time / multi;
        sapphire.UpdateCoroutine();
        //Diamond
        diamond.time = diamond.time / multi;
        diamond.UpdateCoroutine();
        //Emerald
        emera.time = emera.time / multi;
        emera.UpdateCoroutine();
        //Uran
        uran.time = uran.time / multi;
        uran.UpdateCoroutine();
        shopUpgradeActive = true;
        yield return new WaitForSeconds(30f);
        //COAL
        coal.time = coal.time * multi;
        coal.UpdateCoroutine();
        //IRON
        iron.time = iron.time * multi;
        iron.UpdateCoroutine();
        //Gold
        gold.time = gold.time * multi;
        gold.UpdateCoroutine();
        //RUBY
        ruby.time = ruby.time * multi;
        ruby.UpdateCoroutine();
        //Sapphire
        sapphire.time = sapphire.time * multi;
        sapphire.UpdateCoroutine();
        //Diamond
        diamond.time = diamond.time * multi;
        diamond.UpdateCoroutine();
        //Emerald
        emera.time = emera.time * multi;
        emera.UpdateCoroutine();
        //Uran
        uran.time = uran.time * multi;
        uran.UpdateCoroutine();
        for (int i = 0; i < pickaxe.Length; i++)
        {
            pickaxe[i].speed = 1;
        }
        for (int i = 0; i < particle.Length; i++)
        {
            particle[i].Stop();
            var main = particle[i].main;
            main.duration = main.duration * multi;
            particle[i].Play();
        }
        shopUpgradeActive = false;
    }

    //More Coins
    public void CoinsMining(int multi)
    {
        StartCoroutine(MoreCoinsENUM(multi));
    }

    IEnumerator MoreCoinsENUM(int multi)
    {

        //COAL
        coal.profit = coal.profit * multi;
        coal.UpdateCoroutine();
        //IRON
        iron.profit = iron.profit * multi;
        iron.UpdateCoroutine();
        //Gold
        gold.profit = gold.profit * multi;
        gold.UpdateCoroutine();
        //RUBY
        ruby.profit = ruby.profit * multi;
        ruby.UpdateCoroutine();
        //Sapphire
        sapphire.profit = sapphire.profit * multi;
        sapphire.UpdateCoroutine();
        //Diamond
        diamond.profit = diamond.profit * multi;
        diamond.UpdateCoroutine();
        //Emerald
        emera.profit = emera.profit * multi;
        emera.UpdateCoroutine();
        //Uran
        uran.profit = uran.profit * multi;
        uran.UpdateCoroutine();
        shopUpgradeActive = true;
        yield return new WaitForSeconds(30f);
        //COAL
        coal.profit = coal.profit / multi;
        coal.UpdateCoroutine();
        //IRON
        iron.profit = iron.profit / multi;
        iron.UpdateCoroutine();
        //Gold
        gold.profit = gold.profit / multi;
        gold.UpdateCoroutine();
        //RUBY
        ruby.profit = ruby.profit / multi;
        ruby.UpdateCoroutine();
        //Sapphire
        sapphire.profit = sapphire.profit / multi;
        sapphire.UpdateCoroutine();
        //Diamond
        diamond.profit = diamond.profit / multi;
        diamond.UpdateCoroutine();
        //Emerald
        emera.profit = emera.profit / multi;
        emera.UpdateCoroutine();
        //Uran
        uran.profit = uran.profit / multi;
        uran.UpdateCoroutine();
        shopUpgradeActive = false;
    }


    //Android Toast!
    public void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }


}
