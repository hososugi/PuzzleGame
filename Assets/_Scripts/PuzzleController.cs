using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject puzzlePiecePrefab;
    public GameObject puzzlePieceParent;
    public int puzzleWidthCount = 3;
    public int puzzleHeightCount = 3;
    public int dropHeight = 10;

    [SerializeField]
    private int puzzlePieceCount;
    [SerializeField]
    private int puzzlePieceScale;

    // Start is called before the first frame update
    void Start()
    {
        puzzlePieceCount = puzzleWidthCount * puzzleHeightCount;
        puzzlePieceScale = 1;

        GeneratePuzzlePieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePuzzlePieces()
    {
        for(var x = 0; x < puzzleWidthCount; x++)
        {
            for (var y = 0; y < puzzleHeightCount; y++)
            {
                Vector3 location = new Vector3(0, dropHeight, 0);
                Quaternion rotation = Quaternion.identity;
                Quaternion roation = Random.rotation;

                GameObject newPuzzlePiece = Instantiate(puzzlePiecePrefab, location, rotation);
                newPuzzlePiece.transform.parent = puzzlePieceParent.transform;
            }
        }
    }
}
