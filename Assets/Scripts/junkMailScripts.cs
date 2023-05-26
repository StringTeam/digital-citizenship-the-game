using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class junkMailScripts : MonoBehaviour
{
    public static bool HasInfoScreenBeenDisplayed = false;
    public static GameObject game;
    public int points;
    public GameObject numOfChi;
    GameObject scoreText;

    void Start()
    {
        if (!HasInfoScreenBeenDisplayed)
        {
            GameObject infoText;
            GameObject controlsText;

            GameObject.Instantiate(Resources.Load("Prefabs/info screen template"));

            infoText = GameObject.Find("info");
            infoText.GetComponent<TextMeshProUGUI>().text = "pelin idea: pelissä on tarkoituksena oppia tunnistamaan luotettavat sähköpostit";

            controlsText = GameObject.Find("controls");
            controlsText.GetComponent<TextMeshProUGUI>().text = "kun olet luulet tietäväsi onko sähköposti luotettava vai ei niin painat asian mukaista nappia ruudun oikeasta yläkulmasta";
        }//info screen jutut

        emailList();
        trashList();
        foreNameGen();
        lastNameGen();
        domainGen();
        suslastNameGen();
        susdomainGen();
        numOfChi = GameObject.Find("inboxEmails");
        emailCount = numOfChi.transform.childCount;
        randomSusSender(emailCount);
        inBoxStart();
        game = GameObject.Find("game");
        if (!HasInfoScreenBeenDisplayed)
        {
            game.SetActive(false);//piilottaa scenen sisällön info screenin ajaksi  //tämän täytyy olla start() lopussa!
        }
        //ehkä pelin aloitus ääni?
    }
    private void Update()
    {
        emailCount = numOfChi.transform.childCount;
        if (realTitles.Count - 1 <= emailCount)
        {
            emailList();
        }
        if (trashTitles.Count - 1 <= emailCount) 
        { 
            trashList(); 
        }
    }
    List<string> realTitles = new List<string>();
    List<string> trashTitles = new List<string>();

    List<string> foreNames = new List<string>();
    List<string> lastNames = new List<string>();
    List<string> domains = new List<string>();
    void foreNameGen()
    {
        foreNames.Add("Marja");
        foreNames.Add("Pertti");
        foreNames.Add("Aatu");
        foreNames.Add("Jorma");
        foreNames.Add("Liisa");
        foreNames.Add("Iitu");
        foreNames.Add("Tapani");
        foreNames.Add("Pekka");
        foreNames.Add("Jaska");
        foreNames.Add("Jukka");
        foreNames.Add("Pekka");
        foreNames.Add("Marjo");
        foreNames.Add("Kukka");
        foreNames.Add("Tuuli");
    }    
    void lastNameGen()
    {
        lastNames.Add("järvinen");
        lastNames.Add("jokinen");
        lastNames.Add("nieminen");
        lastNames.Add("mäkelä");
        lastNames.Add("korhonen");
        lastNames.Add("virtanen");
        lastNames.Add("mäkinen");
        lastNames.Add("hämäläinen");
        lastNames.Add("laine");
        lastNames.Add("heikkinen");
        lastNames.Add("saarinen");
        lastNames.Add("hiekkala");
        lastNames.Add("lehto");
        lastNames.Add("kivikoski");
    }    
    void domainGen()
    {
        domains.Add("@gmail.com");
        domains.Add("@outlook.com");
        domains.Add("@hotmail.fi");
    }

    List<string> susforeNames = new List<string>();
    List<string> suslastNames = new List<string>();
    List<string> susdomains = new List<string>();
    void suslastNameGen()
    {
        suslastNames.Add("luotettava");
        suslastNames.Add("uskottava");
        suslastNames.Add("göögle");
        suslastNames.Add("mikrosoft"); 
        suslastNames.Add("stean");
        suslastNames.Add("spotifu");
        suslastNames.Add("uoytube");
    }
    void susdomainGen()
    {
        susdomains.Add("@dmail.com");
        susdomains.Add("kareeria.fi");
        susdomains.Add("outIook.fi");
        susdomains.Add("jrtf.fi");
    }
    public void emailList()
    {
        realTitles.Add("Pakettisi on matkalla!");
        realTitles.Add("Maksu onnistui");
        realTitles.Add("Hakemuksesi on vastaan otettu");
        realTitles.Add("Salasanasi on vaihtedettu");
        realTitles.Add("Tilisi on lukittu");
        realTitles.Add("Tervetuloa meille töihin!");
        realTitles.Add("Työtarjous");
        realTitles.Add("Tervetuloa työhaastatteluun!");
        realTitles.Add("Tilauksesi vanheni");
        realTitles.Add("Maksu epäonnistui");
        realTitles.Add("Seuraamasi tuote on alennuksessa!"); 
        realTitles.Add("Pakettisi on matkalla!");
        realTitles.Add("Maksu onnistui");
        realTitles.Add("Hakemuksesi on vastaan otettu");
        realTitles.Add("Salasanasi on vaihtedettu");
        realTitles.Add("Tilisi on lukittu");
        realTitles.Add("Tervetuloa meille töihin!");
        realTitles.Add("Työtarjous");
        realTitles.Add("Tervetuloa työhaastatteluun!");
        realTitles.Add("Tilauksesi vanheni");
        realTitles.Add("Maksu epäonnistui");
        realTitles.Add("Seuraamasi tuote on alennuksessa!");
    }
    public void trashList()
    {
        trashTitles.Add("Onneksi olkoon olet voittanut!");
        trashTitles.Add("koneesi on vaarassa!!!!!! VASTAA HETI!!");
        trashTitles.Add("Ale Ale Ale OSTA HETI!!");
        trashTitles.Add("tarvitset tämän HETI!");
        trashTitles.Add("KIIREINEN ASIA AVAA VÄLITTÖMÄSTI");
        trashTitles.Add("Olet voittanut!!");
        trashTitles.Add("sinut on valittu!!!!");
        trashTitles.Add("Onneksi olkoon");
        trashTitles.Add("tiilisi on lukittu");
        trashTitles.Add("Tahdot tämän!!");
        trashTitles.Add("Onnea!!!");
        trashTitles.Add("tilisi olla vaarassa!!!!");
        trashTitles.Add("TOIMI HETI!!!!");
        trashTitles.Add("Tietokoneellasi on víirus!!!");
        trashTitles.Add("Soita HETI!!");
        trashTitles.Add("TOIMI HETI!!!!");
    }

    void randomSusSender(int amount)
    {
        for (int o = 0; o < amount; o++)
        {
            string word = "";
            for (int i = 0; i < Random.Range(5, 10); i++)
            {
                char c = (char)Random.Range('a', '{');
                word += c;
            }
            susforeNames.Add(word);
        }
    }
    GameObject email;
    GameObject sender;
    public int emailCount;
    public void inBoxStart()
    {
        //trycatch!!
        int num = 1;
        for (int q = 0; q < emailCount; q++)
        {
            int i = Random.Range(0, trashTitles.Count);
            int o = Random.Range(0, realTitles.Count);
            email = GameObject.Find("email." + num);
            sender = GameObject.Find("sentBy." + num);

            int rng = Random.Range(0, 8);

            if (rng <= 2)//real mail
            {
                email.tag = "realMail";
                email.GetComponent<TextMeshProUGUI>().text = realTitles[Random.Range(0, realTitles.Count)];
                realTitles.RemoveAt(o);
                sender.GetComponent<TextMeshProUGUI>().text = foreNames[Random.Range(0, foreNames.Count)] + "." + lastNames[Random.Range(0, lastNames.Count)] + domains[Random.Range(0, domains.Count)];
            }
            else if (rng == 3)//trash mail
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = trashTitles[i];
                trashTitles.RemoveAt(i);
                sender.GetComponent<TextMeshProUGUI>().text = susforeNames[Random.Range(0, susforeNames.Count)] + "." + lastNames[Random.Range(0, lastNames.Count)] + domains[Random.Range(0, domains.Count)];
            }       //susforeName
            else if (rng == 4)//trash mail
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = trashTitles[i];
                trashTitles.RemoveAt(i);
                sender.GetComponent<TextMeshProUGUI>().text = foreNames[Random.Range(0, foreNames.Count)] + "." + suslastNames[Random.Range(0, suslastNames.Count)] + domains[Random.Range(0, domains.Count)];
            }       //suslastName
            else if (rng == 5)//trash mail
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = trashTitles[i];
                trashTitles.RemoveAt(i);
                sender.GetComponent<TextMeshProUGUI>().text = foreNames[Random.Range(0, foreNames.Count)] + "." + lastNames[Random.Range(0, lastNames.Count)] + susdomains[Random.Range(0, susdomains.Count)];
            }       //susdomain



            else if (rng == 6)//trash mail oikealla otsikolla
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = realTitles[o];
                realTitles.RemoveAt(o);
                sender.GetComponent<TextMeshProUGUI>().text = susforeNames[Random.Range(0, susforeNames.Count)] + "." + lastNames[Random.Range(0, lastNames.Count)] + domains[Random.Range(0, domains.Count)];
            }       //susforeName
            else if (rng == 7)//trash mail oikealla otsikolla
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = realTitles[o];
                realTitles.RemoveAt(o);
                sender.GetComponent<TextMeshProUGUI>().text = foreNames[Random.Range(0, foreNames.Count)] + "." + suslastNames[Random.Range(0, suslastNames.Count)] + domains[Random.Range(0, domains.Count)];
            }       //suslastName
            else if (rng == 8)//trash mail oikealla otsikolla
            {
                email.tag = "trashMail";
                email.GetComponent<TextMeshProUGUI>().text = realTitles[o];
                realTitles.RemoveAt(o);
                sender.GetComponent<TextMeshProUGUI>().text = foreNames[Random.Range(0, foreNames.Count)] + "." + lastNames[Random.Range(0, lastNames.Count)] + susdomains[Random.Range(0, susdomains.Count)];
            }       //susdomain
            num++;
        }
    }
    int num;
    public void markAsReal()
    {
        num++;
        GameObject objectToRemove;
        objectToRemove = GameObject.Find("email." + num);
        GameObject objectToRemove2;
        objectToRemove2 = GameObject.Find("sentBy." + num);
        Destroy(objectToRemove);
        Destroy(objectToRemove2);
        GameObject objectToMove = GameObject.Find("inboxEmails");
        GameObject objectToMove2 = GameObject.Find("sentBy");
        try { objectToMove.transform.position += new Vector3(0, 1f, 0); } catch { Debug.Log("ei mitään liikutettavaa"); }
        try { objectToMove2.transform.position += new Vector3(0, 1f, 0); } catch { Debug.Log("ei mitään liikutettavaa2"); }

        if (objectToRemove.tag == "realMail")
        {
            points++;
            GameObject scoreT;
            scoreT = GameObject.Find("scoreText");
            scoreT.GetComponent<TextMeshProUGUI>().color = Color.green;
            scoreT.GetComponent<TextMeshProUGUI>().text = "Pisteet: " + points.ToString();
            //tähän pisteen saamis ääni?
        }
        else
        {
            GameObject scoreT;
            scoreT = GameObject.Find("scoreText");
            scoreT.GetComponent<TextMeshProUGUI>().color = Color.red;
            if (points > 0)
            {
                points--;

                scoreT.GetComponent<TextMeshProUGUI>().text = "Pisteet: " + points.ToString();
                //tähän pisteen menetys ääni?
            }
        }
        if (emailCount == 1)
        {
            game.SetActive(false);
            GameObject.Instantiate(Resources.Load("Prefabs/JunkMailWinScreen"));
            scoreText = GameObject.Find("scoreText");
            scoreText.GetComponent<TextMeshProUGUI>().text = "Pisteet: " + points.ToString();
            //pelin päättymis ääni?
        }
    }
    public void markAsTrash()
    {
        num++;
        GameObject objectToRemove;
        objectToRemove = GameObject.Find("email." + num); 
        GameObject objectToRemove2;
        objectToRemove2 = GameObject.Find("sentBy." + num);
        Destroy(objectToRemove);
        Destroy(objectToRemove2);
        GameObject objectToMove = GameObject.Find("inboxEmails");
        GameObject objectToMove2 = GameObject.Find("sentBy");
        try { objectToMove.transform.position += new Vector3(0, 1f, 0); } catch { Debug.Log("ei mitään liikutettavaa"); }
        try { objectToMove2.transform.position += new Vector3(0, 1f, 0); } catch { Debug.Log("ei mitään liikutettavaa2"); }
        if (objectToRemove.tag == "trashMail")
        {
            points++;
            GameObject scoreT;
            scoreT = GameObject.Find("scoreText");
            scoreT.GetComponent<TextMeshProUGUI>().color = Color.green;
            scoreT.GetComponent<TextMeshProUGUI>().text = "Pisteet: " + points.ToString();
            //tähän pisteen saamis ääni?
        }
        else
        {
            GameObject scoreT;
            scoreT = GameObject.Find("scoreText");
            scoreT.GetComponent<TextMeshProUGUI>().color = Color.red;
            if (points > 0)
            {
                points--;

                scoreT.GetComponent<TextMeshProUGUI>().text = "Pisteet: " + points.ToString();
                //tähän pisteen menetys ääni?
            }
        }
        if (emailCount == 1)
        {
            game.SetActive(false);
            GameObject.Instantiate(Resources.Load("Prefabs/JunkMailWinScreen"));
            scoreText = GameObject.Find("scoreText");
            scoreText.GetComponent<TextMeshProUGUI>().text = "Pisteesi: " + points.ToString();
            //pelin päättymis ääni?
        }
    }
    public void exit()
    {
        GameObject.Instantiate(Resources.Load("Prefabs/info screen template"));
        game.SetActive(false);
    }
    public void settings()
    {
        GameObject.Instantiate(Resources.Load("Prefabs/Managers.1"));
        game.SetActive(false);
    }
    
}