using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerObj;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Game>().Initialize();
        player = Instantiate(playerObj, new Vector2(10, 2), Quaternion.identity).GetComponent<Player>();
        player.Initialize();
    }

    private void InitializeGrid()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
