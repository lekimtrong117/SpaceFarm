using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView = 0,
    HomeView = 1,
    InGameView=2,
    ResultView=3,
}

public class ViewConfig
{
    public static ViewIndex[] viewIndies =
    {
        ViewIndex.EmptyView,
        ViewIndex.HomeView,
        ViewIndex.InGameView,
        ViewIndex.ResultView,
    };
}
public class ViewParam
{

}
