using UnityEngine;

[ExecuteInEditMode]
public class LightSource : MonoBehaviour {

    public Object[] baseMats;
    public bool blue;
    public Object[] greenMats;
    public Light light1;
    public Light light2;

	// Use this for initialization
	void Start () {
        if(blue)
        {
            baseMats = Resources.LoadAll("Mats/BlueMats", typeof(Material));
        }
        else
        {
            baseMats = Resources.LoadAll("Mats/YellowMats", typeof(Material));
        }
        greenMats = Resources.LoadAll("Mats/GreenMats", typeof(Material));

        Invoke("LayerChange", 2);
    }

    void LayerChange()
    {
        ChangeChildLayers(transform.parent.parent.gameObject);
    }

    private void ChangeChildLayers(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            var renderer = child.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.gameObject.layer = 10;
            }
            ChangeChildLayers(child.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach(Object reveal in baseMats)
        {
            ((Material)reveal).SetVector("_LightPosition", light1.transform.position);
            ((Material)reveal).SetVector("_LightDirection", -light1.transform.forward);
            ((Material)reveal).SetFloat("_LightAngle", light1.spotAngle);
            ((Material)reveal).SetFloat("_LightIntensity", light1.intensity);
        }

        foreach (Object revealBoth in greenMats)
        {
            ((Material)revealBoth).SetVector("_LightPosition", light1.transform.position);
            ((Material)revealBoth).SetVector("_LightDirection", -light1.transform.forward);
            ((Material)revealBoth).SetFloat("_LightAngle", light1.spotAngle);
            ((Material)revealBoth).SetFloat("_LightIntensity", light1.intensity);
            ((Material)revealBoth).SetVector("_LightPosition2", light2.transform.position);
            ((Material)revealBoth).SetVector("_LightDirection2", -light2.transform.forward);
            ((Material)revealBoth).SetFloat("_LightAngle2", light2.spotAngle);
            ((Material)revealBoth).SetFloat("_LightIntensity2", light2.intensity);
        }
    }
}
