using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BulletManager : MonoBehaviour
{

    public Queue<GameObject> bulletPool;
    public int bulletNumber;

    private BulletFactory factory;


    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
        factory = GetComponent<BulletFactory>();

        //BuildBulletPool();

    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < bulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet()
    {
        var temp_bullet = factory.createBullet(); 
        bulletPool.Enqueue(temp_bullet);
    }

    public GameObject GetBullet(Vector2 spawnPosition)
    {
        if (bulletPool.Count < 1)
        {
            AddBullet();
            bulletNumber++;
        }
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = spawnPosition;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject returnedbullet)
    {
        returnedbullet.SetActive(false);
        bulletPool.Enqueue(returnedbullet);

    }
}
