using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOLevelsComplit : ScriptableObject
{
    [Header("Complit Test")]
    public List<LevelComplet> levels;
}


[System.Serializable]
public class LevelComplet
{
    public GameObject levelGame;
    public float LimitMap; 
}