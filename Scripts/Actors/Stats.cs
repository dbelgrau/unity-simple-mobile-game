using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    public static int level = 1;
    public static int cash;

    public static int playerHealth = 10;
    public static int playerAttack = 1;
    public static int playerArmor = 0;
    public static int playerBlock = 0;
    public static  int playerAverageDmg = 0;

    public static void Save()
    {
        //PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("cash", cash);

        PlayerPrefs.SetInt("health", playerHealth);
        PlayerPrefs.SetInt("attack", playerAttack);
        PlayerPrefs.SetInt("armor", playerArmor);
        PlayerPrefs.SetInt("block", playerBlock);
        PlayerPrefs.SetInt("avgdmg", playerAverageDmg);
    }

    public static void Load()
    {
        //level = PlayerPrefs.GetInt("level", 1);
        cash = PlayerPrefs.GetInt("cash", 0);

        playerHealth = PlayerPrefs.GetInt("health", 10);
        playerAttack = PlayerPrefs.GetInt("attack", 1);
        playerArmor = PlayerPrefs.GetInt("armor", 0);
        playerBlock = PlayerPrefs.GetInt("block", 0);
        playerAverageDmg = PlayerPrefs.GetInt("avgdmg", 0);
    }

    public static void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
