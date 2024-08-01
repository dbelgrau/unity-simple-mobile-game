using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class ScamShop : MonoBehaviour
{
    [SerializeField] private TMP_Text prizeText;
    [SerializeField] private GameObject prizePanel;

    [SerializeField] private LootBoxSO selectedCrate;
    [SerializeField] private List<LootBoxSO> possibleCrates;

    [SerializeField] private Crate cratePrefab;
    [SerializeField] private Transform uiSpawner;

    [SerializeField] private TMP_Text chancePrefab;
    [SerializeField] private Transform chancesSpawner;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private TMP_Text blockText;
    [SerializeField] private TMP_Text avgDmgText;

    private void Awake()
    {
        Stats.Load();
        InitCrates(uiSpawner);
        SetStatsDisplay();
        GameplayManager.Instance.UpdateCash();
    }

    private void InitCrates(Transform spawner)
    {
        for (var i = spawner.childCount - 1; i >= 0; i--)
        {
            Destroy(spawner.GetChild(i).gameObject);
        }

        foreach (var crate in possibleCrates)
        {
            var newCrate = Instantiate(cratePrefab, spawner);

            newCrate.crate = crate;
            newCrate.button.onClick.AddListener(() => SelectCrate(crate));
            newCrate.button.image.color = crate.color;
            newCrate.description.text = $"{crate.name} - ${crate.price}";
        }
    }

    private void InitChances(Transform spawner)
    {
        for (var i = spawner.childCount - 1; i >= 0; i--)
        {
            Destroy(spawner.GetChild(i).gameObject);
        }

        int lostChance = 100;
        foreach (var prize in selectedCrate.prizes)
        {
            var newChance = Instantiate(chancePrefab, spawner);
            newChance.text = $"{prize.stat}: {prize.value} ({prize.chance}%)";
            lostChance -= prize.chance;
        }

        if (lostChance > 0)
        {
            var newChance = Instantiate(chancePrefab, spawner);
            newChance.text = $"NOTHING: {lostChance}%";
        }
    }

    private void SetStatsDisplay()
    {
        healthText.text = $"HEALTH: {Stats.playerHealth}";
        attackText.text = $"ATTACK VALUE: {Stats.playerAttack}";
        armorText.text = $"ARMOR POINTS: {Stats.playerArmor}";
        blockText.text = $"BLOCK CHANCE: {Stats.playerBlock}%";
        avgDmgText.text = $"AVERAGE DAMAGE: {Stats.playerAverageDmg}%";
    }

    public void SelectCrate(LootBoxSO crate)
    {
        selectedCrate = crate;
        InitChances(chancesSpawner);
    }

    public void OpenCrate()
    {
        if (selectedCrate == null || selectedCrate.price > Stats.cash) return;
        
        string result = Crate.Open(selectedCrate);
        ShowWin(result);
        SetStatsDisplay();
        GameplayManager.Instance.UpdateCash();
    }

    private void ShowWin(string result)
    {
        prizePanel.SetActive(true);
        prizeText.text = result;
    }
}
