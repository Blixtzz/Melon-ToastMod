using MelonLoader;
using System.Net;
using UnityEngine;

namespace ToastClient.External
{
    internal class Items
    {
        public static Sprite SetSprite(string string_0)
        {
            if (string.IsNullOrEmpty(string_0))
            {
                MelonLogger.Msg("Url is Null (LoadSpriteFromUrl)");
                return null;
            }

            byte[] array = new WebClient().DownloadData(string_0);
            if (array == null || array.Length == 0)
            {
                MelonLogger.Msg("flag2 is true (LoadSpriteFromUrl)");
                return null;
            }

            Texture2D texture2D = new Texture2D(512, 512);
            if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
            {
                MelonLogger.Msg("flag3 is true (LoadSpriteFromUrl)");
                return null;
            }

            Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height),
                new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.FullRect, default(Vector4), generateFallbackPhysicsShape: false);
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            if (sprite == null)
            {
                MelonLogger.Msg("Final Sprite is Null (LoadSpriteFromUrl)");
            }
            return sprite;
        }
        public static Texture2D SetTexture(string string_0)
        {
            if (string.IsNullOrEmpty(string_0))
            {
                MelonLogger.Msg("Url is Null (LoadTextureFromUrl)");
                return null;
            }

            byte[] array = new WebClient().DownloadData(string_0);
            if (array == null || array.Length == 0)
            {
                MelonLogger.Msg("flag2 is true (LoadTextureFromUrl)");
                return null;
            }

            Texture2D texture2D = new Texture2D(512, 512);
            if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
            {
                MelonLogger.Msg("flag3 is true (LoadTextureFromUrl)");
                return null;
            }
            texture2D.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            if (texture2D == null)
            {
                MelonLogger.Msg("Final Texture is Null (LoadTextureFromUrl)");
            }
            return texture2D;
        }
    }
}
