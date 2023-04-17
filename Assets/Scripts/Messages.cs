using TMPro;
using UnityEngine;

public class Messages : MonoBehaviour
{
    public TMP_Text messageText;
    public float cooldownTimeMess = 3f;
    private float temporalCoolDownMess;
    public bool noEnergy;
    public bool noMoney;
    public bool notReady;

    // Start is called before the first frame update
    void Start()
    {
        temporalCoolDownMess = cooldownTimeMess;
        messageText.enabled = false;
        noEnergy = false;
        noMoney = false;
        notReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (noEnergy == true)
        {
            NotEnoughEnergy();
        }
        if (noMoney == true)
        {
            NotEnoughMoney();
        }
        if (notReady == true)
        {
            PowerNotReady();
        }
    }
    void NotEnoughEnergy()
    {
        messageText.enabled = true;
        cooldownTimeMess -= Time.deltaTime;
        cooldownTimeMess = Mathf.Clamp(cooldownTimeMess, 0f, Mathf.Infinity);
        messageText.text = "Not Enough Energy!!!";
        if (cooldownTimeMess == 0f)
        {


            messageText.enabled = false;
            cooldownTimeMess = temporalCoolDownMess;
            noEnergy = false;
        }

    }

    void NotEnoughMoney()
    {
        messageText.enabled = true;
        cooldownTimeMess -= Time.deltaTime;
        cooldownTimeMess = Mathf.Clamp(cooldownTimeMess, 0f, Mathf.Infinity);
        messageText.text = "Not Enough Money!!!";
        if (cooldownTimeMess == 0f)
        {


            messageText.enabled = false;
            cooldownTimeMess = temporalCoolDownMess;
            noMoney = false;
        }

    }
    void PowerNotReady()
    {
        messageText.enabled = true;
        cooldownTimeMess -= Time.deltaTime;
        cooldownTimeMess = Mathf.Clamp(cooldownTimeMess, 0f, Mathf.Infinity);
        messageText.text = "Power Not Ready!!!";
        if (cooldownTimeMess == 0f)
        {


            messageText.enabled = false;
            cooldownTimeMess = temporalCoolDownMess;
            notReady = false;
        }

    }
}
