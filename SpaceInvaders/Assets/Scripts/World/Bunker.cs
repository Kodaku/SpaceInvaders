using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    public Sprite[] sprites;
    private Sprite currentSprite;
    private int currentSpriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<Sprite>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag.Contains("Projectile"))
        {
            currentSpriteIndex++;

            if(currentSpriteIndex == sprites.Length) Destroy(this.gameObject);
            if(currentSpriteIndex < sprites.Length)
                currentSprite = sprites[currentSpriteIndex];
            GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
    }
}
