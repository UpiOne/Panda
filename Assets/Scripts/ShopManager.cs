
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    public int index;
    private int indexNow;
    public int coin;
    [SerializeField] private SetSkin setSkin;
    [SerializeField] private Text coinText;
    [SerializeField] private Text priceText;
    [SerializeField] private int [ ] price;

    [SerializeField] private Button buttonSkin;

    [SerializeField] private string[] bonusText;
    [SerializeField] private Text bonusText1;

    private void Start () {
       
        index = setSkin.index;
        indexNow = index;
        coin = PlayerPrefs.GetInt ("coinShop");
        Skin ();
        
    }
    private void Update()
    {
        Skin();
      
    }
    public void SkinMinus () {
        if (index > 0)
            index--;
        else
            index = 6;
        Skin ();
    }
    public void SkinPlus () {
        if (index < 6)
            index++;
        else
            index = 0;
        Skin ();
    }
    private void Skin () {
        setSkin.UpdateSkin (index);
        coinText.text = "Love: "+ coin.ToString ();
        priceText.text = "Price: " + price [index].ToString ();
  
        if (coin >= price[index])
        {
            priceText.color = Color.green;
            buttonSkin.interactable = true;
        }
           

        else if (coin < price[index])
        {
            priceText.color = Color.red;
            buttonSkin.interactable = false;
        }
            
        if (indexNow == index) {
            priceText.color = Color.white;
            priceText.text = "Selected";
            buttonSkin.interactable = true;
         
        } else if (PlayerPrefs.GetInt ("Skin" + index.ToString ()) == 1 || index == 0) {
            priceText.color = Color.white;
            priceText.text = "You can choose !";
            buttonSkin.interactable = true;
          
        }
        if (index == 2)
        {
            bonusText1.text = $"{ bonusText[0]}";
        }
        else if (index == 4)
        {
            bonusText1.text = $"{ bonusText[1]}";
        }
        else if (index == 6)
        {
            bonusText1.text = $"{ bonusText[2]}";
        }
        else
        {
            bonusText1.text = $"{ bonusText[3]}";
        }
    }
    public void BuySkin () {
      
        Skin ();
        if (PlayerPrefs.GetInt ("Skin" + index.ToString ()) == 1 || index == 0) {
            PlayerPrefs.SetInt ("index", index);
            priceText.color = Color.white;
            priceText.text = "Selected";
            indexNow = index;
        } else if (PlayerPrefs.GetInt ("Skin" + index.ToString ()) == 0) {
            if (coin >= price [index]) {
                coin -= price [index];
                priceText.text = price [index].ToString ();
                PlayerPrefs.SetInt ("coinShop", coin);
                PlayerPrefs.SetInt ("Skin" + index.ToString (), 1);
            }
            Skin ();
        }
    }


   
}