using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :BaseGameEntity
{
    public float speed;
    public GameObject projectile;
    private StateMachine<Player> stateMachine;
    // Start is called before the first frame update
    public void Initialize()
    {
        stateMachine = new StateMachine<Player>(this);
        stateMachine.currentState = PlayerMove.Instance;
        stateMachine.currentState.Enter(this);
        RegisterEntity((int)Entities.SPACE_SHIP);
    }

    public void ChangeState(State<Player> newState)
    {
        stateMachine.ChangeState(newState);
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return stateMachine.HandleMessage(telegram);
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 playerPosition = transform.position;
        playerPosition.x += speed * Time.deltaTime * horizontal;
        transform.position = playerPosition;
    }

    public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        stateMachine.Update();
    }
}
