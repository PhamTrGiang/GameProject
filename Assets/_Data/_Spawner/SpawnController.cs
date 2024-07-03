using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SpawnController : MyBehaviourScript
{
    public List<Transform> prefabs;
    public List<Transform> points;

    private static SpawnController instance;
    public static SpawnController Instance { get { return instance; } }

    public override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadSpawnPoins();
    }

    private void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.parent.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }

    private void LoadSpawnPoins()
    {
        if (this.points.Count > 0) return;
        Transform pointObj = transform.parent.Find("SpawnPoints");
        foreach (Transform point in pointObj)
        {
            this.points.Add(point);
        }
    }

    private void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public Transform Spawn(string prefabName)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        Transform spawnPoint = this.GetRandom();
        if (prefab == null)
        {
            Debug.Log("Prefab not fount: " + prefabName);
            return null;
        }
        if (spawnPoint == null)
        {
            Debug.Log("SpawnPoint not fount: " + spawnPoint.name);
            return null;
        }
        Transform newPrefab = Instantiate(prefab,spawnPoint.position, spawnPoint.rotation);

        return newPrefab;
    }
    public Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }

}
