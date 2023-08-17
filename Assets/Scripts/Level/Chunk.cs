using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Food _food;

    public void Setup()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Setup();
        }
    }
    
    public void ResetChunk()
    {
        _food.ResetFood();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.BackToPool(this);
        }
    }
}
