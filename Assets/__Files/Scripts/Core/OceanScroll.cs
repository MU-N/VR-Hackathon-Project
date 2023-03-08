using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRHackathon
{
    using UnityEngine;
    using System.Collections;

    public class OceanScroll : MonoBehaviour
    {
        public float scrollSpeed = 0.5F;
        public Material oceanMat;
        void Start()
        {
            oceanMat = GetComponent<MeshRenderer>().material;
        }
        void Update()
        {
            float offset = Time.time * scrollSpeed;
            oceanMat.mainTextureOffset = new Vector2(offset, offset);
        }
    }
}
