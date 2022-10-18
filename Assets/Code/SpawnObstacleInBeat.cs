using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleInBeat : MonoBehaviour
{
    [SerializeField] private List<Animator> _freeObstacle;
    private List<Animator> _usingObstacle;

    private int _randomIndex;

    private void Awake() => _usingObstacle = new List<Animator>();

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    public void SpawnRandomObstacle()
    {
        if(_freeObstacle.Count == 0)
        {
            Debug.LogError("Объекты кончились");
            return;
        }

        _randomIndex = Random.Range(0, _freeObstacle.Count - 1);
        Debug.Log(_randomIndex);
        UsingObstacle(_freeObstacle[_randomIndex]);

        _freeObstacle.RemoveAt(_randomIndex);

        _usingObstacle[_usingObstacle.Count - 1].SetTrigger("StartMove");
    }

    private void UsingObstacle(Animator obstacle)
    {
        _usingObstacle.Add(obstacle);
        StartCoroutine(EndMove(obstacle));
    }

    private IEnumerator EndMove(Animator obstacle)
    {
        yield return new WaitForSeconds(0.5f);
        
        obstacle.SetTrigger("EndMove");

        _freeObstacle.Add(obstacle);
        _usingObstacle.Remove(obstacle);
    }

    private IEnumerator StartSpawn()
    {
        while(true)
        {
            SpawnRandomObstacle();

            yield return new WaitForSeconds(Random.Range(0.3f, 0.4f));
        }
    }
}
