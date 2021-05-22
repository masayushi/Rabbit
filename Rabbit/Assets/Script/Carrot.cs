using UnityEngine;
using UnityEngine.UI;


public class Carrot : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool PlayerInRange;


    private void Start()
    {

    }

    private void Update()
    {
        if (PlayerInRange == true)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            PlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
