using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnTurrets : MonoBehaviour
{
    private GameObject spawnTurret;

    private GameObject[] spawns;
    [SerializeField] private Material orange;
    [SerializeField] private Material grey;

    private bool spawning = false;

    Animator anim;

    private int currentTurrets = 0;
    [SerializeField] private int maxTurret;
    [SerializeField] private TextMeshProUGUI currentTurretsText;
    [SerializeField] private TextMeshProUGUI maxTurretsText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spawns = GameObject.FindGameObjectsWithTag("SpawnTurret");
        maxTurretsText.text = maxTurret.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && spawning)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("SpawnTurret"))
                {
                    Vector3 pos = hit.transform.position;
                    pos.y += hit.transform.localScale.y;
                    Instantiate(spawnTurret, pos, Quaternion.identity);
                    currentTurrets += 1;
                }
            }

            anim.SetFloat("isOpen", 1);

            spawning = false;
            spawnTurret = null;

            foreach (GameObject go in spawns)
            {
                go.GetComponent<MeshRenderer>().material = grey;
            }
        }

        currentTurretsText.text = currentTurrets.ToString();

    }

    public void SpawnTurret(GameObject turret)
    { 
        if (currentTurrets < maxTurret)
        {
            foreach (GameObject go in spawns)
            {
                go.GetComponent<MeshRenderer>().material = orange;
            }

            anim.SetFloat("isOpen", 0);
            spawnTurret = turret;
            spawning = true;
        }
    }
}
