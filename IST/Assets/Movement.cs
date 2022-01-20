using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Movement : MonoBehaviour
{



    private KeywordRecognizer keywordRecognizer;

    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    System.Action keywordAction;



    void Start()
    {
        //Create keywords for keyword recognizer
        keywords.Add("left", () =>
        {
            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray()); ;
            keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
            keywordRecognizer.Start();

            void OnPhraseRecognized(PhraseRecognizedEventArgs args)
            {
                System.Action keywordAction;
                // if the keyword recognized is in our dictionary, call that Action.
                if (keywords.TryGetValue(args.text, out keywordAction))
                {
                    keywordAction.Invoke();
                    gameObject.GetComponent<Animator>().Play("BoySitAction1");
                }
            }
        });
    }
}
    



       /* keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray()); ;
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();


        void OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            System.Action keywordAction;
            // if the keyword recognized is in our dictionary, call that Action.
            if (keywords.TryGetValue(args.text, out keywordAction))
            {
                keywordAction.Invoke();
                gameObject.GetComponent<Animator>().Play("BoySitAction1");
            }
        }
    }
}*/

