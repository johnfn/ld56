using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ld56;

public interface IDialogItem { }

public struct DialogReward : IDialogItem {
  public string Text { get; set; }
  public Action<bool> GetReward { get; set; }
}

public struct DialogItem : IDialogItem {
  public string Text { get; set; }
  public string Speaker { get; set; }
}

public struct DialogOption {
  public string OptionText { get; set; }
  public Func<bool>? IsAvailable { get; set; }
  public Func<Task>? OnSelect { get; set; }
}

public struct DialogOptions : IDialogItem {
  public List<DialogOption> Options { get; set; }
}

