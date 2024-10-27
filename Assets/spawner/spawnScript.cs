using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Profiling;
using static spawnScript;

public class spawnScript : MonoBehaviour
{
    public enum spawnState {spawning,waiting,counting};
    public spawnState state = spawnState.counting;
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public Transform enemy; //[] here?
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float waveDelay = 5f;
    public float waveCountDown = 0;

    private float searchCountDown = 1.0f;

    public GameObject WinHUD;

    private void Start()
    {
        waveCountDown = waveDelay;
        playerStats_script.waves = waves.Length;
    }

    private void Update()
    {
        if (state == spawnState.waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveComplete();
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0f)
        {
            if (state != spawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown-=Time.deltaTime;
        }
    }

    void WaveComplete()
    {

        state= spawnState.counting;
        waveCountDown = waveDelay;

        //garbage collection
        //Resources.UnloadUnusedAssets();
        //GC.Collect();
        //CheckMemory();

        if (nextWave + 1 > waves.Length - 1)//the last wave
        {
            nextWave = 0;
            //Debug.Log("LEVEL COMPLETE!");
            WinHUD.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            nextWave++;
            //playerStats_script.currentWave++;
            return;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountDown-=Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1.0f;
            if (GameObject.FindGameObjectWithTag("enemy")==null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        playerStats_script.currentWave++;
        state = spawnState.spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state= spawnState.waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    void CheckMemory()
    {
        Debug.Log($"Mono Used Memory: {Profiler.GetMonoUsedSizeLong() / 1024 / 1024} MB");
        Debug.Log($"Total Reserved Memory: {Profiler.GetTotalReservedMemoryLong() / 1024 / 1024} MB");
        Debug.Log($"Allocated GPU Memory: {Profiler.GetAllocatedMemoryForGraphicsDriver() / 1024 / 1024} MB");
        Debug.Log($"GC Memory: {GC.GetTotalMemory(false) / 1024 / 1024} MB");
    }
}
