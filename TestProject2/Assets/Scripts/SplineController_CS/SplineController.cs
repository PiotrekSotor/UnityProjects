using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum eOrientationMode { NODE = 0, TANGENT }

public class SplineController : MonoBehaviour
{
    public Vector3[] Positions;
    public Transform[] Transforms;
    public Transform[] mTransforms;
    public GameObject SplineRoot;
    private SplineInterpolator splineInterpolator;
    private float Duration = 10;
    private eOrientationMode OrientationMode = eOrientationMode.NODE;
    private eWrapMode WrapMode = eWrapMode.ONCE;
    private bool AutoStart = true;
    private bool AutoClose = true;
	private bool HideOnExecute = true;
    public Transform EmptyGameObject;
    private SplineInterpolator mSplineInterp;

   public Vector3[] GetPoints(float numOfVertices)
    {
        Vector3[] result = null;
        
        Transform[] trans = GetTransforms();
        if (trans.Length < 2)
            return result;

        SplineInterpolator interp = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;
        SetupSplineInterpolator(interp, trans);
        interp.StartInterpolation(null, false, WrapMode);


        result = new Vector3[(int)numOfVertices];
        for (int c = 0; c < numOfVertices; c++)
        {
            float currTime = c * Duration / numOfVertices;
            result[c] = interp.GetHermiteAtTime(currTime);
        }  
        return result; 
    }



    void Start()
	{
        mSplineInterp = GetComponent(typeof(SplineInterpolator)) as SplineInterpolator;

        mTransforms = GetTransforms();
        SetupSplineInterpolator(mSplineInterp, mTransforms);
        if (HideOnExecute)
            DisableTransforms();

        if (AutoStart)
            FollowSpline();
    }

	void SetupSplineInterpolator(SplineInterpolator interp, Transform[] trans)
	{
		interp.Reset();

		float step = (AutoClose) ? Duration / trans.Length :
			Duration / (trans.Length - 1);

		int c;
		for (c = 0; c < trans.Length; c++)
		{
			if (OrientationMode == eOrientationMode.NODE)
			{
                if (trans[0] == null)
				    interp.AddPoint(Positions[c], new Quaternion(), step * c, new Vector2(0, 1));
                else
                    interp.AddPoint(trans[c].position, trans[c].rotation, step * c, new Vector2(0, 1));
            }
			else if (OrientationMode == eOrientationMode.TANGENT)
			{
				Quaternion rot;
				if (c != trans.Length - 1)
					rot = Quaternion.LookRotation(trans[c + 1].position - trans[c].position, trans[c].up);
				else if (AutoClose)
					rot = Quaternion.LookRotation(trans[0].position - trans[c].position, trans[c].up);
				else
					rot = trans[c].rotation;

				interp.AddPoint(trans[c].position, rot, step * c, new Vector2(0, 1));
			}
		}

		if (AutoClose)
			interp.SetAutoCloseMode(step * c);
	}


	/// <summary>
	/// Returns children transforms, sorted by name.
	/// </summary>
	Transform[] GetTransforms()
	{
        if (SplineRoot != null)
        {
            List<Component> components = new List<Component>(SplineRoot.GetComponentsInChildren(typeof(Transform)));
            List<Transform> transforms = components.ConvertAll(c => (Transform)c);

            transforms.Remove(SplineRoot.transform);
            transforms.Sort(delegate (Transform a, Transform b)
            {
                return a.name.CompareTo(b.name);
            });

            return transforms.ToArray();
        }

        else if (Positions != null)
        {
            //GameObject obj = Instantiate()
            Transform[] transforms = new Transform[Positions.Length];
            //for (int i=0;i<transforms.Length;++i)
            //    transforms[i] = Instantiate(EmptyGameObject, Positions[i], new Quaternion()) as Transform;
            //for (int i=0;i<Positions.Length;++i)
            //    transforms[i].position = ;
            return transforms;

        }
        else if (Transforms != null)
            return Transforms;


		return null;
	}

	/// <summary>
	/// Disables the spline objects, we don't need them outside design-time.
	/// </summary>
	void DisableTransforms()
	{
		if (SplineRoot != null)
		{
			SplineRoot.SetActiveRecursively(false);
		}
	}
    void FollowSpline()
    {
        if (mTransforms.Length > 0)
        {
            SetupSplineInterpolator(mSplineInterp, mTransforms);
            mSplineInterp.StartInterpolation(null, true, WrapMode);
        }
    }
}