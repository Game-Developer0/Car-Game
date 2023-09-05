using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMetroride : MonoBehaviour
{
    public ParticleSystem back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MetrorideCountRoutine()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Track"))
        {
            back.Stop();
            StartCoroutine(MetrorideCountRoutine());
            
        }
    }
}
