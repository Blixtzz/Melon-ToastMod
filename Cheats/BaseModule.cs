using UnityEngine;

namespace ToastClient.Modules
{
    public abstract class BaseModule
    {
        public virtual void OnUpdate()
        {
        }
        public virtual void OnPlayerJoin(VRC.Player player)
        {
        }
        public virtual void OnPlayerLeft(VRC.Player player)
        {
        }
        public virtual void Init()
        {
        }
        public virtual void OnAvatarLoaded(VRC.Player player, GameObject avatarObject)
        {
        }
    }
}