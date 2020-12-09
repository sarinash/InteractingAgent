using UnityEngine;

using UnityEngine.Windows.Speech;


public class audioo : MonoBehaviour
{
    public string[] keywords = new string[] { "hello","happy", "sad", "angry", "clap","dance","die", "stop","bye" ,"son"};
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    



    protected PhraseRecognizer recognizer;
    protected string word = "xxx";

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log( recognizer.IsRunning );
        }


    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        Debug.Log("Recognizer_OnPhraseRecognized.IsRunning");
        Debug.Log("You said: <b>" + word + "</b>");
        if (word=="hello"){FindObjectOfType<AudioManager>().Play("hello");Invoke("finishHello()", 5f);}
        if (word=="happy"){FindObjectOfType<AudioManager>().Play("happy");Invoke("finishHappy()", 5f);}
        if (word=="die"){FindObjectOfType<AudioManager>().Play("die");Invoke("finishDie()", 5f);}
        if (word=="dance"){FindObjectOfType<AudioManager>().Play("dance");Invoke("finishDance()", 15f);}
    }



    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
    [SerializeField] private Animator animator = null;


    private static readonly int hashHappy = Animator.StringToHash("happy");
    private static readonly int hashBlink= Animator.StringToHash("blink");
    private static readonly int hashClap = Animator.StringToHash("clap");
    private static readonly int hashSad = Animator.StringToHash("sad");
    private static readonly int hashAngry = Animator.StringToHash("angry");
    private static readonly int hashDance = Animator.StringToHash("dance");
    private static readonly int hashDie = Animator.StringToHash("die");
    private static readonly int hashHello = Animator.StringToHash("hello");
    private static readonly int hashBye = Animator.StringToHash("bye");
    
    void Update()
     {
         switch(word)
         {
             case "happy":

                                                                
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);
             animator.SetBool(hashHappy, true);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishHappy", 5f);
             break;


             case"dance":

                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, true);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishDance", 15f);
             break;


             case"clap":
                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, true);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishClap", 7f);
             break;


             case"sad":   
                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);                    
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, true);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishSad", 7f);
             break;


             case"angry":
                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, true);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishAngry", 5f);
             break;


             case"die":
                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);                                      
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, true);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishDie", 10f);
             break;
             

             case"hello":
                                                   
             animator.SetBool(hashHello, true);
             animator.SetBool(hashBye, false);                                      
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 
             Invoke("finishHello", 5f);
             break;

             case"son":

             animator.SetBool(hashBlink, true);                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);                                      
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);                        
             Invoke("finishBlink", 5f);
             break;
             

             case"bye":
                                      
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, true);                                      
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);                          
             animator.SetBool(hashBlink, false); 
             Invoke("finishBye", 7f);
             break;
             case"stop":
                                                   
             animator.SetBool(hashHello, false);
             animator.SetBool(hashBye, false);  
             animator.SetBool(hashHappy, false);
             animator.SetBool(hashSad, false);
             animator.SetBool(hashAngry, false);
             animator.SetBool(hashClap, false);
             animator.SetBool(hashDance, false);
             animator.SetBool(hashDie, false);             
             animator.SetBool(hashBlink, false); 

             break;

             case "stophappy":
             animator.SetBool(hashHappy, false);
             break;
             case "stopsad":
             animator.SetBool(hashSad, false);
             break;             
             case "stopangry":
             animator.SetBool(hashAngry, false);
             break;
             case "stopclap":
             animator.SetBool(hashClap, false);
             break;             
             case "stopdance":
             animator.SetBool(hashDance, false);
             break;
             case "stopdie":
             animator.SetBool(hashDie, false);
             break;
             case "stophello":
             animator.SetBool(hashHello, false);
             break;
             case "stopbye":
             animator.SetBool(hashBye, false);
             break;
             
             case "stopblink":
             animator.SetBool(hashBlink, false);
             break;




         }




     }


     public void finishHappy(){word ="stophappy"; Debug.Log("I would <b>" + word + "</b>");FindObjectOfType<AudioManager>().Stop("happy");}    
     public void finishDance(){word ="stopdance"; Debug.Log("I would <b>" + word + "</b>");FindObjectOfType<AudioManager>().Stop("dance");}
     public void finishSad(){word ="stopsad"; Debug.Log("I would <b>" + word + "</b>");}
     public void finishAngry(){word ="stopangry"; Debug.Log("I would <b>" + word + "</b>");}
     public void finishClap(){word ="stopclap"; Debug.Log("I would <b>" + word + "</b>");}
     public void finishDie(){word ="stopdie"; Debug.Log("I would <b>" + word + "</b>");FindObjectOfType<AudioManager>().Stop("die");}
     public void finishHello(){word ="stophello"; Debug.Log("I would <b>" + word + "</b>");FindObjectOfType<AudioManager>().Stop("hello");}
     public void finishBye(){word ="stopbye"; Debug.Log("I would <b>" + word + "</b>");}
     public void finishBlink(){word ="stopblink"; Debug.Log("I would <b>" + word + "</b>");}
     
     //public void finishHelloSong()=>FindObjectOfType<AudioManager>().Stop("hello");
     //public void finishHappySong()=>FindObjectOfType<AudioManager>().Stop("happy");
     //public void finishDieSong()=>FindObjectOfType<AudioManager>().Stop("die");
     //public void finishDanceSong()=>FindObjectOfType<AudioManager>().Stop("dance");
 
        
   


}