using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Chunk _chunkPrefab;
    [SerializeField] private Vector3 _startPosition;

    private int _poolSize = 10;
    private List<Chunk> _chunksPool;

    private void Start()
    {
        GameplayManager.Instance.OnStartGame += CreateChunks;
        _chunksPool = new List<Chunk>();
    }

    private void CreateChunks()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var newChunk = Instantiate(_chunkPrefab, transform);
            
            newChunk.transform.position =
                _chunksPool.Count == 0 ? _startPosition : _chunksPool.Last().transform.position + _startPosition;
            newChunk.Setup();
            
            _chunksPool.Add(newChunk);
        }
    }

    public void BackToPool(Chunk chunk)
    {
        if (_chunksPool.Contains(chunk))
        {
            _chunksPool.Remove(chunk);
            var lastChunk = _chunksPool.Last();
            chunk.transform.position = lastChunk.transform.position + _startPosition;
            chunk.ResetChunk();
            _chunksPool.Add(chunk);
        }
    }
}
