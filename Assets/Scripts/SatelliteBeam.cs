using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteBeamEffect: MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
            {
                Collider[] _col = Physics.OverlapSphere(_hit.point, 15);
                foreach (var col in _col)
                {
                    if (col.CompareTag("SEnemy"))
                    {
                        Damage(col.transform);

                    }
                }

            }
        }
    }
    
    void Damage(Transform enemy)
    {

        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);

        }


    }
}
