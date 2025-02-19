﻿using Dalamud.Interface.Components;

namespace SubmarineTracker.Windows.Config;

public partial class ConfigWindow
{
    private void Overlay()
    {
        if (ImGui.BeginTabItem($"{Loc.Localize("Config Tab - Overlay", "Overlay")}##Overlay"))
        {
            var changed = false;
            ImGuiHelpers.ScaledDummy(5.0f);

            ImGui.TextColored(ImGuiColors.DalamudViolet, Loc.Localize("Config Tab Entry - Behavior", "Behavior:"));
            ImGuiHelpers.ScaledIndent(10.0f);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Open On Startup", "Open On Startup"), ref Configuration.OverlayStartUp);
            ImGuiComponents.HelpMarker(Loc.Localize("Config Tab Tooltip - Open On Startup", "Opens the overlay, if it was closed before shutting down the game, on the next startup"));
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - On Return", "Open On Return"), ref Configuration.OverlayAlwaysOpen);
            ImGuiComponents.HelpMarker(Loc.Localize("Config Tab Tooltip - On Return", "Automatically opens the overlay if a submarine has returned"));
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Automatically Close", "Automatically Close"), ref Configuration.OverlayHoldClosed);
            ImGuiComponents.HelpMarker(Loc.Localize("Config Tab Tooltip - Automatically Close", "Automatically closes the overlay if all submarines are on voyage, and holds it closed"));
            ImGuiHelpers.ScaledIndent(-10.0f);

            ImGuiHelpers.ScaledDummy(5.0f);

            ImGui.TextColored(ImGuiColors.DalamudViolet, Loc.Localize("Config Tab Entry - General", "General:"));
            ImGuiHelpers.ScaledIndent(10.0f);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Show Rank", "Show Rank"), ref Configuration.OverlayShowRank);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Show Build", "Show Build"), ref Configuration.OverlayShowBuild);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - As Date", "Show As Date"), ref Configuration.OverlayShowDate);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Title Time", "Show Time In Title"), ref Configuration.OverlayTitleTime);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - First Return Time", "Show First Return Time"), ref Configuration.OverlayFirstReturn);
            ImGuiComponents.HelpMarker(Loc.Localize("Config Tab Tooltip - First Return Time", "Shows the first returning sub in the overlay headers for each FC."));
            if (ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Sort Time Lowest", "Sort By Lowest Time"), ref Configuration.OverlaySort))
            {
                changed = true;
                Configuration.OverlaySortReverse = false;
            }
            ImGuiComponents.HelpMarker(Loc.Localize("Config Tab Tooltip - Sort Time Lowest", "Sorts the overlay headers by return time, this overwrites FC order."));
            if (Configuration.OverlaySort)
            {
                ImGuiHelpers.ScaledIndent(10.0f);
                changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Reverse Sort", "Reverse Sort"), ref Configuration.OverlaySortReverse);
                ImGuiHelpers.ScaledIndent(-10.0f);
            }
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Only Returned", "Only Show Returned"), ref Configuration.OverlayOnlyReturned);
            ImGuiHelpers.ScaledIndent(-10.0f);

            ImGuiHelpers.ScaledDummy(5.0f);

            ImGui.TextColored(ImGuiColors.DalamudViolet, Loc.Localize("Config Tab Entry - Colors", "Colors:"));
            ImGuiHelpers.ScaledIndent(10.0f);
            var spacing = 150 * ImGuiHelpers.GlobalScale;
            changed |= Helper.ColorPickerWithReset(Loc.Localize("Config Tab Colors - All Done", "All Done"), ref Configuration.OverlayAllDone, Helper.CustomFullyDone, spacing);
            changed |= Helper.ColorPickerWithReset(Loc.Localize("Config Tab Colors - Partly Done", "Partly Done"), ref Configuration.OverlayPartlyDone, Helper.CustomPartlyDone,spacing);
            changed |= Helper.ColorPickerWithReset(Loc.Localize("Config Tab Colors - None Done", "None Done"), ref Configuration.OverlayNoneDone, Helper.CustomOnRoute, spacing);
            ImGuiHelpers.ScaledIndent(-10.0f);

            ImGuiHelpers.ScaledDummy(5.0f);

            ImGui.TextColored(ImGuiColors.DalamudViolet, Loc.Localize("Config Tab Entry - Window", "Window:"));
            ImGuiHelpers.ScaledIndent(10.0f);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Lock Size", "Lock Size"), ref Configuration.OverlayLockSize);
            changed |= ImGui.Checkbox(Loc.Localize("Config Tab Checkbox - Lock Position", "Lock Position"), ref Configuration.OverlayLockLocation);
            ImGuiHelpers.ScaledIndent(-10.0f);

            if (changed)
                Configuration.Save();

            ImGui.EndTabItem();
        }
    }
}
