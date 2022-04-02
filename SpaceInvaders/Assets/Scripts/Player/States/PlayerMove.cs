using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : State<Player>
{
    private static PlayerMove m_instance;

    public static PlayerMove Instance { get { return m_instance; }}

    void Awake()
    {
        if(m_instance != null && m_instance != this)
        {
            Destroy(this);
        }
        else
        {
            m_instance = this;
        }
    }
    public override void Enter(Player player)
    {
        
    }

    public override void Execute(Player player)
    {
        player.Move();
        player.Shoot();
    }

    public override void Exit(Player player)
    {
        
    }

    public override bool OnMessage(Player player, Telegram telegram)
    {
        return false;
    }
}
