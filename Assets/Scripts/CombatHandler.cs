using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatHandler : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    double attackTimer = 0;

    double enemyAttackTimer = 0;
    double enemyDamage;
    double enemyAttackDelay;

    // Start is called before the first frame update
    void Start()
    {
        player.UpdateStats();
        UpdatePlayer();
        UpdateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        enemyAttackTimer += Time.deltaTime;

        
        //Debug.Log("attackTimer: " + attackTimer);
        //Debug.Log("player.AttackDelay: " + player.AttackDelay);


        if (attackTimer >= player.AttackDelay)
        {
            attackTimer -= player.AttackDelay;
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
            evadeChance = 1 - (100 / (100 + enemy.Evasion - player.Accuracy));


        if (RandFloat() < evadeChance)
        {
            // Attack evaded
            Debug.Log("Enemy evaded attack.");
            return; 
        } else
        {
            double damage = player.Attack * (100 / (100 + enemy.Armor));

            if (RandFloat() < player.CritChance)
            {
                damage *= player.CritMulti;
            }
                

            enemy.TakeDamage((int)damage);
            Debug.Log("Enemy took damage: " + damage);
        }
    }

    public void EnemyAttack()
    {
        double evadeChance;

        if (enemy.Accuracy >= player.Evasion)
            evadeChance = 0;
        else
            evadeChance = 1 - (100 / (100 + player.Evasion - enemy.Accuracy));


        if (RandFloat() < evadeChance)
        {
            // Attack evaded
            Debug.Log("Player evaded attack.");
            return;
        }
        else
        {
            double damage = enemyDamage * (100 / (100 + player.Armor));

            if (RandFloat() < enemy.CritChance)
            {
                damage *= enemy.CritMulti;
            }

            player.TakeDamage((int)damage);
            Debug.Log("Player took damage: " + damage);
        }
    }



    public void UpdatePlayer()
    {
        //player.Attack = player.Attack;
        //attackDelay = player.BaseAttackDelay / player.AttackSpeed;
        Debug.Log("Player attack delay: " + player.AttackDelay);
    }

    public void UpdateEnemy()
    {
        enemyDamage = enemy.Attack;
        enemyAttackDelay = enemy.BaseAttackDelay / enemy.AttackSpeed;
        Debug.Log("Enemy attack delay: " + enemyAttackDelay);

    }

    private float RandFloat()
    {
        return Random.Range(0.0f, 1.0f);
    }
}
