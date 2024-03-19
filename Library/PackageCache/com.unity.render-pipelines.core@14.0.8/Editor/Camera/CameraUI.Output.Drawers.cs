using UnityEngine.Rendering;

namespace UnityEditor.Rendering
{
    /// <summary> Camera UI Shared Properties among SRP</summary>
    public static partial class CameraUI
    {
        /// <summary>
        /// Output Section
        /// </summary>
        public static partial class Output
        {
            /// <summary>Draws Allow Dynamic Resolution related fields on the inspector</summary>
            /// <param name="p"><see cref="ISerializedCamera"/> The serialized camera</param>
            /// <param name="owner"><see cref="Editor"/> The editor owner calling this drawer</param>
            public static void Drawer_Output_AllowDynamicResolution(ISerializedCamera p, Editor owner)
            {
                EditorGUILayout.PropertyField(p.allowDynamicResolution, Styles.allowDynamicResolution);
                p.baseCameraSettings.allowDynamicResolution.boolValue = p.allowDynamicResolution.boolValue;
            }

            public static void Drawer_Output_EnableGDRP(ISerializedCamera p, Editor owner)
            {
#if UNITY_GPU_DRIVEN_PIPELINE
                using (new EditorGUI.DisabledScope(GraphicsSettings.enableGDRP))
                {
                    EditorGUILayout.PropertyField(p.enableGDRP, Styles.enableGDRP);
                    p.baseCameraSettings.enableGDRP.boolValue = p.enableGDRP.boolValue;
                }
#endif
            }

            public static void Drawer_Output_BackfaceCulling(ISerializedCamera p, Editor owner)
            {
#if UNITY_GPU_DRIVEN_PIPELINE
                using (new EditorGUI.DisabledScope(GraphicsSettings.enableGDRP))
                {
                    EditorGUILayout.PropertyField(p.backfaceCulling, Styles.backfaceCulling);
                    p.baseCameraSettings.backfaceCulling.boolValue = p.backfaceCulling.boolValue;
                }
#endif
            }

            /// <summary>Draws Normalized ViewPort related fields on the inspector</summary>
            /// <param name="p"><see cref="ISerializedCamera"/> The serialized camera</param>
            /// <param name="owner"><see cref="Editor"/> The editor owner calling this drawer</param>
            public static void Drawer_Output_NormalizedViewPort(ISerializedCamera p, Editor owner)
            {
                EditorGUILayout.PropertyField(p.baseCameraSettings.normalizedViewPortRect, Styles.viewport);
            }

            /// <summary>Draws Depth related fields on the inspector</summary>
            /// <param name="p"><see cref="ISerializedCamera"/> The serialized camera</param>
            /// <param name="owner"><see cref="Editor"/> The editor owner calling this drawer</param>
            public static void Drawer_Output_Depth(ISerializedCamera p, Editor owner)
            {
                EditorGUILayout.PropertyField(p.baseCameraSettings.depth, Styles.depth);
            }

            /// <summary>Draws Render Target related fields on the inspector</summary>
            /// <param name="p"><see cref="ISerializedCamera"/> The serialized camera</param>
            /// <param name="owner"><see cref="Editor"/> The editor owner calling this drawer</param>
            public static void Drawer_Output_RenderTarget(ISerializedCamera p, Editor owner)
            {
                EditorGUILayout.PropertyField(p.baseCameraSettings.targetTexture);
            }
        }
    }
}
