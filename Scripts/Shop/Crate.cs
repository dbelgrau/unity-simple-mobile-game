using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    [SerializeField] public LootBoxSO crate;
    [SerializeField] public Button button;
    [SerializeField] public TMP_Text description;

    public static string Open(LootBoxSO crate)
    {
        Stats.cash -= crate.price;

        int rng = Random.Range(0, 100);
        int curr = 0;

        foreach (var prize in crate.prizes)
        {
            curr += prize.chance;
            if (curr > rng)
            {
                SetupStats(prize.stat, prize.value);
                return Prize(prize.stat, prize.value);
            }
        }

        return Prize(null, 0);
    }

    private static void SetupStats(StatsEnum stat, int value)
    {
        switch (stat)
        {
            case StatsEnum.HEALTH: Stats.playerHealth += value; break;
            case StatsEnum.ATTACK: Stats.playerAttack += value; break;
            case StatsEnum.ARMOR: Stats.playerArmor += value; break;
            case StatsEnum.BLOCK: Stats.playerBlock += value; break;
            case StatsEnum.AVGDMG: Stats.playerAverageDmg += value; break;
        }

        Stats.Save();
    }

    private static string Prize(StatsEnum? stat, int? value)
    {
        if (!stat.HasValue) return "GOT SCAMMED LOOOL";
        else return $"You have won {stat}: {value}";
    }
}
