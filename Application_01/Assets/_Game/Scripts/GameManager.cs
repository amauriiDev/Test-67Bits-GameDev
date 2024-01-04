using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("HUD")]
    [SerializeField]private Text txtMoney;
    [SerializeField]private Text txtLevel;
    [SerializeField]private Slider sldLevel;


    [Header("INSTANC. INSPEC")]
    [SerializeField]private UserData userData;
    [SerializeField]private PowerUp[] powerUps; // 0 = speed ; 1 = maxStack
    [SerializeField]private Spawn spawn;

    [Header("POWER UP UI")]
    [SerializeField]private Text txtSpeedLevel;
    [SerializeField]private Text txtSpeedCost;
    [SerializeField]private Text txtMaxStackLevel;
    [SerializeField]private Text txtMaxStackCost;

    [Header("PLAYER MATERIAL")]
    [SerializeField]private Material playerMaterial;

    public UserData UserData { get => userData;}



    private void OnEnable()
    {
        UserData.OnLevelUp+=ChangePlayerColor;
    }
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerMaterial.color = Color.white;
        }
        ///userData.NewGame();
        instance = this;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            setXp();
            setLevel();
            setMaxXp();
            setMoney();
            setSpeedText();
            setMaxStackText();
        }
    }

    void setXp(){
        sldLevel.value = userData.Xp;
    }
    void setMoney(){
        txtMoney.text = userData.Money.ToString();
    }

    void setLevel(){
        txtLevel.text = $"Level: {userData.Level}";
    }
    void setSpeedText(){
        txtSpeedLevel.text = $"Increase Speed \nLevel: {powerUps[0].Level}";
        txtSpeedCost.text = $"Valor: {powerUps[0].Cost}";
    }
    void setMaxStackText(){
        txtMaxStackLevel.text = $"Increase Max Stack \nLevel: {powerUps[1].Level}";
        txtMaxStackCost.text = $"Valor: {powerUps[1].Cost}";
    }
    
    public void addMoney(int value){
        userData.UpdateMoney(value);
        setMoney();
    } 
    public void AddXp(int value){
        
        if (userData.AddXp(value))  // level up
        {
            setLevel();
            setMaxXp();
        }
        
        setXp();
    }
    void setMaxXp(){
        sldLevel.maxValue =  userData.MaxXp;
    }

    public void SetPowerUp(PowerUp powerUp){

        if (userData.Money < powerUp.Cost)
            return;

        userData.UpdateMoney(-powerUp.Cost);
        setMoney();
        powerUp.LevelUp();

        switch (powerUp.Type)
        {
            case Type.Speed:
                userData.IncreaseSpeed();
                setSpeedText();
            break;

            case Type.Stack:
                userData.IncreaseMaxStack();
                setMaxStackText();
            break;
        }
    }

    private void ChangePlayerColor(){
        Color c = RandomColor();
        if ( playerMaterial.color == c ){
            ChangePlayerColor();
            return;
            }
        playerMaterial.color = c;
    }
    Color RandomColor(){
        return new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));

    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    private void OnDisable()
    {
        UserData.OnLevelUp-=ChangePlayerColor;
    }
}
