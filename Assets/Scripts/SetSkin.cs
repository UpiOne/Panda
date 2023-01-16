using UnityEngine;
using TMPro;
public class SetSkin : MonoBehaviour {
    public int index;
    [SerializeField] private Sprite [ ] bodySprite, leftHandSprite, rightHandSprite, leftFootSprite, rightFootSprite;
    private SpriteRenderer body, leftHand, rightHand, leftFoot, rightFoot;
    public Player player;
    public int coin;
    public TextMeshProUGUI coinShopText;
    private void Awake () {
        index = PlayerPrefs.GetInt ("index");
    }
    private void Start () {
        body = transform.GetChild (0).GetComponent<SpriteRenderer> ();

        ssss();
        UpdateSkin( index);
    }
    public void UpdateSkin (int index) {
        body.sprite = bodySprite [index];
       
    }
 
    private void ssss()
    {
        coinShopText.text =""+ PlayerPrefs.GetInt("coinShop",coin);
        if (index == 2)
        {
            player.Hp += 1;
        }
        else if (index == 4)
        {
            player.Hp += 2;
        }
        else if (index == 6)
        {
            player.Hp += 9;
        }
    }
}