using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPooler <T> : MonoBehaviour where T : Component
{
    [SerializeField] T prefab;

    public static GenericObjectPooler<T> Instance { get; private set; }
    private Queue<T> objects = new Queue<T>();
    
    [SerializeField] private int startSpawn = 1;

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < startSpawn; i++)
        {
            Get();
        }
    }

    public T Get()
    {
        if(objects.Count == 0)
        {
            addObject(1);
        }
        return objects.Dequeue();
    }

    void addObject(int count)
    {
        var spawn = GameObject.Instantiate(prefab);
        spawn.gameObject.SetActive(false);
        objects.Enqueue(spawn);
        spawn.transform.SetParent(transform);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
