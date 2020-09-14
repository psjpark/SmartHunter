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
        
        private void restartSmartHunter()
        {
            string exec = Assembly.GetEntryAssembly()?.Location;
            if (exec != null)
            {
                Process.Start("SmartHunter.exe");
            }
            Environment.Exit(0);
        }


        private string GetLocString(string stringId)
        {
            return LocalizationHelper.GetString(stringId);
        }


        public SettingsViewModel()
        {

            SettingsGeneral = new List<Setting>();
            SettingsTeam = new List<Setting>();
            SettingsMonster = new List<Setting>();           
            

            // SETTINGS_GENERAL_ORIGINAL

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.ShutdownWhenProcessExits,true,"General_1", GetLocString("LOC_SETTING_SHUTDOWN_WHEN_PROCESS_EXIT"), GetLocString("LOC_SETTING_SHUTDOWN_WHEN_PROCESS_EXIT_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.ShutdownWhenProcessExits = !ConfigHelper.Main.Values.ShutdownWhenProcessExits;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates, true, "General_2", GetLocString("LOC_SETTING_AUTO_CHECK_AND_DOWNLOAD_UPDATES"), GetLocString("LOC_SETTING_AUTO_CHECK_AND_DOWNLOAD_UPDATES_DESC"),  new Command(_ =>
            {
                ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates = !ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates;
                ConfigHelper.Main.Save();
                if (!ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates)
                {
                    var result = MessageBox.Show(GetLocString("LOC_SETTING_RESTART_DESC"), GetLocString("LOC_SETTING_RESTART"), MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        restartSmartHunter();
                    }
                }
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive, true, "General_3", GetLocString("LOC_SETTING_HIDE_WHEN_GAME_WINDOW_IS_INACTIVE"),GetLocString("LOC_SETTING_HIDE_WHEN_GAME_WINDOW_IS_INACTIVE_DESC"),  new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive = !ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible, true, "General_4", GetLocString("LOC_SETTING_DEBUG_WIDGET"), GetLocString("LOC_SETTING_DEBUG_WIDGET_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsGeneral.Add(new Setting(ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible, true, "Player_1", GetLocString("LOC_SETTING_PLAYER_WIDGET"), GetLocString("LOC_SETTING_PLAYER_WIDGET_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            // SETTINGS_MONSTER

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, true, "Monster_1", GetLocString("LOC_SETTING_MONSTER_WIDGET"), GetLocString("LOC_SETTING_MONSTER_WIDGET_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible;
               ConfigHelper.Main.Save();               
               ConfigHelper.Main.Reload();
               for (int i = 1; i < SettingsMonster.Count; i++)
                SettingsMonster[i].Enabled = !SettingsMonster[i].Enabled;
           })));


            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible,  "Monster_2", GetLocString("LOC_SETTING_SHOW_UNCHANGED_MONSTERS"), GetLocString("LOC_SETTING_SHOW_UNCHANGED_MONSTERS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_3", GetLocString("LOC_SETTING_SHOW_UNCHANGED_PARTS"), GetLocString("LOC_SETTING_SHOW_UNCHANGED_PARTS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_4", GetLocString("LOC_SETTING_ALWAYS_SHOW_PARTS"), GetLocString("LOC_SETTING_ALWAYS_SHOW_PARTS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBrokenParts;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_5", GetLocString("LOC_SETTING_SHOW_UNCHANGED_STATUS_EFFECTS"), GetLocString("LOC_SETTING_SHOW_UNCHANGED_STATUS_EFFECTS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_6", GetLocString("LOC_SETTING_SHOW_STATUS_EFFECTS"), GetLocString("LOC_SETTING_SHOW_STATUS_EFFECTS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowStatusEffects;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_7", GetLocString("LOC_SETTING_SHOW_MONSTER_SIZE"), GetLocString("LOC_SETTING_SHOW_MONSTER_SIZE_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_8", GetLocString("LOC_SETTING_SHOW_MONSTER_CROWN"), GetLocString("LOC_SETTING_SHOW_MONSTER_CROWN_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_9", GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_BARS"), GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_BARS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_10", GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_NUMBERS"), GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_NUMBERS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_11", GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_PERCENTS"), GetLocString("LOC_SETTING_MONSTER_WIDGET_SHOW_PERCENTS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_12", GetLocString("LOC_SETTING_USE_ANIMATIONS"), GetLocString("LOC_SETTING_USE_ANIMATIONS_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations = !ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            SettingsMonster.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster, ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster_13", GetLocString("LOC_SETTING_SHOW_ONLY_SELECTED_MONSTER"), GetLocString("LOC_SETTING_SHOW_ONLY_SELECTED_MONSTER_DESC"), new Command(_ =>
           {
               ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster;
               ConfigHelper.Main.Save();
               ConfigHelper.Main.Reload();
           })));

            // SETTINGS_TEAM

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, true, "Team_1", GetLocString("LOC_SETTING_TEAM_WIDGET"), GetLocString("LOC_SETTING_TEAM_WIDGET_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
                for (int i = 1; i < SettingsTeam.Count; i++)
                    SettingsTeam[i].Enabled = !SettingsTeam[i].Enabled;
            })));


            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_2", GetLocString("LOC_SETTING_DONT_SHOW_IF_ALONE"), GetLocString("LOC_SETTING_DONT_SHOW_IF_ALONE_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone = !ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_3", GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_BARS"), GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_BARS_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_4", GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_NUMBERS"), GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_NUMBERS_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

            SettingsTeam.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents, ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team_5", GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_PERCENTS"), GetLocString("LOC_SETTING_TEAM_WIDGET_SHOW_PERCENTS_DESC"), new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents;
                ConfigHelper.Main.Save();
                ConfigHelper.Main.Reload();
            })));

        }
    }
}
