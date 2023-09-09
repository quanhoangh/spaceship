using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_ship : MonoBehaviour
{
    public GameObject Bullet;
    public float onFiring;
    public float shootingDelay =1f;
    public float shootingTime;
    public int num_bullet =1;
    private Transform _parent;
    public List<Transform> bullet_point = new List<Transform>();
    public static bullet_ship instance;
    
    public AudioSource audioSource;
    private void Awake()
    {
        bullet_ship.instance = this;
        audioSource = GameObject.Find("sound_bullet").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _parent = new GameObject("Parent").transform;
        if (bullet_point == null) return;
        for(int i=0 ; i < 5; i++)
        {
                GameObject o = GameObject.Find("bl"+i);
            if (o == null) return;
            Transform bullet = o.transform;
            bullet_point.Add(bullet);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        onFiring = Input.GetAxis("Fire1");
        shooting();
    }
    private void shooting()
    {
        if (onFiring == 0) return;
        if (num_bullet == 0) return;
        
        else if (num_bullet == 1)
        {
        
            shootingTime += Time.deltaTime;
            if (shootingTime < shootingDelay) return;
            shootingTime = 0;
            Instantiate(Bullet, transform.position, transform.rotation, _parent);
        }
        else if (num_bullet == 2)
        {
            shootingTime += Time.deltaTime;
            if (shootingTime < shootingDelay) return;
            shootingTime = 0;
            Instantiate(Bullet, bullet_point[3].position, transform.rotation, _parent);
            Instantiate(Bullet, bullet_point[0].position, transform.rotation, _parent);

        }
        else if (num_bullet == 3)
        {
            shootingTime += Time.deltaTime;
            if (shootingTime < shootingDelay) return;
            shootingTime = 0;
            Instantiate(Bullet, bullet_point[3].position, transform.rotation, _parent);
            Instantiate(Bullet, bullet_point[0].position, transform.rotation, _parent);
            Instantiate(Bullet, transform.position, transform.rotation, _parent);

        }
        else if (num_bullet >= 4)
        {
            shootingTime += Time.deltaTime;
            if (shootingTime < shootingDelay) return;
            shootingTime = 0;
            Instantiate(Bullet, bullet_point[0].position, transform.rotation, _parent);
            Instantiate(Bullet, bullet_point[1].position, transform.rotation, _parent);
            Instantiate(Bullet, bullet_point[2].position, transform.rotation, _parent);
            Instantiate(Bullet, bullet_point[3].position, transform.rotation, _parent);
        }
        audioSource.Play();
    }
    

    

}
