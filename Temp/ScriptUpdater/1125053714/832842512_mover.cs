using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
using DG.Tweening;  

public class mover : MonoBehaviour
{
     public GameObject snakephis;
     public GameObject prefabsnake_light;
     public GameObject prefabsnake_not_light; 
     public GameObject final;
     public Transform perent;    
     public float rb;
     public float movementThreshold = 0.01f;
     public bool changecolor ;
     public bool cpy = false;
     public bool pause = true;
     public GameObject headtexture;
     public AudioSource sound;
     public GameObject walkSound;
     public GameObject bonkSound;

     private bool isFalling;
     private bool objmove;
     private bool tooportal = false;
     private bool tooapple = false;
     private bool proverka;
     private Vector3 previousPosition;
     private Vector3 usl;
     private Animator finanum;
     private GameObject perem;

//https://vk.com/call?id=637398694 
     public List<GameObject> tail = new List<GameObject>();
     public List<string> histori = new List<string>();
     public List<Vector3> stopsnake = new List<Vector3>();
     public List<GameObject> apples = new List<GameObject>();
     public List<Vector3> stopobj = new List<Vector3>();

     

     void Start() 
     {
          apples = new List<GameObject>(GameObject.FindGameObjectsWithTag("apple"));
          apples.Sort(delegate (GameObject a, GameObject b)
          {
              return Vector3.Distance(transform.position, a.transform.position).CompareTo(Vector3.Distance(transform.position, b.transform.position));
          });
          rb = snakephis.GetComponent<Rigidbody2D>().linearVelocity.y;
          previousPosition = transform.position;
          finanum = final.GetComponent<Animator>();
          bonkSound = GameObject.FindGameObjectWithTag("bonkSound");
          walkSound = GameObject.FindGameObjectWithTag("moveSound");

         
     }
     void Update()              
     {

          
          Vector3 currentPosition = transform.position;

        
          if (currentPosition == previousPosition)
          {
               if(tooapple)
               {
                    adderelement();
                    apples = new List<GameObject>(GameObject.FindGameObjectsWithTag("apple"));
     
                    
                    apples.Sort(delegate(GameObject a, GameObject b)
                    {
                        return Vector3.Distance(transform.position, a.transform.position)
                        .CompareTo(Vector3.Distance(transform.position, b.transform.position));
                    });
     
                   

                    if (apples.Count >= 2){
                         GameObject apple1 = apples[0];
                         GameObject apple2 = apples[1];
                         apples.RemoveAt(0);
                         apples.RemoveAt(0);
                         Destroy(apple1);
                         Destroy(apple2); 
                    }  
                    tooapple = false; 
               }
          }
        
      
          previousPosition = currentPosition;
          rb = snakephis.GetComponent<Rigidbody2D>().linearVelocity.y;
          
          if (rb > -0.1f)
          {
               isFalling = false;
               pause = true;
          }
          else
          {
               isFalling = true;
          }


          snakeblock();
          
          if (Input.GetKeyDown("d") && pause ){
               
               
               request("d", transform.position);
               if(proverka && !isFalling)
               {
                    histori.Insert(0,"d"); 
                    headtexture.transform.DORotate(new Vector3(0, 0, 180), 0.3f, RotateMode.FastBeyond360);
                    transform.DOMove(transform.position + transform.right, 0.3f);
                    movesnake();
                    walkSound.GetComponent<AudioSource>().Play(0);
                    
               }
               else 
               {
                    bonkSound.GetComponent<AudioSource>().Play(0);
               }
               
          }
          
          if (Input.GetKeyDown("a") && pause){
                  
               
               request( "a", transform.position);
               if(proverka && !isFalling)
               { 
                    histori.Insert(0,"a");
                    headtexture.transform.DORotate(new Vector3(0, 0, 0), 0.3f, RotateMode.FastBeyond360);
                    transform.DOMove(transform.position - transform.right, 0.3f);
                    movesnake();
                    walkSound.GetComponent<AudioSource>().Play(0);
               }
               else 
               {
                    bonkSound.GetComponent<AudioSource>().Play(0);
               }
                         
          }
          if (Input.GetKeyDown("w") && pause ){
               
               request( "w",  transform.position);
               if(proverka && !isFalling)
               {
                    histori.Insert(0,"w");   
                    headtexture.transform.DORotate(new Vector3(0, 0, 270), 0.3f, RotateMode.FastBeyond360);    
                    transform.DOMove(transform.position + transform.up, 0.3f);
                    movesnake();
                    walkSound.GetComponent<AudioSource>().Play(0);
               }
               else 
               {
                    bonkSound.GetComponent<AudioSource>().Play(0);
               }
               
          }
          if (Input.GetKeyDown("s") && pause){
               
               request( "s",  transform.position);
               if (proverka && !isFalling)
               {
                    histori.Insert(0,"s");   
                    headtexture.transform.DORotate(new Vector3(0, 0, 90), 0.3f, RotateMode.FastBeyond360);  
                    transform.DOMove(transform.position - transform.up, 0.3f);
                    movesnake();
                    
               }
               else 
               {
                    bonkSound.GetComponent<AudioSource>().Play(0);
               }
                         
          } 
          

          

        

          if(Input.GetKeyDown("x"))
          {
             walkSound.GetComponent<AudioSource>().Play(0); 
          }



          if(tooportal)
          {
               snakephis.GetComponent<Rigidbody2D>().gravityScale = 0;
              

               request("e", transform.position);
               if(proverka)
               {
                    histori.Insert(0,"e");
                    StartCoroutine(MoveSnakeThroughPortal(transform.right * 100f));
                    snakephis.GetComponent<Rigidbody2D>().gravityScale = 0; 
               }               
               tooportal = false;
               pause = false;
               finanum.SetBool("final",true);
               
               
          }

          apples = new List<GameObject>(GameObject.FindGameObjectsWithTag("apple"));
     
                   
          apples.Sort(delegate(GameObject a, GameObject b)
          {
               return Vector3.Distance(transform.position, a.transform.position)
               .CompareTo(Vector3.Distance(transform.position, b.transform.position));
          });
     }

     
     



     void snakeblock ()
     {
          for(int i=1; i< 1 + tail.Count; i++)
          {
               stopsnake.RemoveAt(i);
               stopsnake.Insert(i,Round(tail[i-1].transform.position)); 
          }
     }

    
     void request(string napr, Vector3 kord)

     {

          kord = Round(kord);
          if(napr == "w")
          {
               usl = kord += transform.up * 1f;
               if ( !stopsnake.Contains(usl) && !stopobj.Contains(usl))
               {
                    proverka = true;
               }
               else
               {
                    proverka = false;
               }
          } 

          if(napr == "a")
          {
               usl = kord -= transform.right * 1f;
               if ( !stopsnake.Contains(usl) && !stopobj.Contains(usl))
               {
                    proverka = true;
               }
               else
               {
                    proverka = false;
               }
          } 

          if(napr == "s")
          {
               usl = kord -= transform.up * 1f;
               if ( !stopsnake.Contains(usl) && !stopobj.Contains(usl))
               {
                    proverka = true;
               }
               else
               {
                    proverka = false;
                    
               }                
          }

          if(napr == "d")
          {
               usl = kord += transform.right * 1f;
               if ( !stopsnake.Contains(usl) && !stopobj.Contains(usl))
               {
                    proverka = true;
               }
               else
               {
                    proverka = false;
               }                
          } 

          tocenter();  

     }

     IEnumerator MoveSnakeThroughPortal(Vector3 portalShift)
     {
          for (int i = tail.Count - 1; i >= 0 ; i--)
          {
               tail[tail.Count - 1].transform.position += portalShift;
               yield return new WaitForSeconds(0.1f);
               var segment = tail[i];
               segment.transform.position += portalShift;
               yield return new WaitForSeconds(0.1f); 
               int index = stopsnake.IndexOf(Round(segment.transform.position - portalShift));
               if (index != -1) 
               {
                    stopsnake.RemoveAt(index);
               }
               stopsnake.Add(Round(segment.transform.position));
          }
          transform.position += transform.right * 100f;
          //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
     
     void tocenter()
     {
         transform.position = RemoveDecimal(transform.position);

         foreach (GameObject obj in tail)
         {
             obj.transform.position = RemoveDecimal(obj.transform.position);
         }
     }

     Vector3 RemoveDecimal(Vector3 inputVector)
     {
         float roundedX = Mathf.Floor(inputVector.x);
         float roundedY = Mathf.Floor(inputVector.y);
         float roundedZ = Mathf.Floor(inputVector.z);

         return new Vector3(roundedX +0.5f, roundedY + 0.5f, roundedZ );
     }

     void toportal()
     {         

               if (Input.GetKeyDown("e"))
               {
               request( "e",  transform.position);
               if (proverka)
               {
                    histori.Insert(0,"e");     
                    transform.position += transform.right  * 100f;
                    movesnake();
                    
               }          
          }
     }

                     
     void movesnake()
     {
          for(int i=1; i< 1 + tail.Count; i++)
          {
               pause = false;

               if(histori[i] == "d")
               {
                    tail[i-1].transform.DOMove(tail[i-1].transform.position + transform.right * 1f, 0.3f);
               }
               if(histori[i] == "a")
               {
                    tail[i-1].transform.DOMove(tail[i-1].transform.position - transform.right * 1f, 0.3f);
               }

               if(histori[i] == "w")
               {
                    tail[i-1].transform.DOMove(tail[i-1].transform.position + transform.up * 1f, 0.3f);
               }

               if(histori[i] == "s")
               {
                    tail[i-1].transform.DOMove(tail[i-1].transform.position - transform.up * 1f, 0.3f);
               }

               if(histori[i] == "e")
               {
                    tail[i-1].transform.position += transform.right  * 100f;
               }
               stopsnake.RemoveAt(i);
               stopsnake.Insert(i,Round(tail[i-1].transform.position)); 
          }
          
     }

     void adderelement()
     {
         if(changecolor)
         {
             perem = Instantiate(prefabsnake_light, perent);
             Vector3 zxc = tail[tail.Count - 1].transform.position;
             perem.transform.position = zxc;
             tail.Add(perem);
             stopsnake.Add(Round(perem.transform.position));
             changecolor = false;
         }
         else
         {
             perem = Instantiate(prefabsnake_not_light, perent);
             Vector3 zxc = tail[tail.Count - 1].transform.position;
             perem.transform.position = zxc;
             tail.Add(perem);
             stopsnake.Add(Round(perem.transform.position));
             changecolor = true;
         }

         if (histori[tail.Count -1] == "w")
         {
             perem.transform.position -= transform.up * 1f;
         }
         else if (histori[tail.Count -1] == "s")
         {
             perem.transform.position += transform.up * 1f;
         }
         else if (histori[tail.Count -1] == "a")
         {
             perem.transform.position += transform.right * 1f;
         }
         else if (histori[tail.Count -1] == "d")
         {
             perem.transform.position -= transform.right * 1f;
         }

     }


     public static Vector3 Round(Vector3 inputVector)
     {
          float roundedX = Mathf.Round(inputVector.x * 2) / 2;
          float roundedY = Mathf.Round(inputVector.y * 2) / 2;
          float roundedZ = Mathf.Round(inputVector.z * 2) / 2;

          return new Vector3(roundedX, roundedY, roundedZ);
     }

    
     public void ShrinkAndRestartScene()
     {

          if (tail != null && tail.Count > 0)
          {

               foreach (GameObject item in tail)
               {
                   
                    item.transform.DOScale(Vector3.zero, 0.5f);
               }
          }
      
          
          transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
          {
              
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          });
     }
     void OnTriggerEnter2D(Collider2D col)
     {
          if (col.gameObject.tag == "apple")
          {
              tooapple = true;
              
          }
          else if (col.gameObject.tag == "portal" && apples.Count == 0)
          {
              snakephis.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
              snakephis.GetComponent<Rigidbody2D>().gravityScale = 0;
              tooportal = true;
          }
          else if (col.gameObject.tag == "cry" || col.gameObject.tag == "portal")
          {
              snakephis.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
          }
          else if (col.gameObject.tag == "cpy")
          {
              snakephis.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
              snakephis.GetComponent<Rigidbody2D>().gravityScale = 0;
              ShrinkAndRestartScene();
          }
     } 
}