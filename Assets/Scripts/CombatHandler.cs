using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class CombatHandler : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    double attackTimer = 0;
    double playerDamage;
    double attackDelay;

    double enemyAttackTimer = 0;
    double enemyDamage;
    double enemyAttackDelay;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayer();
        UpdateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        enemyAttackTimer += Time.deltaTime;

        
        //Debug.Log("attackTimer: " + attackTimer);
        //Debug.Log("attackDelay: " + attackDelay);


        if (attackTimer >= attackDelay)
        {
            attackTimer -= attackDelay;
            PlayerAttack();
        }

        if (enemyAttackTimer >= enemyAttackDelay)
        {
            enemyAttackTimer -= enemyAttackDelay;
            EnemyAttack();
        }
    }

    public void PlayerAttack()
    {
        double evadeChance;

        if (player.Accuracy >= enemy.Evasion)
            evadeChance = 0;
        else
            evadeChance = 1 - (100 / (100 + enemy.Evasion));


        if (randFloat() < evadeChance)
        {
            // Attack evaded
            //Debug.Log("Enemy evaded attack.");
            return; 
        } else
        {
            double damage = playerDamage * (100 / (100 + enemy.Armor));

            if (randFloat() < player.CritChance)
            {
                damage *= player.CritMulti;
            }
                

            enemy.TakeDamage((int)damage);
            //Debug.Log("Enemy took damage: " + damage);
        }
    }

    public void EnemyAttack()
    {
        double evadeChance;

        if (enemy.Accuracy >= player.Evasion)
            evadeChance = 0;
        else
            evadeChance = 1 - (100 / (100 + player.Evasion));


        if (randFloat() < evadeChance)
        {
            // Attack evaded
            //Debug.Log("Player evaded attack.");
            return;
        }
        else
        {
            double damage = enemyDamage * (100 / (100 + player.Armor));

            if (randFloat() < enemy.CritChance)
            {
                damage *= enemy.CritMulti;
            }

            player.TakeDamage((int)damage);
            //Debug.Log("Player took damage: " + damage);
        }
    }



    public void UpdatePlayer()
    {
        playerDamage = player.Attack;
        attackDelay = player.BaseAttackDelay / player.AttackSpeed;
    }

    public void UpdateEnemy()
    {
        enemyDamage = enemy.Attack;
        enemyAttackDelay = enemy.BaseAttackDelay / enemy.AttackSpeed;
        
    }

    private float randFloat()
    {
        return UnityEngine.Random.Range(0.0f, 1.0f);
    }
}
