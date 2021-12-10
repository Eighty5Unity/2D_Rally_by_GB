using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnalytics
{
    void TrackEvent(string alias, IDictionary<string, object> eventData);
   
}
