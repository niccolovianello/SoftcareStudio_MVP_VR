using System.Collections.Generic;
using UnityEngine;

namespace Scriptable_Objects
{
    
    [CreateAssetMenu(fileName = "NewSessionList", menuName = "Game Sessions/Session List")]
    public class SessionList : ScriptableObject
    {
        public List<GameSession> sessions = new List<GameSession>();
    }
}
