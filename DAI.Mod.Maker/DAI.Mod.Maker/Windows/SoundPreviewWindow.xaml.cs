using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.FrostbiteAssets;

namespace DAI.Mod.Maker {
    public partial class SoundPreviewWindow : Window, IComponentConnector {
        private MediaPlayer SoundPlayer;

        private List<byte[]> SoundStreams;

        private int PlayingIndex;

        private bool IsPlaying;

        private System.Timers.Timer UpdateTimer;

        public SoundPreviewWindow(SoundWaveAsset InSoundWave) {
            InitializeComponent();
            List<ChunkRef> chunkAssets = new List<ChunkRef>();
            foreach (SoundDataChunk chunk in InSoundWave.Chunks) {
                ChunkRef chunkRef = Library.GetChunkById(chunk.ChunkId);
                chunkAssets.Add(chunkRef);
            }
            ChunksListBox.ItemsSource = chunkAssets;
        }

        private void ChunksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ChunksListBox.SelectedIndex == -1) {
                return;
            }
            ChunkRef selectedItem = (ChunkRef)ChunksListBox.SelectedItem;
            SoundStreams = new List<byte[]>();
            SoundPlayer = new MediaPlayer();
            BinaryReader binaryReader = new BinaryReader(new MemoryStream(PayloadProvider.GetAssetPayload(selectedItem)));
            long streamStart = -1L;
            SoundStreams.Clear();
            StreamsListBox.Items.Clear();
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                if (binaryReader.BaseStream.Position + 8 >= binaryReader.BaseStream.Length) {
                    if (streamStart == -1) {
                        streamStart = 8L;
                    }
                    byte[] numArray = new byte[(int)binaryReader.BaseStream.Length - streamStart];
                    binaryReader.BaseStream.Seek(streamStart, SeekOrigin.Begin);
                    numArray = binaryReader.ReadBytes((int)((int)binaryReader.BaseStream.Length - streamStart));
                    SoundStreams.Add(numArray);
                    StreamsListBox.Items.Add("Stream #" + (SoundStreams.Count - 1));
                    streamStart = -1L;
                    continue;
                }
                uint num3 = binaryReader.ReadLEUInt();
                uint num2 = binaryReader.ReadLEUInt();
                if (num3 != 1207959564 || (num2 != 369146752 && num2 != 369408896)) {
                    binaryReader.BaseStream.Seek(-7L, SeekOrigin.Current);
                } else if (streamStart != -1) {
                    long position1 = binaryReader.BaseStream.Position - 8;
                    byte[] numArray2 = new byte[position1 - streamStart];
                    binaryReader.BaseStream.Seek(streamStart, SeekOrigin.Begin);
                    numArray2 = binaryReader.ReadBytes((int)(position1 - streamStart));
                    SoundStreams.Add(numArray2);
                    StreamsListBox.Items.Add("Stream #" + (SoundStreams.Count - 1));
                    streamStart = -1L;
                } else {
                    streamStart = binaryReader.BaseStream.Position - 8;
                }
            }
            binaryReader.Close();
            PlayingIndex = -1;
            ChunkNameTextBox.Text = selectedItem.ChunkId.ToString();
            UpdateTimer = new System.Timers.Timer(100.0);
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e) {
            try {
                string tempPath = Path.GetTempPath();
                int selectedIndex = StreamsListBox.SelectedIndex;
                SoundPlayer = new MediaPlayer();
                SoundPlayer.Open(new Uri(SaveSoundToMp3($"{tempPath}{selectedIndex}.mp3")));
                SoundPlayer.Play();
                SoundPlayer.MediaEnded += SoundPlayer_MediaEnded;
                StopButton.IsEnabled = true;
                PlayButton.IsEnabled = false;
                ExtractButton.IsEnabled = false;
                UpdateTimer.Enabled = true;
                IsPlaying = true;
            } catch (Exception) {
            }
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e) {
            using (SaveFileDialog dlg = new SaveFileDialog()) {
                dlg.DefaultExt = ".mp3";
                dlg.Filter = "MP3|*.mp3";
                dlg.AddExtension = true;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    SaveSoundToMp3(dlg.FileName);
                    System.Windows.Forms.MessageBox.Show("Sound asset succesfully extracted.  Yay!");
                }
            }
        }

        private string SaveSoundToMp3(string outputPath) {
            int selectedIndex = (PlayingIndex = StreamsListBox.SelectedIndex);
            string tempPath = Path.GetTempPath();
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(string.Concat(new object[3] { tempPath, selectedIndex, ".snd" }), FileMode.Create));
            MemoryStream memoryStream = new MemoryStream(SoundStreams[selectedIndex]);
            binaryWriter.Write(memoryStream.ToArray());
            binaryWriter.Close();
            string str = "\"" + Directory.GetCurrentDirectory() + "\\Resources\\ealayer3.exe\"";
            object[] objArray = new object[6] { "\"", tempPath, selectedIndex, ".snd\" -o \"", outputPath, "\"" };
            Process process = Process.Start(new ProcessStartInfo(str, string.Concat(objArray)) {
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
            while (!process.HasExited) {
                Thread.Sleep(100);
            }
            return $"{tempPath}\\{selectedIndex}.mp3";
        }

        private void SoundPlayer_MediaEnded(object sender, EventArgs e) {
            SoundProgressBar.Value = SoundProgressBar.Maximum;
            SoundPlayer.Close();
            string tempPath = Path.GetTempPath();
            File.Delete(tempPath + "\\" + PlayingIndex + ".mp3");
            File.Delete(tempPath + "\\" + PlayingIndex + ".snd");
            PlayButton.IsEnabled = true;
            ExtractButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            UpdateTimer.Enabled = false;
            IsPlaying = false;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e) {
            SoundPlayer.Stop();
            SoundPlayer.Close();
            string tempPath = Path.GetTempPath();
            File.Delete(tempPath + "\\" + PlayingIndex + ".mp3");
            File.Delete(tempPath + "\\" + PlayingIndex + ".snd");
            PlayButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            ExtractButton.IsEnabled = true;
            IsPlaying = false;
        }

        private void StreamsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            PlayButton.IsEnabled = StreamsListBox.SelectedIndex != -1 && !IsPlaying;
            ExtractButton.IsEnabled = PlayButton.IsEnabled;
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e) {
            SoundProgressBar.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                if (SoundPlayer.NaturalDuration.HasTimeSpan) {
                    SoundProgressBar.Maximum = SoundPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                    SoundProgressBar.Value = SoundPlayer.Position.TotalMilliseconds;
                }
                return null;
            }, null);
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (SoundPlayer != null) {
                SoundPlayer.Stop();
                SoundPlayer.Close();
            }
            string tempPath = Path.GetTempPath();
            File.Delete(tempPath + "\\" + PlayingIndex + ".mp3");
            File.Delete(tempPath + "\\" + PlayingIndex + ".snd");
        }
    }
}
