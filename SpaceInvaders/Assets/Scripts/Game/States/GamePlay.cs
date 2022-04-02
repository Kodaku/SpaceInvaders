using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : State<Game>
{
    private static GamePlay m_instance;

    public static GamePlay Instance { get { return m_instance; }}

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
    public override void Enter(Game entity)
    {
        
    }

    public override void Execute(Game entity)
    {
        
    }

    public override void Exit(Game entity)
    {
        
    }

    public override bool OnMessage(Game entity, Telegram telegram)
    {
        return false;
    }
}
