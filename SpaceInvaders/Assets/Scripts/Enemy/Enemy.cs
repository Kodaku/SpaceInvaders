using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseGameEntity
{
    public Sprite[] availableSprites;
    public GameObject enemyProjectile;
    private Sprite currentSprite;
    private StateMachine<Enemy> stateMachine;
    private float animationTime = 1.0f;
    private float currentAnimationTime = 0.0f;
    private int animationIndex = 0;
    private float projectileTimer;
    private float currentProjectileTimer = 0.0f;
    // Start is called before the first frame update
    public void Initialize()
    {
        projectileTimer = Random.Range(2.0f, 5.0f);
        currentSprite = GetComponent<Sprite>();
        stateMachine = new StateMachine<Enemy>(this);
        RegisterEntity((int)Entities.INVADER);
    }

    public void ChangeState(State<Enemy> newState)
    {
        stateMachine.ChangeState(newState);
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return stateMachine.HandleMessage(telegram);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        currentAnimationTime += Time.deltaTime;
        currentProjectileTimer += Time.deltaTime;
        if(currentAnimationTime >= animationTime)
        {
            Vector2 enemyPosition = transform.position;
            enemyPosition.x += animationTime / 4.0f;
            transform.position = enemyPosition;
            animationTime -= Time.deltaTime;
            animationTime = Mathf.Clamp(animationTime, 0.1f, 1.0f);
            currentAnimationTime = 0.0f;
            animationIndex = (animationIndex + 1) % availableSprites.Length;
            currentSprite = availableSprites[animationIndex];
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
        if(currentProjectileTimer >= projectileTimer)
        {
            currentProjectileTimer = 0.0f;
            projectileTimer = Random.Range(2.0f, 5.0f);
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        }
    }
}
