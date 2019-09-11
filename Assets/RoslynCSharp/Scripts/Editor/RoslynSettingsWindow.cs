using Trivial.ImGUI;
using UnityEditor;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using RoslynCSharp.Security;
using UnityEngine;

namespace RoslynCSharp.Editor
{
    [CustomEditor(typeof(RoslynCSharp))]
    public class RoslynSettingsWindow : ImInspectorWindow<RoslynCSharp>
    {
        // Private
        private const int labelWidth = 160;
        private const int negativeVerticalSpaceSize = 28;

        private RoslynCSharp settings = null;
        private int selectedReference = -1;
        private int selectedDefineSymbol = -1;
        private int selectedIllegalReference = -1;
        private int selectedIllegalNamespace = -1;
        private int selectedIllegalType = -1;
        private int selectedTab = 0;

        // Methods
        [MenuItem("Tools/Roslyn C#/Settings")]
        public static void ShowWindow()
        {
            // Try to load the asset
            RoslynCSharp settings = RoslynCSharp.LoadAsset();

            // Check for no asset
            if (settings == null)
                settings = CreateInstance<RoslynCSharp>();

            // Select the item
            Selection.activeObject = settings;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            // Load settings from project
            settings = RoslynCSharp.LoadAsset();

            // Use default settings
            if (settings == null)
                settings = CreateInstance<RoslynCSharp>();
        }

        protected override void OnDisable()
        { 
            base.OnDisable();

            // Save settings to project
            RoslynCSharp.SaveAsset(settings);
        }

        public override void OnImGUI()
        {
            // 
            OnImGUIContent();
        }

        public void OnImGUIContent()
        {
            // Display a toolbar
            ImGUI.ToolbarItem("Compiler");
            ImGUI.ToolbarItem("Security");

            ImGUILayout.Space(5);
            ImGUILayout.BeginLayout(ImGUILayoutType.HorizontalCentered);
            {
                ImGUI.SetNextWidth(220);
                selectedTab = ImGUILayout.Toolbar(selectedTab);
            }
            ImGUILayout.EndLayout();
            ImGUILayout.Space(10);


            // Compiler tab
            if (selectedTab == 0)
            {
                // Allow Unsafe
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Allow Unsafe Code:");

                    // Toggle
                    settings.AllowUnsafeCode = ImGUILayout.Toggle(settings.AllowUnsafeCode);
                }
                ImGUILayout.EndLayout();

                // Allow optimize
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Allow Optimize Code:");

                    // Toggle
                    settings.AllowOptimizeCode = ImGUILayout.Toggle(settings.AllowOptimizeCode);
                }
                ImGUILayout.EndLayout();

                // Allow concurrent
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Allow Concurrent Compile:");

                    // Toggle
                    settings.AllowConcurrentCompile = ImGUILayout.Toggle(settings.AllowConcurrentCompile);
                }
                ImGUILayout.EndLayout();

                // Generate in memory
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Generate in Memory:");

                    // Toggle
                    settings.GenerateInMemory = ImGUILayout.Toggle(settings.GenerateInMemory);
                }
                ImGUILayout.EndLayout();

                // Warning level
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Warning Level:");

                    // Popup
                    for (int i = 0; i < 5; i++)
                        ImGUI.PopupItem(i.ToString());

                    settings.WarningLevel = ImGUILayout.Popup(settings.WarningLevel);
                }
                ImGUILayout.EndLayout();

                // Language version
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Language Version:");

                    // Toggle
                    settings.LanguageVersion = (LanguageVersion)ImGUILayout.EnumPopup(settings.LanguageVersion);
                }
                ImGUILayout.EndLayout();

                // Target platform
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Target Platform:");

                    // Toggle
                    settings.TargetPlatform = (Platform)ImGUILayout.EnumPopup(settings.TargetPlatform);
                }
                ImGUILayout.EndLayout();

                // References
                selectedReference = ImGUILayout.Listbox<string>("References", settings.References, selectedReference, () =>
                {
                    // Get input from the user
                    InputDialog.ShowDialog("Add Assembly Reference", "Enter the name or path of the assembly to reference", (string input) =>
                    {
                        // Add the new reference
                        if (settings.References.Contains(input) == false)
                        {
                            settings.References.Add(input);
                            Repaint();
                        }
                    });
                    return null;
                }, OnListItemImGUI);

                // Defines
                selectedDefineSymbol = ImGUILayout.Listbox<string>("Define Symbols", settings.DefineSymbols, selectedDefineSymbol, () =>
                {
                    // Get input from the user
                    InputDialog.ShowDialog("Add Define Symbol", "Enter the name of the scripting define symbol", (string input) =>
                    {
                        // Add the new reference
                        if (settings.References.Contains(input) == false)
                        {
                            settings.References.Add(input);
                            Repaint();
                        }
                    });
                    return null;
                }, OnListItemImGUI);
            }
            // Security tab
            else if (selectedTab == 1)
            {
                // Security check code
                ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                {
                    // Label
                    ImGUI.SetNextWidth(labelWidth);
                    ImGUILayout.Label("Security Check Code:");

                    // Toggle
                    settings.SecurityCheckCode = ImGUILayout.Toggle(settings.SecurityCheckCode);
                }
                ImGUILayout.EndLayout();


                // Disable if security check is not enabled
                ImGUI.PushEnabledVisualState(settings.SecurityCheckCode);
                {
                    selectedIllegalReference = ImGUILayout.Listbox<string>("References", settings.SecurityRestrictions.References, selectedIllegalReference, ()  =>
                    {
                        // Get input from the user
                        InputDialog.ShowDialog("Add Reference", "Enter the name of the illegal reference including the '.dll' file extension, For example: 'UnityEditor.dll'", (string input) =>
                        {
                            // Add the new reference
                            settings.SecurityRestrictions.AddAssemblyReference(input);
                            Repaint();
                        });

                        // Dont add item by default
                        return null;
                    }, OnListItemImGUI);

                    // Move under list
                    ImGUILayout.Space(-negativeVerticalSpaceSize);

                    // Illegal references
                    ImGUI.SetNextWidth(Screen.width - 100);
                    ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                    {
                        // Small indent
                        ImGUILayout.Space(5);

                        // Label
                        ImGUI.SetNextTooltip("Blacklist mode will ensure that all references are not used whereas whitelist mode will only allow the use of the specified references");
                        ImGUILayout.Label("Restriction Type:");

                        // Popup
                        settings.SecurityRestrictions.ReferencesMode = (SecurityRestrictions.SecurityRestrictionMode)ImGUILayout.EnumPopup(settings.SecurityRestrictions.ReferencesMode);
                    }
                    ImGUILayout.EndLayout();
                    ImGUILayout.Space(10);




                    // Illegal namespaces
                    selectedIllegalNamespace = ImGUILayout.Listbox<string>("Namespaces", settings.SecurityRestrictions.Namespaces, selectedIllegalNamespace, () => 
                    {
                        // Get input from the user
                        InputDialog.ShowDialog("Add Namespace", "Enter the name of the illegal namespace. Wildcards can be used to also exclude child namespaces, For example: 'System.IO.*'", (string input) =>
                        {
                            // Add the new reference
                            settings.SecurityRestrictions.AddNamespace(input);
                            Repaint();
                        });

                        // Dont add item by default
                        return null;
                    }, OnListItemImGUI);

                    // Move under list
                    ImGUILayout.Space(-negativeVerticalSpaceSize);

                    ImGUI.SetNextWidth(Screen.width - 100);
                    ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                    {
                        // Small indent
                        ImGUILayout.Space(5);

                        // Label
                        ImGUI.SetNextTooltip("Blacklist mode will ensure that all namespaces are not used whereas whitelist mode will only allow the use of the specified namespaces");
                        ImGUILayout.Label("Restriction Type:");

                        // Popup
                        settings.SecurityRestrictions.NamespacesMode = (SecurityRestrictions.SecurityRestrictionMode)ImGUILayout.EnumPopup(settings.SecurityRestrictions.NamespacesMode);
                    }
                    ImGUILayout.EndLayout();
                    ImGUILayout.Space(10);




                    // Illegal references
                    selectedIllegalType = ImGUILayout.Listbox<string>("Types", settings.SecurityRestrictions.TypeNames, selectedIllegalType, () =>
                    {
                        // Get input from the user
                        InputDialog.ShowDialog("Add Type", "Enter the name of the illegal type. Assembly qualified type names are preferred however you may be able to use the full type name including namespace, For example: 'System.AppDomain'", (string input) =>
                        {
                            // Add the new reference
                            settings.SecurityRestrictions.AddType(input);
                            Repaint();
                        });

                        // Dont add item by default
                        return null;
                    }, OnListItemImGUI);

                    // Move under list
                    ImGUILayout.Space(-negativeVerticalSpaceSize);

                    ImGUI.SetNextWidth(Screen.width - 100);
                    ImGUILayout.BeginLayout(ImGUILayoutType.Horizontal);
                    {
                        // Small indent
                        ImGUILayout.Space(5);

                        // Label
                        ImGUI.SetNextTooltip("Blacklist mode will ensure that all types are not used whereas whitelist mode will only allow the use of the specified types");
                        ImGUILayout.Label("Restriction Type:");

                        // Popup
                        settings.SecurityRestrictions.TypesMode = (SecurityRestrictions.SecurityRestrictionMode)ImGUILayout.EnumPopup(settings.SecurityRestrictions.TypesMode);
                    }
                    ImGUILayout.EndLayout();
                }
                ImGUI.PopVisualState();
            }
        }

        private void OnListItemImGUI(string item)
        {
            ImGUILayout.Label(item);
        }
    }
}
