using System.Collections.Generic;
using Game.Config;
using Game.Data;
using Game.Network.Data;
using Game.Utils;
using UnityEngine;

namespace Game
{
    public class RemoteObjectsController : MonoBehaviour
    {
        [SerializeField] private RemoteObjectViewConfig config;
        [SerializeField] private Transform viewsHolder;
        
        private readonly Dictionary<string, RemoteObjectView> viewsMap = new Dictionary<string, RemoteObjectView>();
        private readonly List<RemoteObjectView> views = new List<RemoteObjectView>();
        
        public void CreateViews(int count)
        {
            for (int i = 0; i < count; i++)
            {
                views.Add(GetNewView());
            }
        }

        public void UpdateViews(RemoteObjectData[] data)
        {
            foreach (var objectData in data)
            {
                var type = objectData.type;
                var view = GetView(objectData.name);
                view.Init(new RemoteObjectViewData(objectData.name, config.GetMaterial(type), objectData.coordinate.GetVector3(), config.AnimationTime));
            }
        }

        private RemoteObjectView GetView(string name) // there should be an ID as uniq data for each object
        {
            if (viewsMap.TryGetValue(name, out var view))
            {
                return view;
            }

            view = GetFreeView();
            viewsMap.Add(name, view);
            return view;
        }

        private RemoteObjectView GetFreeView()
        {
            foreach (var view in views)
            {
                if (viewsMap.ContainsValue(view) == false)
                {
                    return view;
                }
            }

            return GetNewView();
        }

        private RemoteObjectView GetNewView()
        {
            var view = Instantiate(config.Prefab, viewsHolder);
            views.Add(view);
            return view;
        }
    }
}