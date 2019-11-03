using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public Queue<GameObject> poolQueue;
    public Pool puzzlePiecePool;
    public GameObject puzzlePieceParent;
    public int puzzlePieceScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePuzzlePieces();
    }

    void FixedUpdate()
    {
        Vector3 location     = transform.position;
        //Quaternion rotation = Quaternion.identity;
        Quaternion rotation  = Random.rotation;

        SpawnFromPool("PuzzlePieces", location, rotation);
    }

    void GeneratePuzzlePieces()
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < puzzlePiecePool.size; i++)
        {
            GameObject prefabInstance       = Instantiate(puzzlePiecePool.prefab);
            prefabInstance.transform.parent = puzzlePieceParent.transform;


            prefabInstance.SetActive(false);
            objectPool.Enqueue(prefabInstance);
        }

        poolQueue = objectPool;
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolQueue.Count > 0)
        {
            GameObject objectToSpawn = poolQueue.Dequeue();
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.SetActive(true);
        }
    }

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }
}
