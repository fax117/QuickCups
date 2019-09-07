using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject masterCard;
    public Material[] typeOfCard = new Material[3];
    //private ArrayList correctOrder = new ArrayList();
    private List<int> correctOrder = new List<int>();
    private List<int> playerOrder = new List<int>();
    public Canvas canvas;
    //private bool equal;


    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, 3);
        masterCard.GetComponent<MeshRenderer>().material = typeOfCard[r];

        if (r == 0) {
            correctOrder.Add(3);
            correctOrder.Add(4);
            correctOrder.Add(0);
            correctOrder.Add(2);
            correctOrder.Add(1);
        }
        else if (r == 1) {
            correctOrder.Add(2);
            correctOrder.Add(3);
            correctOrder.Add(4);
            correctOrder.Add(0);
            correctOrder.Add(1);
        }
        else
        {
            correctOrder.Add(0);
            correctOrder.Add(1);
            correctOrder.Add(2);
            correctOrder.Add(3);
            correctOrder.Add(4);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Card")
                {
                    var cardColorInstance = hit.collider.gameObject.GetComponent<Renderer>().material.name.ToString();
                    string cardColor = cardColorInstance.Substring(0, 3);
                    //playerOrder.Add()
                    Debug.Log(cardColor);

                    switch (cardColor)
                    {
                        case "Yel":
                            playerOrder.Add(0);
                            break;
                        case "Blu":
                            playerOrder.Add(1);
                            break;
                        case "Red":
                            playerOrder.Add(2);
                            break;
                        case "Gre":
                            playerOrder.Add(3);
                            break;
                        case "Bla":
                            playerOrder.Add(4);
                            break;

                    }
                }
            }
        }

        CheckWin();
    }

    private void CheckWin(){
        if (playerOrder.Count == 5)
        {
            for (int i = 0; i < correctOrder.Count; i++)
            {
                if (correctOrder[i] == playerOrder[i])
                {
                    //equal = true;
                    //Do GG IZI
                    Debug.Log("Ganaste");
                    WinGame();


                }
                else
                {
                    //equal = false;
                    //Do Game Over
                    Debug.Log("Loser");
                    LoseGame();

                }
            }
        }
    }


    private void LoseGame()
    {
        Debug.Log("Game Over");
    }
    
    private void WinGame(){
        Debug.Log("Victory");
    }


}
