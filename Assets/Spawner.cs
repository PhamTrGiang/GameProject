using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : SpawnController
{
    public int spawnCoubt = 0;
    public float spawnCooldown = 0;

    public string enemy1 = "Goblin_Tourch_Blue";

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        //SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        spawnCooldown += Time.deltaTime;
        if (spawnCoubt == 5) return;
        if(spawnCooldown <= 3) return;
        spawnCooldown = 0;
        spawnCoubt++;
        Transform newEnemy = Spawn(enemy1);
        if (newEnemy == null) return;
        newEnemy.gameObject.SetActive(true);
    }
}
