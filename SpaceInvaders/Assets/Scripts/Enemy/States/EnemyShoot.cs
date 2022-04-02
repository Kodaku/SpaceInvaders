using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : State<Enemy>
{
    private static EnemyShoot m_instance;

    public static EnemyShoot Instance { get { return m_instance; }}
    public override void Enter(Enemy entity)
    {
        
    }

    public override void Execute(Enemy entity)
    {
        
    }

    public override void Exit(Enemy entity)
    {
        
    }

    public override bool OnMessage(Enemy entity, Telegram telegram)
    {
        return false;
    }
}
