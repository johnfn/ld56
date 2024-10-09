using Godot;
using ld56;
using System;

public enum Music {
  Intro,
  Game,
  Spy,
}

public partial class SoundManager : Node {
  // Page turn SFX
  [Export] public AudioStream[] PageTurnSFX = [];
  [Export] public AudioStream ButtonPressSFX;
  [Export] public AudioStream HoverSFX;
  [Export] public AudioStream[] CookingSFX = [];

  [Export] public AudioStream IntroMusic;
  [Export] public AudioStream GameMusic;
  [Export] public AudioStream SpyMusic;

  public AudioStream[][] Voices = [];

  public static SoundManager Instance { get; private set; }

  public void PlayMusic(Music music) {
    Nodes.MusicStreamPlayer.Stop();
    Nodes.MusicStreamPlayer.Stream = music switch {
      Music.Intro => IntroMusic,
      Music.Game => GameMusic,
      Music.Spy => SpyMusic,
    };
    Nodes.MusicStreamPlayer.Play();
    Nodes.MusicStreamPlayer.VolumeDb = -10;
  }

  public void PlayPageTurnSFX() {
    GD.Randomize();
    if (PageTurnSFX.Length == 0) {
      GD.PushWarning("No page turn SFX set for Rolodex.");
      return;
    }
    var randomIndex = GD.Randi() % PageTurnSFX.Length;
    var randomPageTurnSFX = PageTurnSFX[randomIndex];
    Nodes.AudioStreamPlayer2D.Stream = randomPageTurnSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }

  public void PlayButtonPressSFX() {
    Nodes.AudioStreamPlayer2D.Stream = ButtonPressSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }

  public void PlayHoverSFX() {
    Nodes.AudioStreamPlayer2D.Stream = HoverSFX;
    Nodes.AudioStreamPlayer2D.Play();
  }

  private double lastVoicePlayTime = 0;

  public void PlayVoiceSfx(int voiceIndex) {
    double currentTime = Time.GetTicksMsec() / 1000.0;
    if (currentTime - lastVoicePlayTime < 0.1) {
      return;
    }

    if (voiceIndex < 0 || voiceIndex >= Voices.Length) {
      GD.PushWarning($"Invalid voice index: {voiceIndex}");
      return;
    }

    var randomVoiceIndex = GD.Randi() % Voices[voiceIndex].Length;
    var randomVoice = Voices[voiceIndex][randomVoiceIndex];
    Nodes.AudioStreamPlayer2D.Stream = randomVoice;
    Nodes.AudioStreamPlayer2D.Play();
    lastVoicePlayTime = currentTime;
  }


  // Called when the node enters the scene tree for the first time.
  public override void _Ready() {
    Instance = this;

    Voices = [
    [
      GD.Load<AudioStream>("res://voices/voice1/voice1_01.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_02.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_03.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_04.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_05.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_06.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_07.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_08.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_09.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_10.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_11.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_12.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_13.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_14.wav"),
      GD.Load<AudioStream>("res://voices/voice1/voice1_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice2/voice2_01.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_02.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_03.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_04.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_05.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_06.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_07.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_08.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_09.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_10.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_11.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_12.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_13.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_14.wav"),
      GD.Load<AudioStream>("res://voices/voice2/voice2_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice3/voice3_01.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_02.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_03.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_04.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_05.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_06.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_07.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_08.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_09.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_10.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_11.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_12.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_13.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_14.wav"),
      GD.Load<AudioStream>("res://voices/voice3/voice3_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice4/voice4_01.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_02.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_03.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_04.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_05.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_06.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_07.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_08.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_09.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_10.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_11.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_12.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_13.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_14.wav"),
      GD.Load<AudioStream>("res://voices/voice4/voice4_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice5/voice5_01.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_02.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_03.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_04.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_05.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_06.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_07.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_08.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_09.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_10.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_11.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_12.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_13.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_14.wav"),
      GD.Load<AudioStream>("res://voices/voice5/voice5_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice6/voice6_01.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_02.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_03.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_04.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_05.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_06.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_07.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_08.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_09.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_10.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_11.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_12.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_13.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_14.wav"),
      GD.Load<AudioStream>("res://voices/voice6/voice6_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice7/voice7_01.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_02.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_03.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_04.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_05.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_06.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_07.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_08.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_09.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_10.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_11.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_12.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_13.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_14.wav"),
      GD.Load<AudioStream>("res://voices/voice7/voice7_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice8/voice8_01.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_02.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_03.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_04.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_05.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_06.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_07.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_08.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_09.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_10.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_11.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_12.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_13.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_14.wav"),
      GD.Load<AudioStream>("res://voices/voice8/voice8_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice9/voice9_01.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_02.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_03.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_04.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_05.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_06.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_07.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_08.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_09.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_10.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_11.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_12.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_13.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_14.wav"),
      GD.Load<AudioStream>("res://voices/voice9/voice9_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice10/voice10_01.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_02.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_03.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_04.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_05.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_06.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_07.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_08.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_09.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_10.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_11.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_12.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_13.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_14.wav"),
      GD.Load<AudioStream>("res://voices/voice10/voice10_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice11/voice11_01.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_02.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_03.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_04.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_05.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_06.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_07.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_08.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_09.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_10.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_11.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_12.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_13.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_14.wav"),
      GD.Load<AudioStream>("res://voices/voice11/voice11_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice12/voice12_01.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_02.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_03.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_04.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_05.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_06.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_07.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_08.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_09.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_10.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_11.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_12.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_13.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_14.wav"),
      GD.Load<AudioStream>("res://voices/voice12/voice12_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice13/voice13_01.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_02.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_03.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_04.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_05.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_06.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_07.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_08.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_09.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_10.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_11.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_12.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_13.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_14.wav"),
      GD.Load<AudioStream>("res://voices/voice13/voice13_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice14/voice14_01.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_02.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_03.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_04.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_05.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_06.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_07.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_08.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_09.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_10.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_11.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_12.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_13.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_14.wav"),
      GD.Load<AudioStream>("res://voices/voice14/voice14_15.wav"),
    ],
    [
      GD.Load<AudioStream>("res://voices/voice15/voice15_01.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_02.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_03.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_04.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_05.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_06.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_07.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_08.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_09.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_10.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_11.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_12.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_13.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_14.wav"),
      GD.Load<AudioStream>("res://voices/voice15/voice15_15.wav"),
    ]
  ];
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta) {
  }
}
