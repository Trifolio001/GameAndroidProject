using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOCriationLevel : ScriptableObject
{
    public ArtManager.ArtType artType;
    public float Limitmoviment;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int PiecesStartNumber = 3;
    public int PiecesNumber = 5;
    public int PiecesEndNumber = 1;

    [Header("Especiais")]
    public List<PiecesExpecialSetup> piecesExpecialSetup;
}

[System.Serializable]
public class PiecesExpecialSetup
{
    public LevelPieceBase levelPiecesspecial;
    public int inicialpausespecialitem;
    public int pausespecialitem;
}