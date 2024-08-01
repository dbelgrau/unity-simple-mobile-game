using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class GameplayManager : MonoBehaviour
{
    #region variables
    [SerializeField] private int cashMultiplier = 20;

    [SerializeField] private float attackMultiplier = 1;
    [SerializeField] private float healthMultiplier = 3;

    [SerializeField] private float armorMultiplier = 0.2f;
    [SerializeField] private float blockMultiplier = 0.1f;

    public Character player;
    public Character enemy;

    public bool isPlaying;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text cash;

    #endregion

    #region singleton
    public static GameplayManager Instance { get; private set; }
    private void Awake()
    {
        TouchSimulation.Enable();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public void StartScene()
    {
        Stats.Load();
        Stats.level = 1;
        RespawnEnemy();
        RespawnPlayer();
        UpdateCash();
        isPlaying = true;
    }

    private void RespawnEnemy()
    {
        int health = (int)(Stats.level * healthMultiplier);
        int attack = (int)(Stats.level * attackMultiplier);
        int armor = (int)(Stats.level * armorMultiplier);
        int block = (int)(Stats.level * blockMultiplier);

        enemy.Initiate(attack, armor, block, 0, health);
    }

    private void RespawnPlayer()
    {
        player.Initiate(Stats.playerAttack, Stats.playerArmor, Stats.playerBlock, Stats.playerAverageDmg, Stats.playerHealth);
    }

    public void DefeatEnemy()
    {
        Stats.level++;
        Stats.cash += Stats.level * cashMultiplier;
        Stats.Save();
        UpdateCash();
        RespawnEnemy();
    }

    public void PlayerDead()
    {
        ShowMenu();
        isPlaying = false;
    }

    private void ShowMenu()
    {
        menu.SetActive(true);
    }

    public void UpdateCash()
    {
        cash.text = Stats.cash.ToString() + "$";
    }

    public void DeleteSave()
    {
        Stats.Reset();
    }
}
