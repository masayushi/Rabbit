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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            PlayerInRange = true;
        }
        else if (PlayerInRange == true)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(false);
                dialogText.text = dialog;
            }
        }
    }
}
