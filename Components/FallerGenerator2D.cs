
using UnityEngine;
using Labo;


namespace Fiziks2D
{
    public class FallerGenerator2D : MonoBehaviour
    {
        [SerializeField] private GameObject fallerPrefab;
        private float generateInterval = 1f;    // 単位は秒
        private float lastGenerateSecond = 0.00f;
        private float generateRange = 5f;
        private int GenerateQuantity = 0;    // 命名がいまいち

        [SerializeField] private Sprite appleSprite;
        [SerializeField] private Sprite poisonSprite;
        [SerializeField] private Sprite kanatokoSprite;  // 英語では anvil
        [SerializeField] private Sprite tetrapodSprite;

        private void Update()
        {
            if (Time.time > lastGenerateSecond + generateInterval)
            {
                lastGenerateSecond = Time.time;
                Generate();    
            }
        }


        private void Generate()
        {
            GameObject faller = Instantiate(fallerPrefab);
            GenerateQuantity++;
            // faller.name = "Faller";
            faller.transform.Translate(Random.Range(-generateRange, generateRange), 0.00f, 0.00f);

            Transformation(faller);
        }


        private void Transformation(GameObject newbornFaller)
        {
            if (GenerateQuantity % 4 == 0)
            {
                newbornFaller.GetComponent<SpriteRenderer>().sprite = poisonSprite;
                newbornFaller.tag = TagManager.PoisonTag;
                return;
            }

            if ( GenerateQuantity % 5 == 0)
            {
                newbornFaller.GetComponent<SpriteRenderer>().sprite = kanatokoSprite;
                newbornFaller.tag = TagManager.WeightTag;
                return;
            }
        }
    }
}