using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    private List<GameObject> levels;

    public int listLevelReference = -1;
    public SOLevelsComplit levelcomplit;
    public List<SOCriationLevel> levelPieceBaseSetup;

    [SerializeField]
    private int _index;
    private GameObject _currentLevel;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private List<int> _specialPieces = new List<int>();
    private LevelPieceBase lastPiece;

    public TouchController limitcontrolMap;
    public GameObject manafArtManagerm;
    public GameObject manafCorManagerm;
    public GameObject boxCorManagerm;



    private void Awake()
    {
        CreateLevelPieces(Random.Range(0, levelPieceBaseSetup.Count));
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnNextLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spawnNextLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spawnNextLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CreateLevelPieces(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CreateLevelPieces(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CreateLevelPieces(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CreateLevelPieces(Random.Range(0, levelPieceBaseSetup.Count));
        }

    }

    private void spawnNextLevel(int keymap)
    {
        listLevelReference = keymap;
        CleanSpawnnedPieces();

        limitcontrolMap.LimitUpdate(levelcomplit.levels[listLevelReference].LimitMap);
        _currentLevel = Instantiate(levelcomplit.levels[listLevelReference].levelGame, container);
        _currentLevel.transform.localPosition = container.position;

        if (ColorManager.Instance == null)
        {
            Instantiate(manafCorManagerm);
        }
        if (ColorManager.Instance != null)
        {
            ColorManager.Instance.ChangeColorByType(levelPieceBaseSetup[listLevelReference].artType);
        }
        else
        {
            Debug.LogError("ColorManager.Instance é nulo!");
        }
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void CleanSpawnnedPieces()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if (_index >= levelcomplit.levels.Count)
            {
                ResetLevelIndex();
            }
        }
        for (int i = _spawnedPieces.Count -1; i>= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
        _specialPieces.Clear();
    }

    private void CreateLevelPieces(int numRef)
    {
        listLevelReference = numRef;
        CleanSpawnnedPieces();
        //listLevelReference = Random.Range(0, levelPieceBaseSetup.Count - 1);

        limitcontrolMap.LimitUpdate(levelPieceBaseSetup[listLevelReference].Limitmoviment);
        _spawnedPieces = new List<LevelPieceBase>();
        _specialPieces = new List<int>();

        if (levelPieceBaseSetup[listLevelReference].piecesExpecialSetup != null)
        {
            for (int i = 0; i < levelPieceBaseSetup[listLevelReference].piecesExpecialSetup.Count; i++) {
                _specialPieces.Add(levelPieceBaseSetup[listLevelReference].piecesExpecialSetup[i].inicialpausespecialitem); 
            }
        }
        if(levelPieceBaseSetup[listLevelReference] != null)
        {
            _index++;
            if (_index >= levelPieceBaseSetup.Count)
            {
                ResetLevelIndex();
            }
        }

        for (int i = 0; i < levelPieceBaseSetup[listLevelReference].PiecesStartNumber; i++)
        {
            CreateLevelPiece(levelPieceBaseSetup[listLevelReference].levelPiecesStart, null);
        }
        for (int i = 0; i < levelPieceBaseSetup[listLevelReference].PiecesNumber; i++)
        {
            for (int j = 0; j < _specialPieces.Count; j++)
            {

                _specialPieces[j]--;
                if (_specialPieces[j] < 1)
                {
                    _specialPieces[j] = (levelPieceBaseSetup[listLevelReference].piecesExpecialSetup[j].pausespecialitem);
                    CreateLevelPiece(null, levelPieceBaseSetup[listLevelReference].piecesExpecialSetup[j].levelPiecesspecial);
                    i++;
                }
            }

            CreateLevelPiece(levelPieceBaseSetup[listLevelReference].levelPieces, null);

        }
        for (int i = 0; i < levelPieceBaseSetup[listLevelReference].PiecesEndNumber; i++)
        {
            CreateLevelPiece(levelPieceBaseSetup[listLevelReference].levelPiecesEnd, null);
        }

        if (ColorManager.Instance == null)
        {
            Instantiate(manafCorManagerm);
        }
        if (ColorManager.Instance != null)
        {
            ColorManager.Instance.ChangeColorByType(levelPieceBaseSetup[listLevelReference].artType);
        }
        else
        {
            Debug.LogError("ColorManager.Instance é nulo!");
        }
    }



    private void CreateLevelPiece(List<LevelPieceBase> List, LevelPieceBase objectgame)
    {
        LevelPieceBase piece;
        if (objectgame != null)
        {
            piece = objectgame;
        }
        else
        {
            piece = List[Random.Range(0, List.Count)];
        }
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.position = container.position;
        }

        if (ArtManager.Instance == null)
        {
            Instantiate(manafArtManagerm); 
        }

        if (ArtManager.Instance != null) 
        { 
            foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
            {
                p.ChangePiece(ArtManager.Instance.GetSetupByType(levelPieceBaseSetup[listLevelReference].artType));
            }
        }
        else
        {
            Debug.LogError("ArtrManager.Instance é nulo!");
        }

        _spawnedPieces.Add(spawnedPiece);
    }


}
