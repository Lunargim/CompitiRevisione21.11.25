using UnityEditor;
using UnityEngine;
public class PlanetarySystem : MonoBehaviour
{
    [MenuItem("Mio Menu/Planetary System %#F1")]
    static void SpawnSatellites()
    {
        GameObject planet = Selection.gameObjects[0];
        var planetScale = planet.transform.localScale;
        var radius = planet.GetComponent<SphereCollider>().radius;
        char[] digits = "0123456789".ToCharArray();
        var pos = planet.name.IndexOfAny(digits);
        var foo = planet.name.Substring(pos);
        var satellitesNumber = int.Parse(foo);

        var maxDistance = 50;
        var minScale = 5;
        var maxScale = 20;

        for (int i = 0; i < satellitesNumber; i++)
        {
            var satellite = Instantiate(planet, planet.transform.position + new Vector3(Random.Range(radius*2, maxDistance), 0,0), Quaternion.identity);
            var randomNumberScale = Random.Range(minScale, maxScale);
            satellite.transform.localScale = planetScale/randomNumberScale;
        }
        
        

    }
    
    
    
    
    
    
}
