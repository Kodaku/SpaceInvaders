using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainersManager : MonoBehaviour
{
    public GameObject worldContainer;
    public GameObject enemiesContainer;
    public GameObject bunkerContainer;
    private GameObject currentWorldContainer;
    private GameObject currentEnemiesContainer;
    private GameObject currentBunkerContainer;
    private static ContainersManager m_instance;
    public static ContainersManager Instance { get { return m_instance; }}

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
    
    public void InstantiateContainers()
    {
        currentWorldContainer = Instantiate(worldContainer);
        currentEnemiesContainer = Instantiate(enemiesContainer);
        currentBunkerContainer = Instantiate(bunkerContainer);
    }

    public GameObject InstantiateWorldCell(GameObject objToInstantiate, Vector2 position)
    {
        GameObject instance = Instantiate(objToInstantiate, position, Quaternion.identity);
        instance.transform.parent = currentWorldContainer.transform;
        return instance;
    }

    public GameObject InstantiateEnemy(GameObject objToInstantiate, Vector2 position)
    {
        GameObject instance = Instantiate(objToInstantiate, position, Quaternion.identity);
        instance.transform.parent = currentEnemiesContainer.transform;
        return instance;
    }

    public GameObject InstantiateBunker(GameObject objToInstantiate, Vector2 position)
    {
        GameObject instance = Instantiate(objToInstantiate, position, Quaternion.identity);
        instance.transform.parent = currentBunkerContainer.transform;
        return instance;
    }

    public void DestroyContainers()
    {
        if(currentEnemiesContainer != null)
        {
            Destroy(currentBunkerContainer);
            Destroy(currentEnemiesContainer);
            Destroy(currentWorldContainer);
        }
    }
}
