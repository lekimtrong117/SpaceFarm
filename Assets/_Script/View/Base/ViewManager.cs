using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MySingleton<ViewManager>
{
    public RectTransform anchor;
    private Dictionary<ViewIndex, BaseView> dicView = new Dictionary<ViewIndex, BaseView>();
    public BaseView currentView;
    // Start is called before the first frame update
    void Start()
    {
        foreach (ViewIndex v_index in ViewConfig.viewIndies)
        {
            // create view 
            string nameView = v_index.ToString();
            GameObject v_Object = Instantiate(Resources.Load("View/" + nameView, typeof(GameObject))) as GameObject;
            v_Object.transform.SetParent(anchor, false);
            BaseView view = v_Object.GetComponent<BaseView>();
            dicView.Add(v_index, view);
            v_Object.SetActive(false);
        }
        Instance.SwitchView(ViewIndex.EmptyView);
    }

    public void SwitchView(ViewIndex newView, ViewParam viewParam = null, Action callback = null)
    {
        if (currentView != null)
        {
            ViewCallBack viewCallBack = new ViewCallBack();
            viewCallBack.callback = () =>
            {

                currentView.gameObject.SetActive(false);
                ShowNextView(newView, viewParam, callback);
            };
            currentView.BroadcastMessage("HideView", viewCallBack, SendMessageOptions.RequireReceiver);
        }
        else
        {
            ShowNextView(newView, viewParam, callback);
        }
    }
    private void ShowNextView(ViewIndex newView, ViewParam viewParam = null, Action callback = null)
    {
        currentView = dicView[newView];
        currentView.gameObject.SetActive(true);
        currentView.Setup(viewParam);
        ViewCallBack viewCallBack = new ViewCallBack();
        viewCallBack.callback = callback;
        currentView.BroadcastMessage("ShowView", viewCallBack, SendMessageOptions.RequireReceiver);
    }
}
public class ViewCallBack
{
    public Action callback;
}
