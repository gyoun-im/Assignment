using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    GameObject pacman;

    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pacman.transform.position.x == -28 && pacman.transform.position.y == 26)
        {
            tweener.addTween(pacman.transform, pacman.transform.position, new Vector3(-19.0f, 26.0f, 0.0f), 3.0f);
        }
        if (pacman.transform.position.x == -19 && pacman.transform.position.y == 26)
        {
            tweener.addTween(pacman.transform, pacman.transform.position, new Vector3(-19.0f, 19.0f, 0.0f), 3.0f);
        }
        if (pacman.transform.position.x == -19 && pacman.transform.position.y == 19)
        {
            tweener.addTween(pacman.transform, pacman.transform.position, new Vector3(-28.0f, 19.0f, 0.0f), 3.0f);
        }
        if (pacman.transform.position.x == -28 && pacman.transform.position.y == 19)
        {
            tweener.addTween(pacman.transform, pacman.transform.position, new Vector3(-28.0f, 26.0f, 0.0f), 3.0f);
        }
    }
}
