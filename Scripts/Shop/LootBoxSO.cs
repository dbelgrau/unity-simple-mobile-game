using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrateSO")]
public class LootBoxSO : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public Color color;
    [SerializeField] public int price;

    [SerializeField] public List<Prize> prizes;
}