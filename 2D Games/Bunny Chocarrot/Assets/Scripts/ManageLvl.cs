using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLvl : MonoBehaviour
{

    public GameObject[] lvls;
    [SerializeField] GameObject lvlAtual;
    [SerializeField] GameObject lastLvl;
    int lvlUp = 0;

    [SerializeField] PlayerMoves playerScript;

    public int lvlatualOptions;
    // Start is called before the first frame update
    void Start()
    {
        lvlAtual = lvls[lvlUp];

    }

    // Update is called once per frame
    void Update()
    {
        lvlatualOptions = lvlUp;


    }


    public void switchLvl()
    {
        
        
            lvlAtual = lvls[lvlUp];
            lvlAtual.SetActive(true);
            lvlUp++;
            playerScript.checkpointValue++;

            lastLvl = lvls[lvlUp - 2];
            lastLvl.SetActive(false);

        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Carrot"))
        {
            Debug.Log("esta colidindo");
            switchLvl();
        }
    }
}
