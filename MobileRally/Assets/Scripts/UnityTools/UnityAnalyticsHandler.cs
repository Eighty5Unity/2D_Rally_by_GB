using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnalyticsHandler : IAnalytics
{
    public void TrackEvent(string alias, IDictionary<string, object> eventData)
    {
        if(eventData == null)
        {
            eventData = new Dictionary<string, object>();
        }
        Analytics.CustomEvent(alias, eventData);
    }
}
