using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ld56;

public interface IDialogItem { }

public struct DialogItem : IDialogItem {
  public required string Text { get; set; }
  public required string Speaker { get; set; }
  public Action GetReward { get; set; }
}

public struct DialogOption {
  public required string OptionText { get; set; }
  public Func<bool>? IsAvailable { get; set; }
  public Func<Creature, Task>? OnSelect { get; set; }
}

public struct DialogOptions : IDialogItem {
  public required string Text { get; set; }
  public required string Speaker { get; set; }
  public required List<DialogOption> Options { get; set; }
}

