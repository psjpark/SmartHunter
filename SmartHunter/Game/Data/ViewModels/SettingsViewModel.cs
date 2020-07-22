using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using SmartHunter.Core;
using SmartHunter.Core.Data;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data.ViewModels
{
    public class SettingsViewModel : Bindable
    {
        static SettingsViewModel s_Instance = null;
        public static SettingsViewModel Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new SettingsViewModel();
                }

                return s_Instance;
            }
        }

        public List<Setting> SettingsGeneral { get;  }
        public List<Setting> SettingsMonster { get; }
        public List<Setting> SettingsTeam { get;  }
        public bool SettingsMonsterEnabled { get; }
        
        private void restartSmartHunter()
        {
            string exec = Assembly.GetEntryAssembly()?.Location;
            if (exec != null)
            {
                Process.Start("SmartHunter.exe");
            }
            Environment.Exit(0);
        }

        public SettingsViewModel()
        {

            SettingsGeneral = new List<Setting>();
            SettingsTeam = new List<Setting>();
            SettingsMonster = new List<Setting>();           
            

            // SETTINGS_GENERAL_ORIGINAL

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.ShutdownWhenProcessExits,true,"General_1", "Shutdown when process exits", "Shutdown SmartHunter as soon as MonsterHunterWorld is killed", new Command(_ =>
            {
                ConfigHelper.Main.Values.ShutdownWhenProcessExits = !ConfigHelper.Main.Values.ShutdownWhenProcessExits;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates, true, "General_2", "Automatically check and download updates", "If enabled SmartHunter will automatically check and download new updates",  new Command(_ =>
            {
                ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates = !ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates;
                ConfigHelper.Main.Save();
                if (!ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates)
                {
                    var result = MessageBox.Show("This feature will work on the next open of Smarthunter. Would you like to reopen it now?", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        restartSmartHunter();
                    }
                }
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive, true, "General_3", "Hide when game window is inactive", "Automatically hide every SmartHunter window when MonsterHunterWorld it not top most application",  new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive = !ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible, true, "General_4", "Enable debugging", "Show/Hide Debug Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible, true, "Player_1", "Player Widget", "Show/Hide Player Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            // SETTINGS_MONSTER

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, true, "Monster_1", "Monster Widget", "Show/Hide Monsters Widget", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible;
               ConfigHelper.Main.Save();               
               ConfigHelper.Main.Reload();
               for (int i = 1; i < SettingsMonster.Count; i++)
                SettingsMonster[i].Enabled = !SettingsMonster[i].Enabled;
           })));


            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible,  "Monster_2", "    Show unchanged monsters", "Automatically hide monsters if they are not damaged", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_3", "    Show unchanged parts", "Automatically hide monsters parts if they are not damaged", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_4", "    Show broken parts", "Show damanged monster parts", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_5", "    Show unchanged status effects", "Automatically hide monsters status effects when there weren't any changes", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_6", "    Show status effects", "Show status effects", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_7", "    Show monster size", "Show monster size hover its name", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_8", "    Show monster crown", "Show monster crown image", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_9", "    Monster Widget show bars", "Show Bars inside Monster Widget", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_10", "    Monster Widget show numbers", "Show Numbers inside Monster Widget", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_11", "    Monster Widget show percents", "Show Percents inside Monster Widget", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_12", "    Use animations", "Enable/Disable Animations for status effects", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations = !ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_13", "    Show only selected monster", "Show only the monster that you selected for your hunt", new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            // SETTINGS_TEAM

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, true, "Team_1", "Team Widget", "Show/Hide Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
                for (int i = 1; i < SettingsTeam.Count; i++)
                    SettingsTeam[i].Enabled = !SettingsTeam[i].Enabled;
            })));


            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_2", "    Dont show if alone", "Automatically hide Team Widget if you are alone in a mission", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone = !ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_3", "    Team Widget show bars", "Show Bars inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_4", "    Team Widget show numbers", "Show Numbers inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_5", "    Team Widget show percents", "Show Percents inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));



        }
    }
}
