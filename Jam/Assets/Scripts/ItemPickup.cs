using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    //[SerializeField]
    //private TMP_Text pickUpText;

    public GameObject NewShed;

    private bool pickUpAllowed;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        //pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E) && item.name == "Shed")
        {
            PickUpShed();
        }
        else if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        };
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        };
    }
    
    private void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        Destroy(gameObject);
    }

    private void PickUpShed()
    {
        List<Item> list = Inventory.instance.GetList();
        int countLogs = 0;
        int countSoi = 0;
        foreach (Item s in list)
        {
            if (s.name != null && s.name.StartsWith("Log")) countLogs++;
            else if(s.name != null && s.name.StartsWith("Soi")) countSoi++;
        }

        if (countLogs > 1 && countSoi > 0)
        {
            var newShed = Instantiate(NewShed) as GameObject;
            newShed.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3.0f, gameObject.transform.position.z);
            Constants.BuiltBuildings.Add(GetShedNumber());
            Destroy(gameObject);
            
            foreach (Item s in list)
            {
                if (s.name != null && s.name.StartsWith("Log") && countLogs > -1)
                {
                    countLogs--;
                    Inventory.instance.Remove(s);
                }
                else if (s.name != null && s.name.StartsWith("Soi") && countSoi > -1)
                {
                    countSoi--;
                    Inventory.instance.Remove(s);
                }
            }
        }
        else
            Debug.Log("Not enough logs or soi");
    }

    private int GetShedNumber()
    {
        int.TryParse(this.gameObject.name.Replace("shed", string.Empty), out int result);
        return result;
    }
}
