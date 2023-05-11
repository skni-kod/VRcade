using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class MachineLightGun : MonoBehaviour
{
    XRGrabInteractable xrInteractable;
    [SerializeField]
    Transform _rayOrigin;
    [SerializeField]
    Transform _machineScreen;
    [SerializeField]
    DHVRMachine machine;
    [SerializeField]
    GameObject _dotMarker;
    [SerializeField]
    LayerMask _laserLayerMask;

    private void Awake()
    {
        xrInteractable = GetComponent<XRGrabInteractable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var interactor = xrInteractable.interactorsSelecting.Count > 0 ? xrInteractable.interactorsSelecting[0] : null;
        if(interactor != null)
        {
            RaycastHit hit;
            Ray r = new Ray(_rayOrigin.position, _rayOrigin.forward);
            if (Physics.Raycast(r, out hit, 20.0f, _laserLayerMask))
            {
                _dotMarker.SetActive(true);
                _dotMarker.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                _dotMarker.transform.position = hit.point + _dotMarker.transform.up * 0.001f;
            }
            else
                _dotMarker.SetActive(false);
        }
    }

    public void Fire()
    {
        RaycastHit hit;
        Ray r = new Ray(_rayOrigin.position, _rayOrigin.forward);
        if (Physics.Raycast(r, out hit, 20.0f, _laserLayerMask))
        {
            //check if we actually hit this screen.
            if (hit.transform == _machineScreen.transform)
            {
                //here we might want to add some more stuff, so for now it sits.
                if (machine == null || machine.minigameCamera == null) return;

                Ray mr = machine.minigameCamera.ViewportPointToRay(hit.textureCoord);
                Transform hitObject = Physics2D.Raycast(mr.origin, mr.direction).transform;

                if (hitObject != null && hitObject.CompareTag("Duck"))
                    hitObject.transform.GetComponent<MachineDuckController>().HitDuck();
            }
        }
    }
}
