using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject defensePrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject shooterPrefab;
    [SerializeField] private GameObject meleePrefab;

    private GameObject _defense;
    private GameObject _attacking;

    private bool selector;

    private float delay;
    private float posX;
    private float posY;

    private int selectMob;
    private int positionsMob;

    private void Awake()
    {
        if (_defense == null) 
        {
            _defense = Instantiate(defensePrefab) as GameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selector) 
        {
            StartCoroutine(CreateMob());
        }
    }

    public IEnumerator CreateMob() 
    {
        selector = true;
        delay = Random.Range(1f,3f);
        selectMob = Random.Range(1, 4);
        yield return new WaitForSeconds(delay);

        positionsMob = Random.Range(1, 5);

        yield return new WaitForSeconds(delay);

        switch (positionsMob)
        {
            case 1:
                {
                    posX = -10.0f;
                    posY = Random.Range(-7f, 7f);
                    break;
                }
            case 2:
                {
                    posX = 10.0f;
                   
                   posY = Random.Range(-6f, 6f);
                    break;
                }
            case 3:
                {
                    posY = -7f;
                    posX = Random.Range(-10f, 10f);
                    break;
                }
            case 4:
                {
                    posY = 7f;
                    posX = Random.Range(-10f, 10f);
                    break;
                }
        }

        switch (selectMob)
        {
            case 1:
                {
                    _attacking = Instantiate(bombPrefab) as GameObject;
                    _attacking.transform.position = new Vector2(posX, posY);
                    break;
                }
            case 2:
                {
                    _attacking = Instantiate(shooterPrefab) as GameObject;
                    _attacking.transform.position = new Vector2(posX, posY);
                    break;
                }
            case 3:
                {
                    _attacking = Instantiate(meleePrefab) as GameObject;
                    _attacking.transform.position = new Vector2(posX, posY);
                    break;
                }
        }

        selector = false;

    }

}
