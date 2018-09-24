using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace RecyclerView
{
    public class RecyclerView : MonoBehaviour
    {
        private static ScrollRect scrollContent;
        private Adapter<ViewHolder> mAdapter;

        public RecyclerView()
        {
        }

        public void setAdapter(Adapter<ViewHolder> adapter)
        {
            mAdapter = adapter;
        }

        public abstract class Adapter<VH> where VH : ViewHolder
        {
            private List<Object> objectList;
            
            public abstract VH onCreateViewHolder(int viewType);

            public abstract void onBindViewHolder(VH holder, int position);

            public void bindViewHolder()
            {
//                GameObject newItem = Instantiate(listItem) as GameObject;
//                newItem.transform.SetParent(scrollContent.transform);
//                onBindViewHolder(VH, );
            }
        }
    }
    
    public abstract class ViewHolder
    {
        private RecyclerView mRecyclerView;
        private GameObject itemView;

        public ViewHolder(GameObject itemView)
        {
            if (itemView == null)
            {
                throw new Exception("itemView may not be null");
            }
            this.itemView = itemView;
        }
    }
}