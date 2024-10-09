using Godot;


public partial class SoundManager : Node {
  public static SoundManager New() {
    return GD.Load<PackedScene>("res://Scenes/SoundManager.tscn").Instantiate<SoundManager>();
  }
  public SoundManager() {
    foreach (var @interface in GetType().GetInterfaces()) {
      AddToGroup(@interface.Name);
    }
  }

  public partial class SoundManagerNodes {
    SoundManager parent;

    public SoundManagerNodes(SoundManager parent) {
      this.parent = parent;
    }
    // Scene: ./Scenes/SoundManager.tscn
    private AudioStreamPlayer? _AudioStreamPlayer2D;
    public AudioStreamPlayer AudioStreamPlayer2D {
      get => _AudioStreamPlayer2D ??= parent.GetNode<AudioStreamPlayer>("AudioStreamPlayer2D");
    }

    private AudioStreamPlayer? _MusicStreamPlayer;
    public AudioStreamPlayer MusicStreamPlayer {
      get => _MusicStreamPlayer ??= parent.GetNode<AudioStreamPlayer>("MusicStreamPlayer");
    }

  }

  public SoundManagerNodes? _Nodes;
  public SoundManagerNodes Nodes {
    get {
      return _Nodes ??= new SoundManagerNodes(this);
    }
  }
}
